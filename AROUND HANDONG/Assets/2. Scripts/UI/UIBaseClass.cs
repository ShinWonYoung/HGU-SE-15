using UnityEngine;
using System.Collections;

public class UIBaseClass : MonoBehaviour {

    // levels 관련!
    private string startMenuLevel = "1 StartScene";
    private string gameLevel = "2 Game";

    public enum gender { GIRL, BOY }

    public static gender playerGender = gender.BOY;
    
    public void StartGame()
    {
        Application.LoadLevel(gameLevel);
    }

    public void StartMenu()
    {
        Application.LoadLevel(startMenuLevel);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
