using _svetlogo.Entities;
using Godot;
using System;

namespace _svetlogo.Tools
{
    [GlobalClass]
    public partial class Connection : Tool, IBeginDragLMB, IEndDragLMB
    {
        private Entity firstBody;
        private PinJoint2D firstJoint;

        public override void OnDeselect()
        {
        }

        public override void OnSelect()
        {
        }
        public void BeginDragLMB(Vector2 mousePosition, Entity clickedEntity)
        {
            if (clickedEntity == null) return;


            firstBody = clickedEntity;

            firstJoint = new();
            firstJoint.GlobalPosition = mousePosition;
            firstBody.AddChild(firstJoint);

            firstJoint.NodeA = firstBody.GetPath();
        }

        public override void Process(double delta)
        {
        }
        public void EndDragLMB(Vector2 mousePosition, Entity clickedEntity)
        {
            if (clickedEntity == null || firstBody == null)
            {
                if (firstBody != null)
                {
                    firstJoint.QueueFree();
                }
                

                return;
            }

            if (clickedEntity is PhysicsBody2D body)
            {
                firstJoint.NodeB = body.GetPath();

                PinJoint2D secondJoint = new();
                secondJoint.GlobalPosition = mousePosition;

                body.AddChild(secondJoint);
                secondJoint.NodeA = body.GetPath();
                secondJoint.NodeB = firstBody.GetPath();
            }
        }
    }
}