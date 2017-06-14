using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CUILobby : MonoBehaviour {

    public GameObject[] HeartArray = new GameObject[5];
    public Text BestScore = null;
    public Text TotalCoin = null;
    public CUserData UserData = null;

    private void Awake()
    {
        UserData = new CUserData();
    }
    // Use this for initialization
    void Start () {
        BestScore.text = UserData.BestScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickGoScenePlayGameBtn()
    {
        SceneManager.LoadScene("CScenePlayGame");
    }


}
