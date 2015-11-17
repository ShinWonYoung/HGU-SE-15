using UnityEngine;
using System.Collections;

public class HighScoreManager : UIBaseClass {
    
    public static string userName = "Play1";
    public static int maxNumOfUsers = 5;
    public static int minScore = 0;

    private string finishLevel = "3 FinishScene";
    private string highScoreLevel = "3 HighScore";
    
    private LocalHighScore obj_localHighScore;

    
    // Use this for initialization
    void Start () {
        obj_localHighScore = new LocalHighScore();
        obj_localHighScore.setMaxUser(maxNumOfUsers);
        minScore = obj_localHighScore.getMinScore();
    }

    void GameOver(int score) //gameover 됐을 때 불러올 것! 어디에 둴지는 몰겟다... minScore를 static으로 넣거나...
    {
        string levelName = (score > minScore) ? highScoreLevel : finishLevel;
        Application.LoadLevel(levelName);
    }

    // 만약 첫화면에서, 그리고 마지막에서 high score 보고 싶을 떄 - Load 하면 되고. 그걸 string화 시켜서 text에 넣는거
    void LoadScores()
    {


    }


    // high score 화면에서
    void LoadHighScores()
    {
        //거의 LoadScores()이랑 비슷한데, 자기 점수가 어딘지 알아야 되자나.... 그리고 load해.
    }


    // high score 화면에서 button을 눌렀을 경우에는 StartGame() 불러와.
    void SubmitScore()
    {
        // get the text for player name

        //obj_localHighScore.SaveGame(score, name);

        StartGame();

    }
    
   
}