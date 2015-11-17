using UnityEngine;
using System.Collections;

public class LocalHighScore {

    private int maxUserNum;
    private int minScore;
    private UsersData[] userHighScoresData;  // only those for high score

    public void setMaxUser(int maxUserNum)
    {
        this.maxUserNum = maxUserNum;
        LoadGameLocal();
    }

    public int getMinScore()
    {
        return minScore;
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
    
    public void SaveGame(int score, string name)
    {
        if(score >= minScore)
        {
            ArrayList newData = new ArrayList(userHighScoresData);

            //remove last UsersData, newData.RemoveAt()

            //추가할 new UsersData
            UsersData obj_user = new UsersData();
            obj_user.Init(name, score);

            //add to newData Array List

            //userScoresData = newData 형식에 맞게

            //SortUsers(users_);
        }

        for(int i = 0; i < maxUserNum; i++)  // PlayerPrefs 값들이 계속 바뀌는 거.
        {
            userHighScoresData[i].SaveLocal(i);
        }

    }

    private void SortUser()
    {

    }

}
