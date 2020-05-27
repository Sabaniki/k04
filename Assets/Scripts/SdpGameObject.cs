using System;
using GameCanvas;
using UnityEngine;

public abstract class SdpGameObject {
    protected Proxy gc { get; }
    protected static Vector2Int ScreenSize = new Vector2Int(720, 1280);

    private SdpGameObject(Proxy gc, Vector2Int screenSize) {
        this.gc = gc;
        ScreenSize = screenSize;
    }

    protected SdpGameObject(Proxy gc) {
        this.gc = gc;
    }

    public virtual void Draw() {
    }

    public virtual void Update() {
    }
}
