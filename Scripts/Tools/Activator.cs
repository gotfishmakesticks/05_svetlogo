using _svetlogo.Entities;
using Godot;

namespace _svetlogo.Tools
{
    [GlobalClass]
    public partial class Activator : Tool, IEndDragLMB
    {
        public void EndDragLMB(Vector2 mousePosition, IEntity clickedEntity)
        {
            if (clickedEntity == null) return;

            clickedEntity.StopOverload();
            clickedEntity.StartOverload();
        }

        public override void OnDeselect()
        {
        }

        public override void OnSelect()
        {
        }

        public override void Process(double delta)
        {
        }
    }
}