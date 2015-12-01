using UnityEngine;
using System.Collections;

public class UsersData {

    //player's data 담고, PlayerPref을 이용해서 user data 저장, 불러온다.

    private string keylocal = "AH_Local";
    private string s_keyScore = "Score";
    private string s_keyName = "Name";

    public static string DEFAULT_NAME = "_____"; 

    private string s_name;
    private int int_score;
    private string[] as_randomNames = { "Helen", "Sara", "Mary", "Seth", "Beccy" };

    public void Init(string name, int score)
    {
        int_score = score;
        s_name = name;
    }

    public void SetName(string name)
    {
        s_name = name;
    }

    public string GetName()
    {
        return s_name;
    }

    public int GetScore()
    {
        return int_score;
    }

    public void SaveLocal(int index)
    {
        //player들의 점수, 이름 저장
        // 기존에 저장되어 있는 PlayerPrefs에 값을 수정!
        PlayerPrefs.SetInt(keylocal + s_keyScore + index.ToString(), int_score);
        PlayerPrefs.SetString(keylocal + s_keyName + index.ToString(), s_name);
    }

    public void LoadLocal (int index)
    {
        int_score = LoadScore(index);
        s_name = LoadName(index);
    }

    private int LoadScore(int index)
    {
        string s_newKey = keylocal + s_keyScore + index.ToString();
        if (PlayerPrefs.HasKey(s_newKey))
        {
            return PlayerPrefs.GetInt(keylocal + s_keyScore + index.ToString());
        }
        else return -1;
        //없으면 -1 보내자!
    }

    private string LoadName(int index)
    {
        string s_newKey = keylocal + s_keyScore + index.ToString();
        if (PlayerPrefs.HasKey(s_newKey))
        {
            string player_name = PlayerPrefs.GetString(keylocal + s_keyName + index.ToString());
            return player_name;
        }
        else
        {
            //찾으려는 키가 없으면 무작위로 임시 이름
            int int_random = Random.Range(0, as_randomNames.Length);
            // return "";
            return as_randomNames[int_random];
        }
        //없으면 -1 보내자!
    }

}