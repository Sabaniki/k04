using System;
using System.Collections.Generic;
using System.Linq;
using GameCanvas;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallManager : SdpGameObject {
    public List<Ball> Balls { get; }
    public bool CanGenerateBalls;

    public BallManager(Proxy gc): base(gc) {
        Balls = new List<Ball>();
        CanGenerateBalls = true;
    }

    public void AddBall(BallColor ballColor) {
        if(ballColor == BallColor.Random) ballColor = (BallColor) Enum.ToObject(typeof(BallColor), (int) (Random.value * 2 + 1.5));
        Balls.Add(
            new Ball(
                gc, 
                ballColor,
                new Vector2Int((int) (Random.value * ScreenSize.x), (int) (Random.value * 2 * ScreenSize.y) - ScreenSize.y),
                new Vector2(0,   (Random.value * 3) + 3)
                )
        );
    }

    public override void DrawOwn() => Balls.ToList().ForEach(ball => ball.DrawOwn());


    public override void UpdateOwn() {
        var deletedBallNum = 0;
        
        Balls.ToList().ForEach(ball => ball.UpdateOwn());
        Balls.RemoveAll(ball => {
            if (ball.IsActive) return false;
            deletedBallNum++;
            return true;
        });

        if (CanGenerateBalls) for (var i = 0; i < deletedBallNum; i++) AddBall(BallColor.Random);
    }
}