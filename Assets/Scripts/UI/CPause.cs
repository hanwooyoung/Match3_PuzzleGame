using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CPause : MonoBehaviour {

    public CScenePlayGame ScenePlayGame = null;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void SetScene(CScenePlayGame tScenePlayGame)
    {
        ScenePlayGame = tScenePlayGame;
    }

    public void OnClickQuit()
    {
        ScenePlayGame.GameOver();
        //SceneManager.LoadScene("CSceneLobby");
    }

    public void OnClickContinue()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
