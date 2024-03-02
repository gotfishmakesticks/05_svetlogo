using Godot;
using System;

public partial class Player : CharacterBody2D
{
	const float gravity = 98.1f;
	const float jumpForce = 125f;

	[Export] private float max_speed;
	[Export] private float acceleration_time;
	[Export] private float deceleration_time;

	private float acceleration;
	private float deceleration;

    public override void _Ready()
    {
		acceleration = max_speed / acceleration_time;
		deceleration = max_speed / deceleration_time;
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;


		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = -jumpForce;

		float direction = Input.GetAxis("move_left", "move_right");
		if (IsOnFloor())
		{
			if (direction != 0 && velocity.X < max_speed)
			{
				if (Mathf.Sign(velocity.X) != direction)
				{
					velocity.X += direction * deceleration * (float)delta;
				}
				else
				{
					velocity.X += direction * acceleration * (float)delta;
				}
			}
			else
			{
				velocity.X -= Mathf.Sign(velocity.X) * deceleration * (float)delta;
			}
		}
		else
		{
            if (Mathf.Sign(velocity.X) != direction)
            {
                velocity.X += direction * deceleration * (float)delta * 0.33f;
            }
            else
            {
                velocity.X += direction * acceleration * (float)delta * 0.33f;
            }
        }

		if (Mathf.Abs(velocity.X) < 0.25)
		{
			velocity.X = 0;
		}	

		Velocity = velocity;
		MoveAndSlide();
	}
}
