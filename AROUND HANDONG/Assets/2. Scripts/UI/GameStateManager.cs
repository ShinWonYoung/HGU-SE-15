using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStateManager : UIBaseClass
{

    // 나중에 score도 넣을까? 

    private bool _isPaused = false;
    private Canvas _pauseMenuCanvas;

    void Start()
    {

        SetFontSize(_pauseMenuCanvas);

        _isPaused = false;
        _pauseMenuCanvas = GetComponentInChildren<Canvas>();
        _pauseMenuCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { //Escape 누를 때 pause
            if (_isPaused == false) //now pause
            {
                _isPaused = true;
                PauseGame();
            }
            else //now resume game
            {
                _isPaused = false;
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        _pauseMenuCanvas.enabled = true;
        Time.timeScale = 0; //pause
    }

    public void ResumeGame()
    {
        _pauseMenuCanvas.enabled = false;
        Time.timeScale = 1.0F;
    }


}