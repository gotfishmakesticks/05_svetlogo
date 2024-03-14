using Godot;
using Godot.Collections;

namespace _svetlogo.Systems.StateMachine;

[GlobalClass]
public abstract partial class State : Node
{
    public abstract void EnterTree(Dictionary<string, Variant> messages);
    public abstract void ExitTree();
    public abstract void Process(double delta);
    public abstract void PhysicsProcess(double delta);
    public abstract void Input(Dictionary<string, Variant> messages);
}
