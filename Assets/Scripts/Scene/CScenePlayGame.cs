using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScenePlayGame : MonoBehaviour {

    public CMap Map = null;

    private void Awake()
    {
        Map = new CMap();
      
    }

    // Use this for initialization
    void Start () {
        Map.CreateMap(this.transform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
