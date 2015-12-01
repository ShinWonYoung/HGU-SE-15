using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuManager : UIBaseClass {

    //소리 조절, BOY/GIRL,  HIGH SCORE

    private Canvas _startMenuCanvas;
    private Canvas _highScoreCanvas;

    private Image _soundImage;
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    

    // Use this for initialization
    void Start ()
    {
        AudioListener.volume = 1;

        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image i in images)
            if (i.name == "SoundButton") _soundImage = i;

        _startMenuCanvas = GetComponentInChildren<Canvas>();
        _startMenuCanvas.enabled = true;

        try {
            _highScoreCanvas = GameObject.Find("HighScoreUI").GetComponentInChildren<Canvas>();
            if (_highScoreCanvas != null) _highScoreCanvas.enabled = false;
        }
        catch(Exception e) { Debug.Log(e);  }

        Text[] textArry = _startMenuCanvas.GetComponentsInChildren<Text>();
        foreach (Text ctext in textArry)
        {
            if (ctext.name.Contains("Score")) ctext.text = "" + Score.getScore();
        }

        SetFontSize(_startMenuCanvas);

    }

    public void SoundControl()
    {
        _soundImage.sprite = (AudioListener.volume == 0) ? soundOnImage : soundOffImage;
        AudioListener.volume = (AudioListener.volume == 0) ? 1 : 0;
    }

    public void MenuStartGame(string playerG)
    {
        playerGender = (playerG == "boy") ? gender.BOY : gender.GIRL;
        StartGame();

    } 

    public void OpenCloseHighScore()
    {
        _startMenuCanvas.enabled = (_startMenuCanvas.enabled == true) ? false : true;
        _highScoreCanvas.enabled = (_highScoreCanvas.enabled == true) ? false : true;
    }
    
}