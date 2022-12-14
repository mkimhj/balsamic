using System;
using System.Collections.Generic;
using System.Text;

namespace NnCase.Converter.Model.Layers
{
    public class ChannelwiseDequantize : Layer
    {
        public InputConnector Input { get; }

        public OutputConnector Output { get; }

        public string Name { get; set; }

        public ChannelwiseDequantize(ReadOnlySpan<int> dimensions)
        {
            Input = AddInput("input", dimensions);
            Output = AddOutput("output", dimensions);
        }

        protected override void OnPlanning(GraphPlanContext context)
        {
            context.TFOutputs[Output] = context.TFGraph.Identity(context.TFOutputs[Input.Connection.From], Name);
        }
    }
}
