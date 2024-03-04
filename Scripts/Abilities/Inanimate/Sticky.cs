using _svetlogo.Entities;
using Godot;
using System;

namespace _svetlogo.Abilities
{
    [GlobalClass]
    public partial class Sticky : Ability
    {
        public override void OnReady(Entity invoker)
        {
        }

        public override void ProcessAbility(Entity invoker)
        {
        }

        public override void StartAbility(Entity invoker)
        {
            StickArea stickArea = invoker.GetNode<StickArea>("StickArea");

            stickArea.can_stick = true;
            stickArea.Stick();
        }

        public override void StopAbility(Entity invoker)
        {
            StickArea stickArea = invoker.GetNode<StickArea>("StickArea");

            stickArea.can_stick = false;
            stickArea.Unstick();
        }
    }
}