using Godot;
using System;

public partial class PlayerData : Node
{
    [Export]
    public float HP { get; private set; }
    
    public void DealDamage(float damage)
    {
        HP -= damage;

        if (HP < 0)
        {
            GetParent().QueueFree();
        }
    }
}
