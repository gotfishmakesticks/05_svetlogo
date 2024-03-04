using _svetlogo.Entities;
using Godot;
using System.Collections.Generic;

namespace _svetlogo.Systems
{
    public partial class Level : Node2D
    {
        public static Level instance;

        public Overload Overload { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();

        public override void _EnterTree()
        {
            instance = this;
        }

        public override void _Ready()
        {
            Overload = GetNode<Overload>("Overload");
            
        }

        public override void _ExitTree()
        {
            instance = null;
        }
    }
}