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

    public void EnterTree()
    {
        foreach (var child in GetChildren())
        {
            if (child is State state) 
            {
                states.Add(state.Name, state);
            }
        }

        if (current_state is IStateEnter stateEnter)
            stateEnter.EnterTree(EMPTY_DICT);
    }

    public override void _Process(double delta)
    {
        if (current_state is IStateProcess stateProcess)
            stateProcess.Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (current_state is IStatePhysicsProcess statePhysics)
            statePhysics.PhysicsProcess(delta);
    }

    public void Transit(string to, Dictionary<string, Variant> message)
    {
        GD.PushError(states.ContainsKey(to));

        if (current_state is IStateExit stateExit)
            stateExit.ExitTree();

        current_state = states[to];
        if (current_state is IStateEnter stateEnter)
            stateEnter.EnterTree(message);

        EmitSignal(SignalName.Transitioned);
    }

    public void SendMessage(Dictionary<string, Variant> message)
    {
        current_state.RecieveMessage(message);
    }

    public void SendMessageAll(Dictionary<string, Variant> message)
    {
        foreach (var state in states.Values)
        {
            state.RecieveMessage(message);
        }
    }

}
