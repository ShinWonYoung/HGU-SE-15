using UnityEngine;
using System.Collections;

public class LocalHighScore {

    private int maxUserNum;
    private int minScore;
    private UsersData[] userScoresData;

    public void SetMaxUser(int maxUserNum)
    {
        this.maxUserNum = maxUserNum;
        LoadGameLocal();
    }

    public void LoadGameLocal()
    {
        userScoresData = new UsersData[maxUserNum];

        int[] scores = new int[maxUserNum];
        for(int i  = 0; i < maxUserNum; i++)
        {
            UsersData user = new UsersData();
            user.LoadLocal(i);
            userScoresData[i] = user;
            scores[i] = userScoresData[i].GetScore();
        }

        minScore = Mathf.Min(scores);
    }
    

    public void SaveGame(int score, string name)
    {
        if(score >= minScore)
        {
            ArrayList newData = new ArrayList(userScoresData);

            //newData.RemoveAt()
            UsersData obj_user = new UsersData();
            obj_user.Init(name, score);

            //add to newData
            //userScoresData = newData 형식에 맞게

            //SortUsers(users_);
        }

        for(int i = 0; i < maxUserNum; i++)
        {
            userScoresData[i].SaveLocal(i);
        }

    }

    private void SortUser()
    {

    }

}
