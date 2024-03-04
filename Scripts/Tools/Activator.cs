using _svetlogo.Entities;
using Godot;

namespace _svetlogo.Tools
{
    [GlobalClass]
    public partial class Activator : Tool, IEndDragLMB, IEndDragRMB
    {
        public void EndDragLMB(Vector2 mousePosition, Entity clickedEntity)
        {
            if (clickedEntity == null) return;

            clickedEntity.StopOverload();
            clickedEntity.StartOverload();
        }

        public void EndDragRMB(Vector2 mousePosition, Entity clickedEntity)
        {
            if (clickedEntity == null) return;

            clickedEntity.StopOverload();
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