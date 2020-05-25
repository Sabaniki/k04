using System.Linq;
using UnityEngine;
using Sequence = System.Collections.IEnumerator;

/// <summary>
/// ゲームクラス。
/// 学生が編集すべきソースコードです。
/// </summary>
public sealed class Game : GameBase {
    // 変数の宣言
    int sec = 0;
    private Vector2Int screenSize;
    private BallManager ballManager;
    private Player player;
    private Counter counter;

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void InitGame() {
        screenSize = new Vector2Int(720, 1280);
        // キャンバスの大きさを設定します
        gc.SetResolution(screenSize.x, screenSize.y);
        Player.ScreenSize = screenSize;
        ballManager = new BallManager(gc, screenSize);
        for (var i = 0; i < 30; i++) ballManager.AddBall(BallColor.RANDOM);
        player = new Player(gc);
        counter = new Counter(gc, 1800);
    }


    /// <summary>
    /// 動きなどの更新処理
    /// </summary>
    public override void UpdateGame() {
        // 起動からの経過時間を取得します
        counter.UpdateOwn();
        player.UpdateOwn();
        ballManager.UpdateOwn();
        ballManager.Balls.ToList().ForEach(ball => {
            if (ball.IsActive && player.CheckHitBall(ball)) {
                counter.AddPoint(ball);
                ball.Position.y = screenSize.y + player.Size.y;
            }
        });
    }

    /// <summary>
    /// 描画の処理
    /// </summary>
    public override void DrawGame() {
        // 画面を白で塗りつぶします
        gc.ClearScreen();

        ballManager.DrawOwn();
        player.DrawOwn();
        counter.DrawOwn();

        //gc.DrawRightString($"{sec}s", 630, 10);
    }
}