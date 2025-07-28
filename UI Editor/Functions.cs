using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace UI_Editor
{
    enum Effect
    {
        Translate,
        ChangeScene,
        Resize,
        ChangeColor,
        CustomDebug
    }

    enum Transition
    {
        None=0,
        Linear=1,
        Logarithmic=2,
        Exponential=3
    }

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "Function")]
    [JsonDerivedType(typeof(Debugging), "Debugging")]
    [JsonDerivedType(typeof(Translate), "Translate")]
    internal class Functions
    {
        public void Execute(Element element) { }
    }

    internal class Translate : Functions
    {
        public PointSerializable translation { get; set; }
        public Transition transition { get; set; }

        public void Execute(Element element)
        {
            // translation here
        }
    }

    internal class Debugging : Functions
    {
        public int number { get; set; }
        public Transition transition { get; set; }
        public PointSerializable translation { get; set; }
        public void Execute(Element element)
        {

        }
    }
}
