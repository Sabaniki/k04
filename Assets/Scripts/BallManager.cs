using System;
using System.Collections.Generic;
using System.Linq;
using GameCanvas;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallManager : ISdpGameObject {
    public List<Ball> Balls { get; private set; }
    public Proxy gc { get; set; }
    private Vector2Int screenSize;
    public bool CanGenerateBalls;

    public BallManager(Proxy gc, Vector2Int screenSize) {
        Balls = new List<Ball>();
        this.gc = gc;
        this.screenSize = screenSize;
        CanGenerateBalls = true;
    }

    public void AddBall(BallColor ballColor) {
        if(ballColor == BallColor.RANDOM) ballColor = (BallColor) Enum.ToObject(typeof(BallColor), (int) (Random.value * 2 + 1.5));
        Ball.displaySize = screenSize;
        Balls.Add(
            new Ball(
                gc, 
                ballColor,
                new Vector2Int((int) (Random.value * screenSize.x), (int) (Random.value * 2 * screenSize.y) - screenSize.y),
                new Vector2(0,   (Random.value * 3) + 3)
                )
        );
    }

    public void DrawOwn(Action callback = null) => Balls.ToList().ForEach(ball => ball.DrawOwn());


    public void UpdateOwn() {
        var deletedBallNum = 0;
        
        Balls.ToList().ForEach(ball => ball.UpdateOwn());
        Balls.RemoveAll(ball => {
            if (ball.IsActive) return false;
            deletedBallNum++;
            return true;
        });

        if (CanGenerateBalls) for (var i = 0; i < deletedBallNum; i++) AddBall(BallColor.RANDOM);
    }
}