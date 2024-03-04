using _svetlogo.Tools;
using Godot;
using System;

namespace _svetlogo.Entities.Animate
{
	public partial class PlayerMovement : CharacterBody2D
	{
		const float gravity = 981f;
		const float jumpForce = 275f;



        [Export] private float max_speed;
		[Export] private float acceleration_time;
		[Export] private float deceleration_time;
		[Export] private float mass;

		private bool jump_cached;
		private float acceleration;
		private float deceleration;
		private bool floor_cached;

		private Timer jump_cache_timer;

		public override void _Ready()
		{
			acceleration = max_speed / acceleration_time;
			deceleration = max_speed / deceleration_time;

			jump_cache_timer = GetNode<Timer>("JumpCacheTimer");
		}

		public override void _PhysicsProcess(double delta)
		{
			Vector2 velocity = Velocity;

            float res_acceleration = 0.0f;

			if (IsOnFloor() != floor_cached)
			{
				if (floor_cached)
				{
					jump_cache_timer.Start();
				}
				else
				{
					jump_cache_timer.Stop();
					jump_cached = true;
				}
			}

            floor_cached = IsOnFloor();

            if (IsOnFloor() || IsOnCeiling())
			{
				res_acceleration -= deceleration * velocity.X/max_speed;
			}

			float direction = Input.GetAxis("move_left", "move_right");

			if ((velocity.X < max_speed && direction > 0) || (velocity.X > -max_speed && direction < 0))
			{
				res_acceleration += direction * (acceleration + deceleration);
			}
			else if (direction == Mathf.Sign(velocity.X)) 
			{
                res_acceleration = 0;
			}

			velocity.X += res_acceleration * (float)delta;

			velocity.Y += gravity * (float)delta;
			if (Input.IsActionJustPressed("jump") && jump_cached)
			{
				velocity.Y = -jumpForce;
			}

			Velocity = velocity;
			MoveAndSlide();

			for (int i = 0; i < GetSlideCollisionCount(); i++)
			{
				var collision = GetSlideCollision(i);
				if (collision != null)
				{
					var collider = collision.GetCollider();
					if (collider is RigidBody2D rigid)
					{
						rigid.ApplyImpulse(-collision.GetNormal() * mass,rigid.ToLocal(collision.GetPosition()));
					}
				}
			}
        }

		public void JumpCacheTimeout()
		{
			jump_cached = false;
		}
    }
}