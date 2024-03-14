using Godot;
using Godot.Collections;

namespace _svetlogo.Systems.StateMachine;

[GlobalClass]
public abstract partial class State : Node
{
    public abstract void RecieveMessage(Dictionary<string, Variant> messages);
}
