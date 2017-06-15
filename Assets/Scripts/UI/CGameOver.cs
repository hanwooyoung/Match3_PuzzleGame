using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CGameOver : MonoBehaviour {
    public CScenePlayGame ScenePlayGame = null;
    public Text ScoreTxt = null;
    public int Score = 0;
    public Text CoinTxt = null;
    public CUserData UserData = null;

    private void Awake()
    {
        UserData = new CUserData();
    }
    // Use this for initialization
    void Start () {

        //ScoreTxt.DOText = ScenePlayGame.Score.ToString();
        ScoreTxt.text = Score.ToString();
        CoinTxt.text = ScenePlayGame.Coin.ToString();
        StartCoroutine(ScoreAni());
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator ScoreAni()
    {
        for(;;)
        {
            if (Score < ScenePlayGame.Score)
            {
                Score+=400;
                ScoreTxt.text = Score.ToString();
            }
            else
            {
                Score = ScenePlayGame.Score;
                ScoreTxt.text = Score.ToString();
                
            }
            yield return new WaitForSeconds(0.0f);
        }
       

    }

    public void OnClickGoLobbyBtn()
    {
        UserData.Coin += ScenePlayGame.Coin;
        SceneManager.LoadScene("CSceneLobby");
    }

    public void SetScene(CScenePlayGame tScenePlayGame)
    {
        ScenePlayGame = tScenePlayGame;
    }
}
