using Godot;
using System;

public partial class WeightedButtonPlate : RigidBody2D
{
    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        state.LinearVelocity = Vector2.Up * state.LinearVelocity;
    }
}
