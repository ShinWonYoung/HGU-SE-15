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

    public static int total_score;   // 점수

    private static STEP curr_step = STEP.PLAY;

    private static float step_timer = 0.0f; // 경과시간

    private Text _scoreText;

    void Start() {
        curr_step = STEP.PLAY; // 상태를 실행중으로

        initializeScore();

        _scoreText = GetComponentInChildren<Text>();

        _scoreText.fontSize = (int)(_scoreText.fontSize * ((Screen.width) / 1236f));

    }

    public static void initializeScore()
    {
        total_score = 0;
        step_timer = 0.0f;
    }

    //  Mathf.CeilToInt(this.step_timer) + ,last.total_score
    void Update() {
        step_timer += Time.deltaTime; // 시간 증가

        if( curr_step == STEP.PLAY)
        {
            _scoreText.text = "" + (Mathf.CeilToInt(step_timer*7) + total_score);
        }
        else // FINISH인거
        {
            HighScoreManager.GameOver(Mathf.CeilToInt(step_timer*7) + total_score);
        }

    }

    public static int getScore()
    {
        return (Mathf.CeilToInt(step_timer * 7) + total_score);
    }

    public static void addHeart() { // 하트 먹을 때마다 카운트
        total_score += 50;
    }

    public static void addDia() { // 다이아몬드 먹을 때마다 카운트
        total_score += 100;
    }

    public static void GameOver()
    {
        curr_step = STEP.FINISH;
    }

}