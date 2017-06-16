using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoundBGM : MonoBehaviour {

    static public CSoundBGM instance;


    public bool IsBgmOn = true;
    public AudioSource IntroBgm = null;
    public AudioSource PlayBgm = null;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if( instance != null)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        //StartCoroutine(Bgmoff());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayGamePlayBgm()
    {
        IntroBgm.Stop();
        PlayBgm.Play();
    }

    public void OnPlayIntroBgm()
    {
        PlayBgm.Stop();
        IntroBgm.Play();
    }

    public void Bgmoff()
    {
        IntroBgm.Stop();
        PlayBgm.Stop();
      
    }
}
