using Godot;
using System;

namespace _svetlogo.Entities
{
	public partial class Circle : RigidBody2D, IEntity
	{
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

        public void StartOverload()
        {
            throw new NotImplementedException();
        }

        public void StopOverload()
        {
            throw new NotImplementedException();
        }
    }
}