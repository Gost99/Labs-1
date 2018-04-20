
namespace NeuralNetwork
{
    class InputLayer
    {
          // <InputLayer Include = "System.ValueTuple" Version="4.4.0" />;
        private (double[], double[])[] _trainset = new(double[], double[])[]
        {

            (new double[]{ 0, 0 }, new double[]{ 0, 1 }),
            (new double[]{ 0, 1 }, new double[]{ 1, 0 }),
            (new double[]{ 1, 0 }, new double[]{ 1, 0 }),
            (new double[]{ 1, 1 }, new double[]{ 0, 1 })
                };
        //инкапсулция
        public (double[], double[])[] Trainset { get => _trainset; }
    }
}
