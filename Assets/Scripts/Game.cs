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
    private BallGenerator ballGenerator;
    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void InitGame() {
        screenSize = new Vector2Int(720, 1280);
        // キャンバスの大きさを設定します
        gc.SetResolution(screenSize.x, screenSize.y);
        ballGenerator = new BallGenerator(gc, screenSize);
        ballGenerator.AddBall(BallColor.RED);
        ballGenerator.AddBall(BallColor.BLUE);
        ballGenerator.AddBall(BallColor.YELLOW);
    }


    /// <summary>
    /// 動きなどの更新処理
    /// </summary>
    public override void UpdateGame() {
        // 起動からの経過時間を取得します
        sec = (int) gc.TimeSinceStartup;
        ballGenerator.UpdateOwn();
        ballGenerator.DrawOwn();
    }

    /// <summary>
    /// 描画の処理
    /// </summary>
    public override void DrawGame() {
        // 画面を白で塗りつぶします
        gc.ClearScreen();

        // 0番の画像を描画します
        gc.DrawImage(0, 0, 0);

        // 黒の文字を描画します
        gc.SetColor(0, 0, 0);
        gc.SetFontSize(48);
        gc.DrawString("この文字と青空の画像が", 40, 160);
        gc.DrawString("見えていれば成功です", 40, 270);
        gc.DrawRightString($"{sec}s", 630, 10);
    }
}