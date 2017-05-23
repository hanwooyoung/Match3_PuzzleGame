using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlock : MonoBehaviour {

    struct Index
    {
        int X;
        int Y;
    }

    public CMap.Kind Kind;
    public CScenePlayGame ScenePlayGeme = null;

    public void SetScene(CScenePlayGame tScenePlayGame)
    {
        ScenePlayGeme = tScenePlayGame;
    }

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
