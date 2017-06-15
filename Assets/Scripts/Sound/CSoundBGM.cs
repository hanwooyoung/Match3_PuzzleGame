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


    public IEnumerator Bgmoff()
    {
        for (;;)
        {
            if (IsBgmOn == false)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(0.5f);
        }
      
    }
}
