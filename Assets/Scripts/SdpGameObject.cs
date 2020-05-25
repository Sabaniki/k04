using System;
using GameCanvas;

public interface ISdpGameObject {
    Proxy gc { get; set; }
    void DrawOwn(Action callback = null);
    void UpdateOwn();
}