using _svetlogo.Abilities;
using _svetlogo.Systems;
using Godot;
using Godot.Collections;

namespace _svetlogo.Entities
{
    public partial class Entity : RigidBody2D
    {
        [Export] private Array<Ability> abilities = new Array<Ability>();
        private bool overloaded = false;

        [Export] public bool massInverted = false;

        [Export] public int health = 1;
        [Signal]
        public delegate void DeathSignalEventHandler();

        public override void _Ready()
        {
            Level.instance.Entities.Add(this);
            foreach (var ability in abilities)
            {
                ability.OnReady(this);
            }
            if (massInverted)
                Level.instance.Overload.AddMass(-Mass);
            else
                Level.instance.Overload.AddMass(Mass);
        }
        public override void _ExitTree()
        {
            if (massInverted)
                Level.instance.Overload.AddMass(Mass);
            else
                Level.instance.Overload.AddMass(-Mass);
            if (overloaded)
            {
                StopOverload();
            }
            Level.instance.Entities.Remove(this);
            EmitSignal(SignalName.DeathSignal);
        }
        public void StartOverload()
        {
            overloaded = true;
            foreach (var ability in abilities)
            {
                ability.StartAbility(this);
            }
        }
        public override void _Process(double delta)
        {
            if (overloaded)
            {
                foreach (var ability in abilities)
                {
                    ability.ProcessAbility(this);
                }
            }
        }
        public void StopOverload()
        {
            overloaded = false;
            foreach (var ability in abilities)
            {
                ability.StopAbility(this);
            }
        }

        public void AddMass(float mass)
        {
            UpdateMass(Mass + mass);
        }
        
        public void UpdateMass(float to)
        {
            float difference = to - Mass;
            if (massInverted)
                difference = -difference;
            Level.instance.Overload.AddMass(difference);

            Mass = to;
        }

    }
}
