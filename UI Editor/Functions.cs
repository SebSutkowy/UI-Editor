using Microsoft.Xna.Framework;

namespace UI_Editor
{
    enum Effect
    {
        Translate,
        ChangeScene,
        Resize,
        ChangeColor
    }

    enum Transition
    {
        None,
        Linear,
        Logarithmic,
        Exponential
    }

    class Functions
    {
    }

    class Translate : Functions
    {
        public PointSerializable translationDistance { get; set; }
        public Transition translationTransition { get; set; }

        public Translate(Point translation, Transition transition)
        {
            translationDistance = new PointSerializable(translation);
            translationTransition = transition;
        }


    }
}
