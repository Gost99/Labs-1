
using static System.Math;
using static System.Console;
namespace NeuralNetwork
{
    class Network
    {
        //все слои сети
        InputLayer input_layer = new InputLayer();
        public HiddenLayer hidden_layer = new HiddenLayer(4, 2, NeuronType.Hidden, nameof(hidden_layer));
        public OutputLayer output_layer = new OutputLayer(2, 4, NeuronType.Output, nameof(output_layer));
        //массив для хранения выхода сети
        public double[] fact = new double[2];//не ругайте за 2 пожалуйста
        //ошибка одной итерации обучения
        double GetMSE(double[] errors)
        {
            double sum = 0;
            for (int i = 0; i < errors.Length; ++i)
                sum += Pow(errors[i], 2);
            return 0.5d * sum;
        }
        //ошибка эпохи
        double GetCost(double[] mses)
        {
            double sum = 0;
            for (int i = 0; i < mses.Length; ++i)
                sum += mses[i];
            return (sum / mses.Length);
        }
        //непосредственно обучение
        static void Train(Network net)//backpropagation method
        {
            const double threshold = 0.001d;//порог ошибки
            double[] temp_mses = new double[4];//массив для хранения ошибок итераций
            double temp_cost = 0;//текущее значение ошибки по эпохе
            do
            {
                for (int i = 0; i < net.input_layer.Trainset.Length; ++i)
                {
                    //прямой проход
                    net.hidden_layer.Data = net.input_layer.Trainset[i].Item1;
                    net.hidden_layer.Recognize(null, net.output_layer);
                    net.output_layer.Recognize(net, null);
                    //вычисление ошибки по итерации
                    double[] errors = new double[net.input_layer.Trainset[i].Item2.Length];
                    for (int x = 0; x < errors.Length; ++x)
                        errors[x] = net.input_layer.Trainset[i].Item2[x] - net.fact[x];
                    temp_mses[i] = net.GetMSE(errors);
                    //обратный проход и коррекция весов
                    double[] temp_gsums = net.output_layer.BackwardPass(errors);
                    net.hidden_layer.BackwardPass(temp_gsums);
                }
                temp_cost = net.GetCost(temp_mses);//вычисление ошибки по эпохе
                //debugging
                WriteLine($"{temp_cost}");
            } while (temp_cost > threshold);
            //загрузка скорректированных весов в "память"
            net.hidden_layer.WeightInitialize(MemoryMode.SET, nameof(hidden_layer));
            net.output_layer.WeightInitialize(MemoryMode.SET, nameof(output_layer));
        }
        //тестирование сети
        static void Test(Network net)
        {
            for (int i = 0; i < net.input_layer.Trainset.Length; ++i)
            {
                net.hidden_layer.Data = net.input_layer.Trainset[i].Item1;
                net.hidden_layer.Recognize(null, net.output_layer);
                net.output_layer.Recognize(net, null);
                for (int j = 0; j < net.fact.Length; ++j)
                    WriteLine($"{net.fact[j]}");
                WriteLine();
            }
        }
        //запуск сети
        static void Main(string[] args)
        {
            Network net = new Network();
            Train(net);
            Test(net);
            ReadKey();//чтоб консоль не закрывалась :)
        }
    }
}
