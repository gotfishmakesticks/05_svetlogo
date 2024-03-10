using _svetlogo.Systems;
using Godot;

namespace _svetlogo.Entities.Static
{
    [GlobalClass]
    public partial class OverflowCondition : PortalCondition
    {
        [Export] private bool inverse;

        public override bool CheckCondition(SceneTree tree)
        {
            if (tree.CurrentScene is Level level)
            {
                return level.Overflow.IsOverflowed != inverse;
            }
            return false;
        }
    }
}
