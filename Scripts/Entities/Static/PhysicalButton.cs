using Godot;

namespace _svetlogo.Entities.Static;
public partial class PhysicalButton : Area2D, IButtonActivated
{
	[Export] private Texture2D activatedTexture;
	[Export] private Texture2D deactivatedTexture;
	[Export] private Sprite2D sprite;

	public bool Activated => bodyCount != 0;
	private int bodyCount = 0;

	[Signal] public delegate void ButtonPressedEventHandler();
	[Signal] public delegate void ButtonUnpressedEventHandler();

    public void OnBodyEntered(Node body)
	{
		if (body is RigidBody2D)
		{
			if (bodyCount++ == 0)
			{
				EmitSignal(SignalName.ButtonPressed);
				sprite.Texture = deactivatedTexture;
			}
		}
	}
	public void OnBodyExited(Node body)
	{
        if (body is RigidBody2D)
		{
			if (--bodyCount == 0)
			{
				EmitSignal(SignalName.ButtonUnpressed);
                sprite.Texture = activatedTexture;
            }
        }
	}
}
