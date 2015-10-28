using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    // 나중에 score도 넣을까? 

    
    private bool _isPaused = false;
    private Canvas _pauseMenuCanvas;

    // levels 관련!
    private string startMenuLevel = "1 StartScene";
    private string gameLevel = "2 Game";

    void Start()
    {

        //font 조절하는거.

        _isPaused = false;
        _pauseMenuCanvas = GetComponentInChildren<Canvas>();
        _pauseMenuCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { //Escape 누를 때 pause
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

    public void RestartGame()
    {
        Application.LoadLevel(gameLevel);
    }

    public void StartMenu()
    {
        Application.LoadLevel(startMenuLevel);
    }

    void QuitGame()
    {
        //confirm 창?

        Application.Quit();
    }
}