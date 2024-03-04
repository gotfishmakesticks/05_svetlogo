using Godot;
using _svetlogo.Entities;

namespace _svetlogo.Systems
{
	public partial class Overload : Node
	{
		[Export] private float max_mass;
		private float mass;

		private bool overload = false;

		public void AddMass(float mass)
		{
			this.mass += mass;
			if (this.mass >= max_mass)
			{
				overload = true;

				foreach (Entity entity in Level.instance.Entities)
				{
					entity.StartOverload();
				}
			}
			else if (overload == true)
			{
                foreach (Entity entity in Level.instance.Entities)
                {
                    entity.StopOverload();
                }

				overload = false;
            }
		}
	}
}