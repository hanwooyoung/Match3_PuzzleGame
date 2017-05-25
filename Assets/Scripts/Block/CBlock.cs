using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlock : MonoBehaviour {

    public struct Index 
    {
        public int X;
        public int Y;
    }

    public Index BlockCoordinate = new Index();

    public enum Move
    {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4,
    }

    public CMap.Kind Kind;
    public Move BlockMove = Move.None;
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
    /*
    private void OnMouseDown()
    {
        Debug.Log(Kind);
        
    }
    */

    public void ReSetMove()
    {
        BlockMove = Move.None;
        ScenePlayGeme.SetSwapPos(BlockMove);
    }
}
