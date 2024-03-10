using Godot;
using Godot.Collections;

namespace _svetlogo.Entities.Static
{
    [GlobalClass]
    public partial class ButtonCondition : PortalCondition
    {
        [Export] private bool inverse;
        [Export] private Array<NodePath> _buttons;

        public override bool CheckCondition(SceneTree tree, Portal portal)
        {
            foreach (var button in _buttons)
            {
                if (portal.GetNode(button) is IButtonActivated btn)
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
