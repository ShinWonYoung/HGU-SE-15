using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : UIBaseClass {

    //소리 조절, BOY/GIRL,  HIGH SCORE

    private Canvas _startMenuCanvas;

    private Image _soundImage;
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    

    // Use this for initialization
    void Start ()
    {
        _startMenuCanvas = GetComponentInChildren<Canvas>();
        _startMenuCanvas.enabled = true;
        AudioListener.volume = 1;

        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image i in images)
            if (i.name == "SoundButton") _soundImage = i;
        
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
    
}