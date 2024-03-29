﻿namespace NeuralNetwork;

public class SigmoidActivationFunction : IActivationFunction
{
    private readonly double _coeficient;

    public SigmoidActivationFunction(double coeficient)
    {
        _coeficient = coeficient;
    }

    public double CalculateOutput(double input)
    {
        return 1 / (1 + Math.Exp(-input * _coeficient));
    }
}