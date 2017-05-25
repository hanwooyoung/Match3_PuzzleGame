using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;
using DG.Tweening;


public class CScenePlayGame : MonoBehaviour {

    public CMap Map = null;

    public CBlock SeletBlock = null;
    public CBlock.Move SwapPos = CBlock.Move.None;


    private void Awake()
    {
        Map = new CMap();
        
    }

    // Use this for initialization
    void Start () {
        Map.CreateMap(this.transform);

        for (int ti = 0; ti < CMap.Raw; ti++)
        {
            for (int tj = 0; tj < CMap.Col; tj++)
            {
                Map.BlockArray[ti, tj].SetScene(this);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSwapPos(CBlock.Move tSwapPos)
    {
        SwapPos = tSwapPos;
    }

    public void SetSwapBlock(CBlock tBlock)
    {
        SeletBlock = tBlock;
    }
    

   
    public void DoSwap(Vector2 tMoveVec)
    {
        int tX = (int)tMoveVec.x;
        int tY = (int)tMoveVec.y;

        if (SeletBlock != null && CBlock.Move.None != SwapPos)
        {
            foreach (CBlock tBlock in Map.BlockArray)
            {
                if(tBlock == SeletBlock)
                {
                    CBlock tTmepBlock = null;
                    Vector2 BlockVec = Vector2.zero;
                    Vector2 SwapVec = Vector2.zero;
                    var tBlockCoordinate = tBlock.BlockCoordinate;
                    tTmepBlock = Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y];
                    BlockVec = tBlock.transform.position;
                    
                    if (SwapPos != CBlock.Move.None)
                    {
                        SwapVec = Map.BlockArray[tBlock.BlockCoordinate.X + tX, tBlock.BlockCoordinate.Y + tY].transform.position;

                        tBlock.transform.DOMove(SwapVec,0.1f);
                        Map.BlockArray[tBlock.BlockCoordinate.X + tX, tBlock.BlockCoordinate.Y + tY].transform.DOMove(BlockVec, 0.1f);

                        Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y] = Map.BlockArray[tBlock.BlockCoordinate.X + tX, tBlock.BlockCoordinate.Y + tY];
                        Map.BlockArray[tBlock.BlockCoordinate.X + tX, tBlock.BlockCoordinate.Y + tY] = tTmepBlock;

                        Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y].BlockCoordinate.X -= tX;
                        Map.BlockArray[tBlock.BlockCoordinate.X + tX, tBlock.BlockCoordinate.Y].BlockCoordinate.X += tX;
                        Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y].BlockCoordinate.Y -= tY;
                        Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y + tY].BlockCoordinate.Y += tY;

                    }                   
                    tBlock.ReSetMove();
                }
            }
        }
    }



    public void IsCheckUpDate()
    {
        foreach (CBlock tBlock in Map.BlockArray)
        {
            if(SeletBlock == tBlock)
            {
                Vector2 tVec = Vector2.zero;
            }
        }
    }
}
