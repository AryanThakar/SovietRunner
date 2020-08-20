using Godot;
using System;

public class Player : KinematicBody2D {
    [Export]

    public int speed = 250;

    public override void _PhysicsProcess(float delta) {

        var motion = new Vector2();
        
        Vector2 textureSize = GetNode<Texture>("Sprite").GetSize();
        Vector2 screenSize = GetViewport().GetVisibleRect().Size;
               
        motion.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        motion.y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
        
        if (Position.x + motion.x < 0 || Position.x + motion.x + textureSize.x > screenSize.x) {
            motion.x = 0;
        } if (Position.y + motion.y < 0 || Position.y + motion.y + textureSize.y > screenSize.y) {
            motion.y = 0;
        } 
        
        MoveAndCollide(motion.Normalized() * speed * delta);

        
    }

}
