using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public enum BlockState
    {
        Idle = 0,
        Select = 1,
        Possible =2,
    }

    public CMap.Kind Kind;
    public Move BlockMove = Move.None;
    public CScenePlayGame ScenePlayGeme = null;
    public GameObject InstBody = null;
    public GameObject InstBoom = null;
    
    protected BlockState mCurrentState = BlockState.Idle;
    public BlockState CurrentState
    {
        get
        {
            return mCurrentState;
        }
        set
        {
            mCurrentState = value;
        }
    }

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
    //private float mTime = 0.0f;
    public void DoBoom()
    {
        InstBody.gameObject.SetActive(false);
        InstBoom.gameObject.SetActive(true);
        if (this.Kind == CMap.Kind.HorizontalBomb || this.Kind == CMap.Kind.VerticalBomb)
        {
            ScenePlayGeme.AddCoin(10);
        }
        if(this.Kind == CMap.Kind.FiveBomb)
        {
            ScenePlayGeme.AddCoin(20);
        }
        ScenePlayGeme.AddScore(100);
        StartCoroutine(BlockDestroy());
    }

    public IEnumerator BlockDestroy()
    {
        CSoundEffect.instance.OnPlayBoom();
        yield return new WaitForSeconds(0.2f);
        GameObject.Destroy(gameObject);
    }

   

}
