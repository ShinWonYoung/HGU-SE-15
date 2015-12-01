using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public enum STEP
    {
        PLAY = 0,
        FINISH,
    };

    public struct Count // 점수 관리용 구조체
    {
        public int heart;   // 하트
        public int dia;     // 다이아몬드
        public int total_score;   // 점수
    };

    private static STEP curr_step = STEP.PLAY;

    private static float step_timer = 0.0f; // 경과시간
    public static Count last;  // 이번점수

    private Text _scoreText;

    void Start() {
        curr_step = STEP.PLAY; // 상태를 실행중으로

        last.heart = 0;
        last.dia = 0;
        last.total_score = 0;

        _scoreText = GetComponentInChildren<Text>();

        _scoreText.fontSize = (int)(_scoreText.fontSize * ((Screen.width) / 1236f));

    }

    //  Mathf.CeilToInt(this.step_timer) + ,last.total_score
    void Update() {
        step_timer += Time.deltaTime; // 시간 증가

        if( curr_step == STEP.PLAY)
        {
            _scoreText.text = "" + (Mathf.CeilToInt(step_timer*7) + last.total_score);
        }
        else // FINISH인거
        {
            HighScoreManager.GameOver(Mathf.CeilToInt(step_timer*7) + last.total_score);
        }

    }

    public static int getScore()
    {
        return (Mathf.CeilToInt(step_timer * 7) + last.total_score);
    }

    public static void addHeart() { // 하트 먹을 때마다 카운트
        last.total_score += 200;
    }

    public static void addDia() { // 다이아몬드 먹을 때마다 카운트
        last.total_score += 400;
    }

    public static void GameOver()
    {
        curr_step = STEP.FINISH;
    }

}