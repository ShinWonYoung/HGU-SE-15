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

    public struct Count // ���� ������ ����ü
    {
        public int heart;   // ��Ʈ
        public int dia;     // ���̾Ƹ��
        public int total_score;   // ����
    };

    private static STEP curr_step = STEP.PLAY;

    private static float step_timer = 0.0f; // ����ð�
    public static Count last;  // �̹�����

    private Text _scoreText;

    void Start() {
        curr_step = STEP.PLAY; // ���¸� ����������

        last.heart = 0;
        last.dia = 0;
        last.total_score = 0;

        _scoreText = GetComponentInChildren<Text>();

        _scoreText.fontSize = (int)(_scoreText.fontSize * ((Screen.width) / 1236f));

    }

    //  Mathf.CeilToInt(this.step_timer) + ,last.total_score
    void Update() {
        step_timer += Time.deltaTime; // �ð� ����

        if( curr_step == STEP.PLAY)
        {
            _scoreText.text = "" + (Mathf.CeilToInt(step_timer*7) + last.total_score);
        }
        else // FINISH�ΰ�
        {
            HighScoreManager.GameOver(Mathf.CeilToInt(step_timer*7) + last.total_score);
        }

    }

    public static int getScore()
    {
        return (Mathf.CeilToInt(step_timer * 7) + last.total_score);
    }

    public static void addHeart() { // ��Ʈ ���� ������ ī��Ʈ
        last.total_score += 200;
    }

    public static void addDia() { // ���̾Ƹ�� ���� ������ ī��Ʈ
        last.total_score += 400;
    }

    public static void GameOver()
    {
        curr_step = STEP.FINISH;
    }

}