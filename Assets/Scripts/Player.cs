using System;
using GameCanvas;
using UnityEngine;

public class Player: ISdpGameObject {
    public Proxy gc { get; set; }
    public static Vector2Int ScreenSize;
    private Vector2Int position;
    public Vector2Int Size;
    private Vector2Int speed;
    private PlayerDirection direction;
    public Player(Proxy gc) {
        this.gc = gc;
        Size = new Vector2Int(32, 32);
        position = new Vector2Int(ScreenSize.x / 2, ScreenSize.y - Size.y);
        speed = new Vector2Int(3, 3);
    }

    public void DrawOwn(Action callback = null) {
        gc.DrawClipImage((int)direction, position.x, position.y, 0, 64, Size.x, Size.y);
    }

    public bool CheckHitBall(Ball ball) {
        var isHit = gc.CheckHitRect(
            ball.Position.x, ball.Position.y, ball.radios, ball.radios,
            position.x, position.y, Size.x, Size.y
        );
        if (isHit) {
            ball.IsActive = false;
        }

        return isHit;
    }

    public void UpdateOwn() {
        if (gc.GetPointerFrameCount(0) <= 0) return;
        if (gc.GetPointerX(0) > ScreenSize.x / 2) {
            position.x += speed.x;
            direction = PlayerDirection.RIGHT;
        }
        else {
            position.x -= speed.x;
            direction = PlayerDirection.LEFT;
        }
    }
}