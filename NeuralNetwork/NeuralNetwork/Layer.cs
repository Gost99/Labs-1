
using System.Xml;
using static System.Console;
namespace NeuralNetwork
{
    abstract class Layer
    {
        protected Layer(int non, int nopn, NeuronType nt, string type)
        {//увидите это в WeightInitialize
            numofneurons = non;
            numofprevneurons = nopn;
            Neurons = new Neuron[non];
            double[,] Weights = WeightInitialize(MemoryMode.GET, type);
            for (int i = 0; i < non; ++i)
            {
                double[] temp_weights = new double[nopn];
                for (int j = 0; j < nopn; ++j)
                    temp_weights[j] = Weights[i, j];
                Neurons[i] = new Neuron(null, temp_weights, nt);//про подачу null на входы ниже
            }
        }
        protected int numofneurons;//число нейронов текущего слоя
        protected int numofprevneurons;//число нейронов предыдущего слоя
        protected const double learningrate = 0.1d;//скорость обучения
        Neuron[] _neurons;
        public Neuron[] Neurons { get => _neurons; set => _neurons = value; }
        public double[] Data//я подал null на входы нейронов, так как
        {//сначала нужно будет преобразовать информацию
            set//(видео, изображения, etc.)
            {//а загружать input'ы нейронов слоя надо не сразу,
                for (int i = 0; i < Neurons.Length; ++i)
                    Neurons[i].Inputs = value;
            }//а только после вычисления выходов предыдущего слоя
        }
        public double[,] WeightInitialize(MemoryMode mm, string type)
        {
            double[,] _weights = new double[numofneurons, numofprevneurons];
            WriteLine($"{type} weights are being initialized...");
            XmlDocument memory_doc = new XmlDocument();
            memory_doc.Load($"{type}memory_doc.xml");
            XmlElement memory_el = memory_doc.DocumentElement;
            switch (mm)
            {
                case MemoryMode.GET:
                    for (int l = 0; l < _weights.GetLength(0); ++l)
                        for (int k = 0; k < _weights.GetLength(1); ++k)
                            _weights[l, k] = double.Parse(memory_el.ChildNodes.Item(k + _weights.GetLength(1) * l).InnerText.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);//parsing stuff
                    break;
                case MemoryMode.SET:
                    for (int l = 0; l < Neurons.Length; ++l)
                        for (int k = 0; k < numofprevneurons; ++k)
                            memory_el.ChildNodes.Item(k + numofprevneurons * l).InnerText = Neurons[l].Weights[k].ToString();
                    break;
            }
            memory_doc.Save($"{type}memory_doc.xml");
            WriteLine($"{type} weights have been initialized...");
            return _weights;
        }
        abstract public void Recognize(Network net, Layer nextLayer);//для прямых проходов
        abstract public double[] BackwardPass(double[] stuff);//и обратных
    }
}
