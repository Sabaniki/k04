using System;
using System.Collections.Generic;
using System.Globalization;
using GameCanvas;

public class Counter : SdpGameObject {
    private int point;
    private readonly float limitTime;
    private float currentTime;
    private float TimeRemaining => limitTime - currentTime;
    public bool IsGameFinished => TimeRemaining < 0;
    
    private BallColor beforeHitBallColor;
    private int numOfConsecutiveCollisions;
    public Counter(Proxy gc, int limitTime): base(gc) {
        point = 0;
        this.limitTime = limitTime;
        currentTime = gc.TimeSinceStartup;
        beforeHitBallColor = BallColor.Random;
        numOfConsecutiveCollisions = 1;
    }

    public override void Draw() {
        gc.DrawString(
            TimeRemaining > 0 ? $"time: {TimeRemaining.ToString(CultureInfo.InvariantCulture)}\n" 
                : "finished!!", 0, 0
            );
        gc.DrawString($"point: {point.ToString()}\ncombo: {(numOfConsecutiveCollisions - 1).ToString()}", 0, 24);
    }

    public override void Update() {
        currentTime = gc.TimeSinceStartup;
    }

    public void AddPoint(Ball ball) {
        if (TimeRemaining < 0) return;
        
        if (ball.Color == beforeHitBallColor) numOfConsecutiveCollisions++;
        else numOfConsecutiveCollisions = 1;
        beforeHitBallColor = ball.Color;
        
        point += (int) ball.Color * numOfConsecutiveCollisions;
    }
}