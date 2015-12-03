using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIBaseClass : MonoBehaviour {

    // levels 관련!
    private string startMenuLevel = "1 StartScene";
    private string gameLevel = "2 Game";

    public static int sound = 1;

    public enum gender { GIRL, BOY }

    public float FontSizePercent = 0.1f;

    public static gender playerGender = gender.BOY;
    
    public void SetSound()
    {
        AudioListener.volume = sound;
    }

    public void StartGame()
    {
        Time.timeScale = 1.0F;
        Application.LoadLevel(gameLevel);
    }

    public void StartMenu()
    {
        Time.timeScale = 1.0F;
        Application.LoadLevel(startMenuLevel);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    public void SetFontSize(Canvas c)
    {
        Text[] texts = c.GetComponentsInChildren<Text>();
        foreach (Text t in texts)
        {
            t.fontSize = (int) (t.fontSize * ((Screen.width) / 1236f));
        }
    }
}
