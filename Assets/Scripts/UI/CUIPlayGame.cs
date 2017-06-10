using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIPlayGame : MonoBehaviour {


    public Text CoinTxt = null;
    public Text ScoreTxt = null;
    public Text TimeTxt = null;
    public Slider TimeHpBar = null;

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
}
