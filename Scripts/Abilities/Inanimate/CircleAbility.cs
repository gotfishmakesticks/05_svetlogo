using _svetlogo.Entities;
using Godot;
using System;

namespace _svetlogo.Abilities
{
    [GlobalClass]
    public partial class CircleAbility : Ability
    {
        [Export] private float _torque;
        public override void OnReady(Entity invoker) { }

        public override void ProcessAbility(Entity invoker) 
        { 
            invoker.ConstantTorque = _torque;
        }

        public override void StartAbility(Entity invoker) { }

        public override void StopAbility(Entity invoker) 
        {
            invoker.ConstantTorque = 0;
        }
    }
}