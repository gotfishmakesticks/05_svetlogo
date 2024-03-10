using Godot;
using Godot.Collections;

namespace _svetlogo.Entities.Static
{
    [GlobalClass]
    public partial class ButtonCondition : PortalCondition
    {
        [Export] private bool inverse;
        [Export] private Array<Node2D> _buttons;

        public override bool CheckCondition(SceneTree tree)
        {
            foreach (var button in _buttons)
            {
                if (button is IButtonActivated btn)
                {
                    if (btn.Activated == inverse) return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
