﻿using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using GooglePlayGames.BasicApi;


public class GpgsMgr : MonoBehaviour{

    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.Activate();
        ConectarGoogle();
    }

    public void ConectarGoogle()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            // handle success or failure
            if (true == success)
            {
                Debug.Log("Login");
            }
            else
            {

                Debug.Log("Login Fail !!");
            }
        });
    }

    public void ShowBoard() //리더보드
    {
        CSoundEffect.instance.OnPlayMenuClickBtn();
        Social.ShowLeaderboardUI();
    }

    public void ShowAchievement()//업적
    {
        Social.ShowAchievementsUI();
    }

}

