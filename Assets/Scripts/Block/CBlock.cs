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
    public GameObject InstBody = null;
    public GameObject BoomParticle = null;

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
    private float mTime = 0.0f;
    public void DoBoom()
    {
        BoomParticle.gameObject.SetActive(true);

        StartCoroutine(BlockDestroy());
    }

    public IEnumerator BlockDestroy()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject.Destroy(gameObject);
    }
}
