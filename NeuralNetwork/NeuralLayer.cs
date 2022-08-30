namespace NeuralNetwork;

public class NeuralLayer
{
    public List<INeuron> Neurons;

    public NeuralLayer()
    {
        Neurons = new();
    }

    /// <summary>
    ///     Connecting two layers.
    /// </summary>
    public void ConnectLayers(NeuralLayer inputLayer)
    {
        var combos = Neurons.SelectMany(neuron => inputLayer.Neurons, (neuron, input) => new {neuron, input});
        combos.ToList().ForEach(x => x.neuron.AddInputNeuron(x.input));
    }
}