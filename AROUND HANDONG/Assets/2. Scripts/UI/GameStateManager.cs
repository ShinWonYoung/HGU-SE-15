using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStateManager : UIBaseClass
{

    // 나중에 score도 넣을까? 

    private bool _isPaused = false;
    private Canvas _pauseMenuCanvas;
    public GameObject _confirmTab;
    private Text _scoreText;

    void Start()
    {

        _isPaused = false;
        _pauseMenuCanvas = GetComponentInChildren<Canvas>();
        _pauseMenuCanvas.enabled = false;

        SetFontSize(_pauseMenuCanvas);
       
        _confirmTab.SetActive(false);
        Text[] textArry = _pauseMenuCanvas.GetComponentsInChildren<Text>();
        foreach(Text text in textArry) {
            if (text.name.Contains("Score")) _scoreText = text;
        }
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
        _scoreText.text = "" + Score.getScore();
        _pauseMenuCanvas.enabled = true;
        Time.timeScale = 0; //pause
    }

    public void ResumeGame()
    {
        _pauseMenuCanvas.enabled = false;
        Time.timeScale = 1.0F;
    }


    public void OpenCloseConfirmTab()
    {
        bool b_active = (_confirmTab.activeSelf == false) ? true : false;
        _confirmTab.SetActive(b_active);

    }

}