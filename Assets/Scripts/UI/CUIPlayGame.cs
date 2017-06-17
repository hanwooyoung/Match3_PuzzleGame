using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIPlayGame : MonoBehaviour {


    public Text CoinTxt = null;
    public Text ScoreTxt = null;
    public Text TimeTxt = null;
    public Slider TimeHpBar = null;
    public GameObject Ready = null;
    public GameObject Go = null;
    public GameObject instPause = null;
    public Animator instReadyAnimator = null;
    public Animator instGoAnimator = null;

    private bool mIsPause = false;
    public bool IsPause
    {
        get
        {
            return mIsPause;
        }
        set
        {
            mIsPause = IsPause;
        }
    }


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetTxtcoin(int value)
    {
        CoinTxt.text = string.Format("{0}", value.ToString());
    }
    public void SetTxtScore(int value)
    {
        ScoreTxt.text = string.Format("{0}", value.ToString());
    }
    public void SetTxtTime(int value)
    {
        TimeTxt.text = string.Format("{0}", value.ToString());
    }

    public void ShowReady()
    {
        instReadyAnimator.SetTrigger("IsTriggerStart");
        Ready.SetActive(true);
        StartCoroutine(ShowGo());
    }

    public IEnumerator ShowGo()
    {
        yield return new WaitForSeconds(1.0f);
        instGoAnimator.SetTrigger("IsTriggerStart");
        Ready.SetActive(false);
        Go.SetActive(true);
        StopCoroutine(ShowGo());

        StartCoroutine(HideGo());
       
    }

    public IEnumerator HideGo()
    {
        yield return new WaitForSeconds(1.0f);
        Go.SetActive(false);

        StopCoroutine(HideGo());

    }

    public void OnClickPauseBtn()
    {
        instPause.SetActive(true);
        Time.timeScale = 0;
    }
}
