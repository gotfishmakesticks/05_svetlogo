using _svetlogo.Entities;

namespace _svetlogo.Abilities
{
    public partial class Empty : Ability
    {
        public override void OnReady(Entity invoker) { }

        public override void ProcessAbility(Entity invoker) { }

        public override void StartAbility(Entity invoker)
        {
            invoker.QueueFree();
        }

        public override void StopAbility(Entity invoker)
        {
        }
    }
}