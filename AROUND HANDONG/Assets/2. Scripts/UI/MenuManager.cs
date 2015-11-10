using UnityEngine;
using System.Collections;

public class MenuManager : UIBaseClass {

    //소리 조절, BOY/GIRL,  HIGH SCORE

    private Canvas _startMenuCanvas;

    // Use this for initialization
    void Start () {
        _startMenuCanvas = GetComponentInChildren<Canvas>();
        _startMenuCanvas.enabled = true;
        AudioListener.volume = 1;
    }

    public void SoundControl()
    {
        AudioListener.volume = (AudioListener.volume == 0) ? 1 : 0;
    }

    public void MenuStartGame(string playerG)
    {
        playerGender = (playerG == "boy") ? gender.BOY : gender.GIRL;
        StartGame();

    } 
    
}