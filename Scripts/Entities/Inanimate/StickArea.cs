using _svetlogo.Entities;
using Godot;
using Godot.Collections;

public partial class StickArea : Area2D
{
	public bool can_stick = false;
	private Array<Entity> inArea;
	private Array<Joint2D> joints;
	public void OnBodyEntered(Node2D body)
	{
		if (body is Entity entity)
		{
			inArea.Add(entity);

			Stick();
		}
	}
	public void OnBodyExited(Node2D body)
	{
        if (body is Entity entity)
        {
			inArea.Remove(entity);
        }
    }
	public void Stick()
	{
		if (can_stick == false) return;

		foreach (Entity entity in inArea)
		{
			PinJoint2D joint2D = new();
			AddChild(joint2D);
			joint2D.NodeA = GetPath();
			joint2D.NodeB = entity.GetPath();

			joints.Add(joint2D);
		}
	}
	
	public void Unstick()
	{
		if(joints.Count == 0) return;

		foreach (var joint in joints)
		{
			joint.QueueFree();
		}

		joints.Clear();
	}
}
