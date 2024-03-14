using Godot;
using Godot.Collections;

namespace _svetlogo.Systems.StateMachine;
public interface IStateEnter
{
    public void EnterTree(Dictionary<string, Variant> messages);
}
