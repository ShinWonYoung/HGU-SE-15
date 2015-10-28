using UnityEngine;
using System.Collections;

public class HighScoreManager : MonoBehaviour {

    public GUISkin customSkin;

    public static string userName = "Player 1";

    public int maxNumOfUsers = 5;

    enum Page { GAMEOVER, LOCALSCORE, SERVERSCORE };

    private Page e_page = Page.GAMEOVER; //기본값이 gameover

    //필요 없을 수도!
    private Vector2 scrollPositionL = Vector2.zero; //local scores scroll 영역의 scroller 초기

    private Vector2 scrollPositionR = Vector2.zero;


    //버튼들이 클릭됐는지 확인한다
    private bool b_isClickRestart = false;

    private bool b_isClickSubmit = false;

    private LocalHighScore obj_localHighScore;

    // Use this for initialization
    void Start () {
        e_page = Page.GAMEOVER;
        scrollPositionL = scrollPositionR = Vector2.zero;
        b_isClickRestart = b_isClickSubmit = false;

        obj_localHighScore = new LocalHighScore();
        obj_localHighScore.SetMaxUser(maxNumOfUsers);
	}
	
    void OnGUI() //게임 종료 page를 나타내기 위한 코드
    {
        //if() //game over 됐을때 StaticVars.b_isGameOver
        {
            GUI.skin = customSkin;
            if(b_isClickRestart == false)
            {
                switch (e_page)
                {
                    case Page.GAMEOVER:
                        GameOverPage(); //게임 종료 page
                        break;
                    case Page.LOCALSCORE:
                        LocalScorePage();
                        break;
                    case Page.SERVERSCORE:
                        break;
                }

                // RESTART button 만들기

            }
            else
            {
                //RESTART button 클릭했을 때 보여줄 로딩 text
            }
        }

    }

    private void GameOverPage()
    {
        //배경으로 쓰일 box
        //player의 최종 점수를 보여줄 text label....
        //player의 이름 입력할 text field
        //submit button
        //submit 누르면 obj_localHighScore.SaveGame(점수, 이름);

        //local 점수 page button
        //server 점수 page button
    }

    private void LocalScorePage()
    {
        //배경...
        //텍스트 수정
        //for(int i = 0; i < maxNumOfUsers; i++) { 텍스트 수정하자.  }
    }

}
