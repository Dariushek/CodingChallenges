namespace NeuralNetwork;

public class StepActivationFunction : IActivationFunction
{
    private readonly double treshold;

    public StepActivationFunction(double treshold)
    {
        this.treshold = treshold;
    }

    public double CalculateOutput(double input)
    {
        return Convert.ToDouble(input > treshold);
    }
}