using System;
using System.Collections.Generic;
using System.Globalization;
using GameCanvas;

public class Counter : ISdpGameObject {
    public Proxy gc { get; set; }
    private int point;
    private readonly float limitTime;
    private float currentTime;
    private float TimeRemaining => limitTime - currentTime;
    public bool IsGameFinished => TimeRemaining < 0;

    public Counter(Proxy gc, int limitTime) {
        this.gc = gc;
        point = 0;
        this.limitTime = limitTime;
        currentTime = gc.TimeSinceStartup;
    }

    public void DrawOwn(Action callback = null) {
        gc.DrawString(
            TimeRemaining > 0 ? $"time: {TimeRemaining.ToString(CultureInfo.InvariantCulture)}\n" 
                : "finished!!", 0, 0
            );
        gc.DrawString($"point: {point.ToString()}", 0, 24);
    }

    public void UpdateOwn() {
        currentTime = gc.TimeSinceStartup;
    }

    public void AddPoint(Ball ball) {
        if (TimeRemaining < 0) return;
        point += (int) ball.Color;
    }
}