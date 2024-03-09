using Godot;
using Godot.Collections;

namespace _svetlogo.Entities.Static
{
    public partial class ButtonCondition : PortalCondition
    {
        [Export] private bool inverse;
        [Export] private Array<PhysicalButton> _buttons;

        public override bool CheckCondition(SceneTree tree)
        {
            foreach (var button in _buttons)
            {
                if (button.Activated == inverse) return false;
            }
            return true;
        }
    }
}
