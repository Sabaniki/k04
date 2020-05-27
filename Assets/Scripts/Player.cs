using System;
using GameCanvas;
using UnityEngine;

public class Player : MovingSdpGameObject {
    private PlayerDirection direction;

    public Player(Proxy gc) :
        base(
            gc,
            new Vector2Int(32, 32),
            new Vector2Int( ScreenSize.x / 2, ScreenSize.y - 32), 
            new Vector2Int(3, 3)
        ) {
    }

    public override void Draw() {
        gc.DrawClipImage((int) direction, Position.x, Position.y, 0, 64, Size.x, Size.y);
    }

    public bool CheckHitBall(Ball ball) {
        var isHit = gc.CheckHitRect(
            ball.Position.x, ball.Position.y, ball.Size.x, ball.Size.y,
            Position.x, Position.y, Size.x, Size.y
        );
        if (isHit) ball.IsActive = false;
        return isHit;
    }

    public override void Update() {
        if (gc.GetPointerFrameCount(0) <= 0) return;
        if (gc.GetPointerX(0) > ScreenSize.x / 2 && Position.x < ScreenSize.x - Size.x) {
            Position.x += (int)Speed.x;
            direction = PlayerDirection.Right;
        }
        else if (0 < Position.x) {
            Position.x -= (int)Speed.x;
            direction = PlayerDirection.Left;
        }
    }
}