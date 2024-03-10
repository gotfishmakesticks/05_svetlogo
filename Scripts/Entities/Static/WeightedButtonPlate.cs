using Godot;
using System;

public partial class WeightedButtonPlate : RigidBody2D
{
    private float start_x;
    public override void _Ready()
    {
        start_x = GlobalPosition.X;
    }
    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        GlobalPosition = new Vector2(start_x,GlobalPosition.Y);
        LinearVelocity = Vector2.Up * state.LinearVelocity;
    }
}
