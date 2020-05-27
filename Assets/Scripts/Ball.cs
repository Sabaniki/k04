using System;
using GameCanvas;
using UnityEngine;

public class Ball : MovingSdpGameObject {
    public BallColor Color { get; }
    public bool IsActive { get; set; }

    public Ball(Proxy gc, BallColor ballColor, Vector2Int position, Vector2 speed): 
        base(gc, new Vector2Int(24, 24), position, speed) {
        Position = position;
        Speed = speed;
        Color = ballColor;
        IsActive = true;
    }

    public override void DrawOwn() {
        gc.DrawImage((int)Color, Position.x, Position.y);
    }

    public override void UpdateOwn() {
        Position.y += (int)Speed.y;
        IsActive = Position.y < ScreenSize.y;
    }
}