using Godot;
using System;

public partial class Killbox : Area2D
{
	public void OnKillboxBodyEntered(Node2D _body)
	{
		GetParent().QueueFree();
	}
}
