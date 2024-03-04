using _svetlogo.Entities;
using Godot;
using System;

namespace _svetlogo.Abilities
{
    public partial class StarAbility : Ability
    {
        public override void OnReady(Entity invoker)
        {
        }

        public override void ProcessAbility(Entity invoker)
        {
        }

        public override void StartAbility(Entity invoker)
        {
            invoker.GetNode<StarHitbox>("Hitbox").activated = true;
        }

        public override void StopAbility(Entity invoker)
        {
            invoker.GetNode<StarHitbox>("Hitbox").activated = false;
        }
    }
}