using _svetlogo.Entities;
using Godot;

namespace _svetlogo.Abilities
{
    [GlobalClass]
    public abstract partial class Ability : Resource
    {
        public abstract void OnReady(Entity invoker);
        public abstract void StartAbility(Entity invoker);
        public abstract void ProcessAbility(Entity invoker);
        public abstract void StopAbility(Entity invoker);
    }
}