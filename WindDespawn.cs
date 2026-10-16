using Godot;
using System;

public partial class WindDespawn : Node2D
{
    public void _on_area_2d_area_entered(Area2D body)
    {
        
        if (body is Wind)
        {
            var wind = body.GetParent();
            wind.QueueFree();
        }
        
    }
    
}
