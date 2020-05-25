using System;
using System.Collections.Generic;
using System.Linq;
using GameCanvas;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallGenerator : ISdpGameObject {
    private List<Ball> Balls { get; set; }
    public Proxy gc { get; set; }
    public Vector2Int ScreenSize;

    public BallGenerator(Proxy gc, Vector2Int screenSize) {
        Balls = new List<Ball>();
        this.gc = gc;
        this.ScreenSize = screenSize;
    }

    public void AddBall(BallColor ballColor) {
        Ball.displaySize = ScreenSize;
        Balls.Add(
            new Ball(
                gc, 
                ballColor,
                new Vector2Int((int) (Random.value * ScreenSize.x), 0),
                new Vector2Int(5,   5)
                )
        );
    }

    public void DrawOwn(Action callback = null) => Balls.ToList().ForEach(ball => ball.DrawOwn());


    public void UpdateOwn() {
        Balls.ToList().ForEach(ball => ball.UpdateOwn());
        Balls.RemoveAll(ball => !ball.IsActive);
        Debug.Log(Balls.Count.ToString());
    }
}