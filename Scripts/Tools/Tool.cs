using Godot;

namespace _svetlogo.Tools
{
    [GlobalClass]
    public abstract partial class Tool : Resource
    {
        public abstract void OnSelect();
        public abstract void Process(double delta);
        public abstract void OnDeselect();
    }
}