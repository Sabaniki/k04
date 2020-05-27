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
        ballManager = new BallManager(gc);
        for (var i = 0; i < 30; i++) ballManager.AddBall(BallColor.Random);
        player = new Player(gc);
        counter = new Counter(gc, 30);
    }

    public override void UpdateGame() {
        counter.Update();
        player.Update();
        ballManager.CanGenerateBalls = !counter.IsGameFinished;
        ballManager.Update();
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

        ballManager.Draw();
        player.Draw();
        counter.Draw();

    }
}