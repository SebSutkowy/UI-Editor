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
    [JsonDerivedType(typeof(ChangeColor), "ChangeColor")]
    abstract class Functions
    {
        public abstract void Execute(Element element);
    }

    internal class Translate : Functions
    {
        public PointSerializable translation { get; set; }
        public Transition transition { get; set; }

        public override void Execute(Element element)
        {
            // translation here
            switch(transition)
            {
                default:
                    element.Position += translation.ToPoint();
                    break;
            }
        }
    }

    internal class ChangeColor : Functions
    {
        public Color NewColor { get; set; }
        public override void Execute(Element element)
        {
            element.BackgroundColor = NewColor;
        }
    }

    internal class Debugging : Functions
    {
        public override void Execute(Element element)
        {
            Debug.WriteLine(element.GetJson());
        }
    }
}
