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

    public static int total_score;   // ����

    private static STEP curr_step = STEP.PLAY;

    private static float step_timer = 0.0f; // ����ð�

    private Text _scoreText;

    void Start() {
        curr_step = STEP.PLAY; // ���¸� ����������

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
        step_timer += Time.deltaTime; // �ð� ����

        if( curr_step == STEP.PLAY)
        {
            _scoreText.text = "" + (Mathf.CeilToInt(step_timer*7) + total_score);
        }
        else // FINISH�ΰ�
        {
            HighScoreManager.GameOver(Mathf.CeilToInt(step_timer*7) + total_score);
        }

    }

    public static int getScore()
    {
        return (Mathf.CeilToInt(step_timer * 7) + total_score);
    }

    public static void addHeart() { // ��Ʈ ���� ������ ī��Ʈ
        total_score += 50;
    }

    public static void addDia() { // ���̾Ƹ�� ���� ������ ī��Ʈ
        total_score += 100;
    }

    public static void GameOver()
    {
        curr_step = STEP.FINISH;
    }

}