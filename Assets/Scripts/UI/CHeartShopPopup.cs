using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHeartShopPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickclosePopup()
    {
        this.gameObject.SetActive(false);
    }
}
