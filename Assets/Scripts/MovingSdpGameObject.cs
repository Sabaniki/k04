using GameCanvas;
using UnityEngine;


public abstract class MovingSdpGameObject: SdpGameObject {
    public Vector2Int Position;
    public Vector2 Speed;
    public Vector2Int Size;

    protected MovingSdpGameObject(Proxy gc, Vector2Int size, Vector2Int position, Vector2 speed) : base(gc) {
        Size = size;
        Position = position;
        Speed = speed;
    }
}