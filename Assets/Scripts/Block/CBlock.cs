﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlock : MonoBehaviour {


    public CMap.Kind Kind; 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log(Kind);
    }
}
