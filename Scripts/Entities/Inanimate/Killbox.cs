using _svetlogo.Entities;
using Godot;
using System;

public partial class Killbox : Area2D
{
	public void OnKillboxBodyEntered(Node2D _body)
	{
		if (_body is Entity)
		{
			GetParent().QueueFree();
		}
	}
}
