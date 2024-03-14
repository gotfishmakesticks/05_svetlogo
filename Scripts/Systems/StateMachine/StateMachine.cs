using Godot;
using Godot.Collections;

namespace _svetlogo.Systems.StateMachine;

[GlobalClass]
public partial class StateMachine : Node
{
    private readonly Dictionary<string, Variant> EMPTY_DICT = new();

    [Export] private State current_state;
    private Dictionary<string,State> states;

    [Signal] public delegate void TransitionedEventHandler(State to_state);

    public override void _Ready()
    {
        foreach (var child in GetChildren())
        {
            if (child is State state) 
            {
                states.Add(state.Name, state);
            }
        }

        current_state.EnterTree(EMPTY_DICT);
    }

    public override void _Process(double delta)
    {
        current_state.Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        current_state._PhysicsProcess(delta);
    }

    public void Transit(string to, Dictionary<string, Variant> message)
    {
        GD.PushError(states.ContainsKey(to));

        current_state.ExitTree();

        current_state = states[to];
        current_state.EnterTree(message);

        EmitSignal(SignalName.Transitioned);
    }

    public void SendInput(Dictionary<string, Variant> message)
    {
        current_state.Input(message);
    }

    public void SendInputAll(Dictionary<string, Variant> message)
    {
        foreach (var state in states.Values)
        {
            state.Input(message);
        }
    }

}
