using _svetlogo.Entities.Animate;
using Godot;
using Godot.Collections;

namespace _svetlogo.Entities.Static;
public partial class Portal : Area2D
{
	[Export] private Array<PortalCondition> conditions;
	[Export] private PackedScene scene_to_switch;

	public void Teleport(Node2D body)
	{
		if (body is PlayerMovement == false) return;

		SceneTree tree = GetTree();

		foreach (PortalCondition condition in conditions)
		{
			if (condition.CheckCondition(tree,this) == false)
			{
				GD.Print("Condition is false");
				return;
			}
		}
        GD.Print("Condition is true");
        tree.ChangeSceneToPacked(scene_to_switch);
	}

	public void Trigger(string trigger)
	{
		foreach (PortalCondition condition in conditions)
		{
			if (condition is TriggerCondition triggerCondition)
			{
				triggerCondition.AddTrigger(trigger);
			}
		}
	}
}
