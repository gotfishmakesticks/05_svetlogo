using Godot;
using _svetlogo.Entities;

namespace _svetlogo.Systems
{
	public partial class Overload : Node
	{
		[Export] private float mass_treshold;
		[Export]private float mass;

		private bool overload = false;

		[Signal]
		public delegate void OnOverflowEventHandler();
		[Signal]
		public delegate void OnOverflowEndEventHandler();

        public void AddMass(float mass)
		{
			this.mass += mass;
			if (this.mass >= mass_treshold)
			{
				overload = true;

				foreach (Entity entity in Level.instance.Entities)
				{
					entity.StartOverload();
					EmitSignal(SignalName.OnOverflow);
				}
			}
			else if (overload == true)
			{
                foreach (Entity entity in Level.instance.Entities)
                {
                    entity.StopOverload();
                    EmitSignal(SignalName.OnOverflowEnd);

                }

                overload = false;
            }
		}
	}
}