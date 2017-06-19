using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Inspector;

public class CUILobby : MonoBehaviour {

    public GameObject[] HeartArray = new GameObject[5];

    public const int TOTAL_HEARTCOUNT = 5;
    public const int WAITINGTIME = 300;


    public int CurrentHeartCount = 0;
    public int Total_Timer = 0;
    public int Min = 0;
    public int Sec = 0;


    private int mHeart = 0;
    private int mSpareTime = 0;
    private CIntReactiveProperty mTime = null;

    public Text BestScore = null;
    public Text TotalCoin = null;
    public Text TimeText = null;
    public CUserData UserData = null;

    public CHeartShopPopup HeartShopPopup = null;
    public GameObject HeartNotPanel = null;
    public GameObject CoinNotPanel = null;
    public GameObject CoinShopPopup = null;

    

    private void Awake()
    {
        UserData = new CUserData();

        mTime = new CIntReactiveProperty();
        mTime.Subscribe((time) =>
        {
            Total_Timer = time;
            Min = Total_Timer / 60;
            Sec = Total_Timer % 60;

            TimeText.text = string.Format("{0} :{1:D2}", Min, Sec);
        });
        HeartShopPopup.SetUILobby(this);
    }
    // Use this for initialization
    void Start () {
        BestScore.text = string.Format("{0}", UserData.BestScore);
        TotalCoin.text = UserData.Coin.ToString();

    }
	
	// Update is called once per frame
	void Update () {
        UpdateHeartArray();
        CheckHeartTime();
    }

    public void OnClickGoScenePlayGameBtn()
    {
        if(mHeart != 0)
        {
            mHeart -= 1;
            if(mHeart <0)
            {
                mHeart = 0;
            }
            UserData.Heart = mHeart;
            CSoundBGM.instance.OnPlayGamePlayBgm();
            CSoundEffect.instance.OnPlayStartBtn();
            SceneManager.LoadScene("CScenePlayGame");
        }
        else
        {
            Debug.Log("하트없음");
            HeartNotPanel.SetActive(true);
        }
    }

    public void CheckHeartTime()
    {

        var now = DateTime.Now.ToLocalTime();

        var span = (now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
        int nowTime = (int)span.TotalSeconds;

        if (mHeart == TOTAL_HEARTCOUNT)
        {
            TimeText.text = string.Format("MAX");
            UserData.ExitTime = nowTime;
            return;
        }




        int tExitTime = 0;

        if (UserData.ExitTime == 0)
        {
            UserData.ExitTime = nowTime;
        }
        else
        {
            tExitTime = UserData.ExitTime;

        }


        mHeart = UserData.Heart;

        int gapTime = nowTime - tExitTime;


        int roundCount = gapTime / WAITINGTIME;
        int remainder = gapTime % WAITINGTIME;


        if (roundCount > 0)
        {
            UserData.ExitTime = nowTime;

            if (roundCount >= TOTAL_HEARTCOUNT - mHeart)
            {
                roundCount = TOTAL_HEARTCOUNT - mHeart;
                if (roundCount < 0) roundCount = 0;
            }


            mHeart += roundCount;

        }



        UserData.SpareTime = WAITINGTIME - remainder;
        UserData.Heart = mHeart;

        mTime.Value = UserData.SpareTime;

    }

    [Button]
    public void HeartCount()
    {
        Debug.Log(mHeart.ToString());
    }

    [Button]
    public void SetUserData()
    {
        UserData.Heart = 3;
    }


    public void UpdateHeartArray()
    {
        for (int ti = 0; ti < TOTAL_HEARTCOUNT; ti++)
        {
            if (ti < TOTAL_HEARTCOUNT - mHeart)
            {
                HeartArray[ti].SetActive(false);
            }
            else
            {
                HeartArray[ti].SetActive(true);
            }
        }
    }
    

    public void OnClickHeartShopPopUpBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        HeartShopPopup.gameObject.SetActive(true);
    }

    public void OnClickCoinShopPopUpBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        CoinShopPopup.gameObject.SetActive(true);
    }



    public void OnClickHeartNotPanelYesBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        HeartNotPanel.SetActive(false);
        HeartShopPopup.gameObject.SetActive(true);
    }
    public void OnClickHeartNotPanelYNoBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        HeartNotPanel.SetActive(false);
    }


    public void OnClickCoinNotPanelYesBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        CoinNotPanel.SetActive(false);
        HeartShopPopup.gameObject.SetActive(false);
        CoinShopPopup.gameObject.SetActive(true);
        
    }
    public void OnClickCoinNotPanelYNoBtn()
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        CoinNotPanel.SetActive(false);
    }

}
