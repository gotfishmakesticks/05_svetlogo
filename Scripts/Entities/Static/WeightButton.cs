using Godot;

namespace _svetlogo.Entities.Static;
public partial class WeightButton : Node2D
{
    [Export] private Texture2D activatedTexture;
    [Export] private Texture2D deactivatedTexture;
    [Export] private Sprite2D sprite;
    [Export] private float massTreshold;

    private int bodyCount = 0;
    private bool state = false;
    private float gravityForce = (float)ProjectSettings.GetSetting("physics/2d/default_gravity");

    [Signal] public delegate void ButtonPressedEventHandler();
    [Signal] public delegate void ButtonUnpressedEventHandler();
    [Signal] public delegate void ThresholdReachedEventHandler();
    [Signal] public delegate void WeightUpdateEventHandler(float Weight);

    private void ToggleState(bool _state)
    {
        if (_state == state) return;
        state = _state;
        if (state)
        {
            EmitSignal(SignalName.ButtonPressed);
            sprite.Texture = deactivatedTexture;
        }
        else
        {
            EmitSignal(SignalName.ButtonUnpressed);
            sprite.Texture = activatedTexture;
        }
    }
}
