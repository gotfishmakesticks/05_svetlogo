using _svetlogo.Tools;
using Godot;
using System;

namespace _svetlogo.Entities.Animate
{
	public partial class PlayerMovement : RigidBody2D
	{
		const float jumpForce = 325f;

		public PlayerData PlayerData { get; private set; }

        [Export] private float max_speed;
		[Export] private float acceleration_time;
		[Export] private float deceleration_time;

		private bool jump_cached;
		private float acceleration;
		private float deceleration;
		private bool floor_cached;

		private Timer jump_cache_timer;
		private ShapeCast2D floor_detector;

		public override void _Ready()
		{
			acceleration = max_speed / acceleration_time;
			deceleration = max_speed / deceleration_time;

			jump_cache_timer = GetNode<Timer>("JumpCacheTimer");
			floor_detector = GetNode<ShapeCast2D>("FloorDetector");
			PlayerData = GetNode<PlayerData>("PlayerData");
		}

        public override void _IntegrateForces(PhysicsDirectBodyState2D state)
		{

			Vector2 velocity = LinearVelocity;

            float res_acceleration = 0.0f;

			if (Input.IsActionJustPressed("jump") && jump_cached)
			{
				ApplyCentralImpulse(Vector2.Up*jumpForce*Mass);
				jump_cached = false;	
			}

			if (floor_detector.IsColliding() != floor_cached)
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

            floor_cached = floor_detector.IsColliding();

            if (floor_cached)
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

			ConstantForce = Vector2.Right * Mass * res_acceleration;
		}

		public void JumpCacheTimeout()
		{
			jump_cached = false;
		}
    }
}