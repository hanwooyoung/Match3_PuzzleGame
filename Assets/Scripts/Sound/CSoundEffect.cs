using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoundEffect : MonoBehaviour {

    static public CSoundEffect instance;

    public AudioSource MenuClickBtn = null;
    public AudioSource StartBtn = null;

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
}
