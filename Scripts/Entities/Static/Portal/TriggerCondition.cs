using Godot;
using Godot.Collections;

namespace _svetlogo.Entities.Static
{
    public partial class TriggerCondition : PortalCondition
    {
        [Export] private bool inverse;
        [Export] private Array<string> triggers;
        private Array<string> activatedTriggers;

        public override bool CheckCondition(SceneTree tree)
        {
            foreach (var trigger in triggers)
            {
                bool check = false;
                foreach(var activatedTrigger in activatedTriggers)
                {
                    if (trigger == activatedTrigger)
                        check = true;
                        break;
                }
                if (check) continue;
                return false;
            }
            return true;
        }

        public void AddTrigger(string trigger)
        {
            if (activatedTriggers.Contains(trigger)) return;
            activatedTriggers.Add(trigger);
        }
    }
}
