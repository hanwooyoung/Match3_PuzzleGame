using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScenePlayGame : MonoBehaviour {

    public CMap Map = null;

    public CBlock SeletBlock = null;
    

    private void Awake()
    {
        Map = new CMap();
      
    }

    // Use this for initialization
    void Start () {
        Map.CreateMap(this.transform);
    }
    
    public void SetSwapBlock(CBlock tBlock)
    {
        SeletBlock = tBlock;
    }

    void IsSwap()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
