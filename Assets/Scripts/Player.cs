using System;
using GameCanvas;
using UnityEngine;

public class Player: ISdpGameObject {
    public Proxy gc { get; set; }
    public static Vector2Int ScreenSize;
    public Vector2Int Position;
    public Vector2Int Size;
    public Vector2Int Speed;
    private PlayerDirection direction;
    public Player(Proxy gc) {
        this.gc = gc;
        Size = new Vector2Int(32, 32);
        Position = new Vector2Int(ScreenSize.x / 2, ScreenSize.y - Size.y);
        Speed = new Vector2Int(3, 3);
    }

    public void DrawOwn(Action callback = null) {
        gc.DrawClipImage((int)direction, Position.x, Position.y, 0, 64, Size.x, Size.y);
    }

    public void UpdateOwn() {
        if (gc.GetPointerFrameCount(0) <= 0) return;
        if (gc.GetPointerX(0) > ScreenSize.x / 2) {
            Position.x += Speed.x;
            direction = PlayerDirection.RIGHT;
        }
        else {
            Position.x -= Speed.x;
            direction = PlayerDirection.LEFT;
        }
    }
}