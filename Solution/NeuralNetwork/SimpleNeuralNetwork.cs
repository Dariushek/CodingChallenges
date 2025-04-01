namespace NeuralNetwork;

public class SimpleNeuralNetwork
{
    private readonly NeuralLayerFactory layerFactory;
    private double[][]? expectedResult;
    private readonly List<NeuralLayer> layers;
    private readonly double learningRate;

    /// <summary>
    ///     Constructor of the Neural Network.
    ///     Note:
    ///     Initialy input layer with defined number of inputs will be created.
    /// </summary>
    /// <param name="numberOfInputNeurons">
    ///     Number of neurons in input layer.
    /// </param>
    public SimpleNeuralNetwork(int numberOfInputNeurons)
    {
        layers = new();
        layerFactory = new();

        // Create input layer that will collect inputs.
        CreateInputLayer(numberOfInputNeurons);

        learningRate = 2.95;
    }

    /// <summary>
    ///     Add layer to the neural network.
    ///     Layer will automatically be added as the output layer to the last layer in the neural network.
    /// </summary>
    public void AddLayer(NeuralLayer newLayer)
    {
        if (layers.Any())
        {
            NeuralLayer lastLayer = layers.Last();
            newLayer.ConnectLayers(lastLayer);
        }

        layers.Add(newLayer);
    }

    /// <summary>
    ///     Push input values to the neural network.
    /// </summary>
    public void PushInputValues(double[] inputs)
    {
        layers.First().Neurons.ForEach(x => x.PushValueOnInput(inputs[layers.First().Neurons.IndexOf(x)]));
    }

    /// <summary>
    ///     Set expected values for the outputs.
    /// </summary>
    public void PushExpectedValues(double[][] expectedOutputs)
    {
        expectedResult = expectedOutputs;
    }

    /// <summary>
    ///     Calculate output of the neural network.
    /// </summary>
    /// <returns></returns>
    public List<double> GetOutput()
    {
        var returnValue = new List<double>();

        layers.Last().Neurons.ForEach(neuron =>
        {
            returnValue.Add(neuron.CalculateOutput());
        });

        return returnValue;
    }

    /// <summary>
    ///     Train neural network.
    /// </summary>
    /// <param name="inputs">Input values.</param>
    /// <param name="numberOfEpochs">Number of epochs.</param>
    public void Train(double[][] inputs, int numberOfEpochs)
    {
        double totalError = 0;

        for (var i = 0; i < numberOfEpochs; i++)
        {
            for (var j = 0; j < inputs.GetLength(0); j++)
            {
                PushInputValues(inputs[j]);

                var outputs = new List<double>();

                // Get outputs.
                layers.Last().Neurons.ForEach(x =>
                {
                    outputs.Add(x.CalculateOutput());
                });

                // Calculate error by summing errors on all output neurons.
                totalError = CalculateTotalError(outputs, j);
                HandleOutputLayer(j);
                HandleHiddenLayers();
            }
        }
    }

    /// <summary>
    ///     Hellper function that creates input layer of the neural network.
    /// </summary>
    private void CreateInputLayer(int numberOfInputNeurons)
    {
        NeuralLayer inputLayer = layerFactory.CreateNeuralLayer(numberOfInputNeurons, new RectifiedActivationFunction(), new WeightedSumFunction());
        inputLayer.Neurons.ForEach(x => x.AddInputSynapse(0));
        AddLayer(inputLayer);
    }

    /// <summary>
    ///     Hellper function that calculates total error of the neural network.
    /// </summary>
    private double CalculateTotalError(List<double> outputs, int row)
    {
        double totalError = 0;

        outputs.ForEach(output =>
        {
            if (expectedResult != null)
            {
                double error = Math.Pow(output - expectedResult[row][outputs.IndexOf(output)], 2);
                totalError += error;
            }
        });

        return totalError;
    }

    /// <summary>
    ///     Hellper function that runs backpropagation algorithm on the output layer of the network.
    /// </summary>
    /// <param name="row">
    ///     Input/Expected output row.
    /// </param>
    private void HandleOutputLayer(int row)
    {
        layers.Last().Neurons.ForEach(neuron =>
        {
            neuron.Inputs.ForEach(connection =>
            {
                double output = neuron.CalculateOutput();
                double netInput = connection.GetOutput();

                if (expectedResult != null)
                {
                    double expectedOutput = expectedResult[row][layers.Last().Neurons.IndexOf(neuron)];

                    double nodeDelta = (expectedOutput - output) * output * (1 - output);
                    double delta = -1 * netInput * nodeDelta;

                    connection.UpdateWeight(learningRate, delta);

                    neuron.PreviousPartialDerivate = nodeDelta;
                }
            });
        });
    }

    /// <summary>
    ///     Hellper function that runs backpropagation algorithm on the hidden layer of the network.
    /// </summary>
    /// <param name="row">
    ///     Input/Expected output row.
    /// </param>
    private void HandleHiddenLayers()
    {
        for (int k = layers.Count - 2; k > 0; k--)
        {
            layers[k].Neurons.ForEach(neuron =>
            {
                neuron.Inputs.ForEach(connection =>
                {
                    double output = neuron.CalculateOutput();
                    double netInput = connection.GetOutput();
                    double sumPartial = 0;

                    layers[k + 1].Neurons
                        .ForEach(outputNeuron =>
                        {
                            outputNeuron.Inputs.Where(i => i.IsFromNeuron(neuron.Id))
                                .ToList()
                                .ForEach(outConnection =>
                                {
                                    sumPartial += outConnection.PreviousWeight * outputNeuron.PreviousPartialDerivate;
                                });
                        });

                    double delta = -1 * netInput * sumPartial * output * (1 - output);
                    connection.UpdateWeight(learningRate, delta);
                });
            });
        }
    }
}