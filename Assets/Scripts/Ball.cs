using System;
using GameCanvas;
using UnityEngine;

public class Ball : ISdpGameObject {
    public Proxy gc { get; set; }
    public Vector2Int Position;
    public Vector2Int Speed;
    private int imageId;
    private readonly int radios;
    public static Vector2Int displaySize;
    public bool IsActive { get; private set; }

    public Ball(Proxy gc, BallColor ballColor, Vector2Int position, Vector2Int speed) {
        this.gc = gc;
        Position = position;
        Speed = speed;
        imageId = (int) ballColor;
        radios = 24;
        IsActive = true;
        
        //displaySize = new Vector2Int(480, 640);
    }

    public void DrawOwn(Action callback = null) {
        gc.DrawImage(imageId, Position.x, Position.y);
    }

    public void UpdateOwn() {
        Debug.Log("position: " + Position.ToString());
        Position.y += Speed.y;
        IsActive = Position.y < displaySize.y;
    }
}