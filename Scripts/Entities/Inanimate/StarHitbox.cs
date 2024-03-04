using _svetlogo.Entities.Animate;
using Godot;

public partial class StarHitbox : Area2D
{
    public bool activated = false;
    [Export] float damage = 1;

    public void OnBodyEntered(Node2D body)
    {
        if (body is PlayerMovement player)
        {
            player.PlayerData.DealDamage(damage);
        }
    }
}
