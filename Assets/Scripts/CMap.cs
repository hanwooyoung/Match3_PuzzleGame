using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMap : MonoBehaviour {

    public enum Kind
    {

    } 

    public int[,] MapArray = null;


    private void Awake()
    {
        MapArray = new int[9, 9]
            {
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0}
            };
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
