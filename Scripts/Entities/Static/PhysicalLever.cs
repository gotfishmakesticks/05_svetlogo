using Godot;

namespace _svetlogo.Entities.Static;
public partial class PhysicalLever : Area2D
{
	[Export] private Texture2D activatedTexture;
	[Export] private Texture2D deactivatedTexture;
	[Export] private Sprite2D sprite;

	public bool Activated {  get; private set; }
	private int bodyCount = 0;

	[Signal] public delegate void LeverToggledEventHandler();
	[Signal] public delegate void LeverPressedEventHandler();
	[Signal] public delegate void LeverUnpressedEventHandler();

    public void OnBodyEntered(Node body)
	{
		if (body is RigidBody2D)
		{
			
			if (Activated)
			{
                if (bodyCount == 0)
                {
                    EmitSignal(SignalName.LeverUnpressed);
                    EmitSignal(SignalName.LeverToggled);
                    sprite.Texture = activatedTexture;
					Activated = false;
                }
            }
			else
			{
				if (bodyCount == 0)
				{
					EmitSignal(SignalName.LeverPressed);
					EmitSignal(SignalName.LeverToggled);
                    sprite.Texture = deactivatedTexture;
					Activated = true;
				}
			}
            bodyCount++;
        }
	}
	public void OnBodyExited(Node body)
	{
		if (body is RigidBody2D)
		{
			bodyCount--;

        }
	}
}
