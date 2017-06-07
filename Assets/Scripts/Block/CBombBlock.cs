using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;

public class CBombBlock : CBlock {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseUp()
    {


    }



    [Button]
    public void Xy()
    {
        Debug.Log("X" + BlockCoordinate.X);
        Debug.Log("Y" + BlockCoordinate.Y);
    }
}
