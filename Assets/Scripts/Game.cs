using System.Linq;
using UnityEngine;
using Sequence = System.Collections.IEnumerator;

public sealed class Game : GameBase {
    private Vector2Int screenSize;
    private BallManager ballManager;
    private Player player;
    private Counter counter;

    public override void InitGame() {
        screenSize = new Vector2Int(720, 1280);
        gc.SetResolution(screenSize.x, screenSize.y);
        Player.ScreenSize = screenSize;
        ballManager = new BallManager(gc, screenSize);
        for (var i = 0; i < 30; i++) ballManager.AddBall(BallColor.RANDOM);
        player = new Player(gc);
        counter = new Counter(gc, 30);
    }

    public override void UpdateGame() {
        counter.UpdateOwn();
        player.UpdateOwn();
        ballManager.CanGenerateBalls = !counter.IsGameFinished;
        ballManager.UpdateOwn();
        ballManager.Balls.ToList().ForEach(ball => {
            
            if (ball.IsActive && player.CheckHitBall(ball)) {
                counter.AddPoint(ball);
                ball.Position.y = screenSize.y + player.Size.y;
            }
        });
        if (gc.GetPointerFrameCount(0) > 120 && counter.IsGameFinished) {
            InitGame();
        }
    }

    public override void DrawGame() {
        gc.ClearScreen();

        ballManager.DrawOwn();
        player.DrawOwn();
        counter.DrawOwn();

    }
}