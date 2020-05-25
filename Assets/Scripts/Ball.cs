using System;
using GameCanvas;
using UnityEngine;

public class Ball : ISdpGameObject {
    public Proxy gc { get; set; }
    public Vector2Int Position;
    public Vector2 Speed;
    public BallColor Color { get; private set; }
    public readonly int radios;
    public static Vector2Int displaySize;
    public bool IsActive { get; set; }

    public Ball(Proxy gc, BallColor ballColor, Vector2Int position, Vector2 speed) {
        this.gc = gc;
        Position = position;
        Speed = speed;
        Color = ballColor;
        radios = 24;
        IsActive = true;
    }

    public void DrawOwn(Action callback = null) {
        gc.DrawImage((int)Color, Position.x, Position.y);
    }

    public void UpdateOwn() {
        Position.y += (int)Speed.y;
        IsActive = Position.y < displaySize.y;
    }
}