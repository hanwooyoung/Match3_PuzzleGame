using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoundEffect : MonoBehaviour {

    static public CSoundEffect instance;

    public AudioSource MenuClickBtn = null;
    public AudioSource StartBtn = null;
    public AudioSource Swap = null;
    public AudioSource UnSwap = null;
    public AudioSource Boom = null;
    public AudioSource Select = null;
    public AudioSource Whistle = null;
    public AudioSource Warning = null;
    public AudioSource Timeover = null;
    public AudioSource ReadyGo = null;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayStartBtn()
    {
        StartBtn.Play();
    }

    public void OnPlayMenuClickBtn()
    {
        MenuClickBtn.Play();
    }

    public void OnPlaySwap()
    {
        Swap.Play();
    }
    public void OnPlayUnSwap()
    {
        UnSwap.Play();
    }
    public void OnPlayBoom()
    {
        Boom.Play();
    }
    
    public void OnPlaySelect()
    {
        Select.Play();
    }
    public void OnPlayWhistle()
    {
        Whistle.Play();
    }
    public void OnPlayWarning()
    {
        Warning.Play();
    }
    public void OffWarning()
    {
        Warning.Stop();
    }
    public void OnPlayTimeover()
    {
        Timeover.Play();
    }

    public void OnPlayReadyGo()
    {
        ReadyGo.Play();
    }

    public void EffectOff()
    {

    }
}
