using UnityEngine;
using System.Collections;

public class LocalHighScore {

    private int maxUserNum = 5;
    private int minScore;
    private UsersData[] userHighScoresData;  // only those for high score

    private static volatile LocalHighScore instance;

    private LocalHighScore() {

        LoadGameLocal();
    }

    public static LocalHighScore getInstance()
    {
        if (instance == null)
        {
            instance = new LocalHighScore();
        }
        return instance;
    }

    public void setMaxUser(int maxUserNum)
    {
        this.maxUserNum = maxUserNum;
        LoadGameLocal();
    }

    public int getMinScore()
    {
        LoadGameLocal();
        return minScore;
    }

    public string getPlayerNames()
    {
        string playerNameString = "";

        for(int i = 0; i < maxUserNum; i++)
        {
            playerNameString += userHighScoresData[i].GetName();
            playerNameString += (i == maxUserNum - 1) ? "" : "\n\n";
        }

        return playerNameString;
    }

    public string getPlayerScores()
    {
        string playerScoresString = "";

        for (int i = 0; i < maxUserNum; i++)
        {
            playerScoresString += userHighScoresData[i].GetScore();
            playerScoresString += (i == maxUserNum - 1) ? "" : "\n\n";
        }

        return playerScoresString;
    }

    public void LoadGameLocal()
    {
        userHighScoresData = new UsersData[maxUserNum];

        int[] scores = new int[maxUserNum];
        for(int i  = 0; i < maxUserNum; i++)
        {
            UsersData user = new UsersData();
            user.LoadLocal(i);
            userHighScoresData[i] = user;
            scores[i] = userHighScoresData[i].GetScore();
        }

        minScore = Mathf.Min(scores);
    }
    
    public void SaveGame(int score)
    {
        LoadGameLocal();
        ArrayList newData;
        if (score >= minScore)
        {
            newData = new ArrayList(userHighScoresData);

            //추가할 new UsersData
            UsersData obj_user = new UsersData();
            obj_user.Init(UsersData.DEFAULT_NAME, score);

            // Add to newData Array List
            newData.Add(obj_user);

            // Sort Users By Scores
            newData.Sort(new ScoreComparer());

            // UserScoresData = newData 형식에 맞게
            userHighScoresData = newData.ToArray(typeof(UsersData)) as UsersData[];

        }

        for(int i = 0; i < maxUserNum; i++)  // PlayerPrefs 값들이 계속 바뀌는 거.
        {
            Debug.Log("name: " + userHighScoresData[i].GetName() + " score:" + userHighScoresData[i].GetScore());
            if(userHighScoresData[i].GetScore() >= 0) userHighScoresData[i].SaveLocal(i);
        }

    }

    public void SaveGame(string name)
    {
        for(int i = 0; i < maxUserNum; i++)
        {
            if(userHighScoresData[i].GetName() == UsersData.DEFAULT_NAME)
            {
                userHighScoresData[i].SetName(name);
                userHighScoresData[i].SaveLocal(i);
            }
        }
    }

    public class ScoreComparer : IComparer
    {
        Comparer _comparer = new Comparer(System.Globalization.CultureInfo.CurrentCulture);

        public int Compare(object p1, object p2)
        {
            UsersData u1 = (UsersData) p1;
            UsersData u2 = (UsersData) p2;
            return _comparer.Compare(u2.GetScore(), u1.GetScore());
        }
    }

}
