using _svetlogo.Entities;
using _svetlogo.Tools;
using Godot;

namespace _svetlogo
{
    public partial class Cursor : Node2D
    {
        private RayCast2D _rayCast;

        public override void _Ready()
        {
            _rayCast = GetNode<RayCast2D>("RayCast2D");
        }

        public override void _Process(double delta)
        {
            GlobalPosition = GetGlobalMousePosition();
            
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton button_event)
            {
                Tool tool = GetParent<ToolContainer>().GetTool();
                if (button_event.ButtonIndex == MouseButton.Left)
                {
                    if (button_event.Pressed)
                    {
                        if (tool is IBeginDragLMB dragLMB)
                        {
                            dragLMB.BeginDragLMB(GlobalPosition, _rayCast.GetCollider() as Entity);
                        }
                    }
                    else
                    {
                        if (tool is IEndDragLMB dragLMB)
                        {
                            dragLMB.EndDragLMB(GlobalPosition, _rayCast.GetCollider() as Entity);
                        }
                    }
                }
                else if (button_event.ButtonIndex == MouseButton.Right)
                {
                    if (button_event.Pressed)
                    {
                        if (tool is IBeginDragRMB dragRMB)
                        {
                            dragRMB.BeginDragRMB(GlobalPosition, _rayCast.GetCollider() as Entity);
                        }
                    }
                    else
                    {
                        if (tool is IEndDragRMB dragRMB)
                        {
                            dragRMB.EndDragRMB(GlobalPosition, _rayCast.GetCollider() as Entity);
                        }
                    }
                }
            }
        }
    }
}