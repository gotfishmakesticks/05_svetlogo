using Godot;
using System;

namespace _svetlogo.Entities.Static;

[GlobalClass]
public abstract partial class PortalCondition : Resource
{
    public abstract bool CheckCondition(SceneTree tree);
}
