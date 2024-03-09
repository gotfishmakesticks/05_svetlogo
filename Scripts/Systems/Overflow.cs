using Godot;
using _svetlogo.Entities;

namespace _svetlogo.Systems
{
	public partial class Overflow : Node
	{
		[Export] private float mass_treshold;
		[Export]private float mass;

		public bool IsOverflowed { get; private set; } = false;

		[Signal]
		public delegate void OnOverflowEventHandler();
		[Signal]
		public delegate void OnOverflowEndEventHandler();

        public void AddMass(float mass)
		{
			this.mass += mass;
			if (this.mass >= mass_treshold)
			{
				IsOverflowed = true;

				foreach (Entity entity in Level.instance.Entities)
				{
					entity.StartOverload();
					EmitSignal(SignalName.OnOverflow);
				}
			}
			else if (IsOverflowed == true)
			{
                foreach (Entity entity in Level.instance.Entities)
                {
                    entity.StopOverload();
                    EmitSignal(SignalName.OnOverflowEnd);

                }

                IsOverflowed = false;
            }
		}
	}
}