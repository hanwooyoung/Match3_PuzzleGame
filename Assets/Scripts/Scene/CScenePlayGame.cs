using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;
using DG.Tweening;


public class CScenePlayGame : MonoBehaviour {

    public CMap Map = null;

    public CBlock SeletBlock = null;
    public CBlock.Move SwapPos = CBlock.Move.None;

    public CBoomCheck BoomCheck = null;

    private void Awake()
    {
        Map = new CMap();
        BoomCheck = new CBoomCheck();
        BoomCheck.SetBlockArray(Map.BlockArray);


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
        Map.BlockNullCheck();
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
                    IsCheckUpDate();
                    tBlock.ReSetMove();
                }
            }
        }

        //BoomCheck.SetBlockArray(Map.BlockArray);
    }



    public void IsCheckUpDate()
    {
        BoomCheck.SetBlockArray(Map.BlockArray);
        foreach (CBlock tBlock in Map.BlockArray)
        {

            if (SeletBlock == tBlock)
            {
                Vector2 tVec = Vector2.zero;
                tVec = SeletBlock.transform.position;
                int tX = (int)tVec.x;
                int tY = (int)tVec.y;

                BoomCheck.SetSeletBlock(tBlock);

                BoomCheck.LeftBoom();
                tBlock.ReSetMove();
              
            }
        }
        BoomCheck.Stack();
        BlockDestroy();
    }

    [Button]
    public void Asd()
    {
        BoomCheck.Stack();
    }

    [Button]
    public void BlockDestroy()
    {
        foreach(var ti in Map.BlockArray)
        {
            foreach(var tj in BoomCheck.BoomBlockList)
            {
                if(ti == tj)
                {           
                    ti.BlockDestroy();

                }
            }
        }
        BoomCheck.BoomBlockList.Clear();
        BoomCheck.LeftBoomNumber = 0;
    }


    [Button]
    public void Array()
    {
        for (int ti = 0; ti < 9; ti++)
        {
            for (int tj = 0; tj < 9; tj++)
            {
                Debug.Log("(" + tj + "," + ti + ")" + "=" + Map.BlockArray[tj, ti]);
            }
        }
    }
    

    //[Button]
    //public void BlockNullCheck()
    //{
    //    foreach (var ti in Map.BlockArray)
    //    {
    //        if(ti == null)
    //        {
    //            var tX = ti.BlockCoordinate.X;
    //            var tY = ti.BlockCoordinate.Y;
    //            int tN = 0;
    //            while((tY + tN + 1)<7)
    //            {
    //                Map.BlockArray[tX, tY + tN + 1].transform.DOMove(new Vector2(tX, tY + tN), 0.5f);
    //            }

    //        }
    //    }
    //}
}
