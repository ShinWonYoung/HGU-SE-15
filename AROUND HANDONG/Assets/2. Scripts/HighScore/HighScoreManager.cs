using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreManager : UIBaseClass {
    
    public static string userName = "Play1";
    public static int maxNumOfUsers = 5;
    public static int minScore = 0;

    private string finishLevel = "3 FinishScene";
    private string highScoreLevel = "3 HighScore";
    
    private LocalHighScore obj_localHighScore;

    private Canvas _highScoreCanvas;
    private Text RankPlayerNameText;
    private Text RankScoreText;
    private InputField PlayerNameInputText;

        
    // Use this for initialization
    void Start () {

        _highScoreCanvas = GetComponentInChildren<Canvas>();
        PlayerNameInputText = _highScoreCanvas.GetComponentInChildren<InputField>();

        Text[] texts = _highScoreCanvas.GetComponentsInChildren<Text>();
        foreach(Text t in texts)
        {
            t.fontSize *= (Screen.width) / 1236;

            if(t.name.Contains("Player Name")) RankPlayerNameText = t;
            else if(t.name.Contains("Scores")) RankScoreText = t;
        }

        obj_localHighScore = LocalHighScore.getInstance();
        obj_localHighScore.setMaxUser(maxNumOfUsers);
        minScore = obj_localHighScore.getMinScore();

        LoadScores();
    }

    public void GameOver(int score) //gameover 됐을 때 불러올 것! 어디에 둴지는 몰겟다... minScore를 static으로 넣거나...
    {
        if (score > minScore) obj_localHighScore.SaveGame(score);

        string levelName = (score > minScore) ? highScoreLevel : finishLevel;
        Application.LoadLevel(levelName);
    }

    // 만약 첫화면에서, 그리고 마지막에서 high score 보고 싶을 떄 - Load 하면 되고. 그걸 string화 시켜서 text에 넣는거
    void LoadScores()
    {
        RankPlayerNameText.text = obj_localHighScore.getPlayerNames();
        RankScoreText.text = obj_localHighScore.getPlayerScores();
    }
    
    // high score 화면에서 button을 눌렀을 경우에는 StartGame() 불러와.
    public void SubmitScore()
    {
        // get the text for player name
        string name = PlayerNameInputText.text;
        obj_localHighScore.SaveGame(name);
        
        StartGame();

    }
}