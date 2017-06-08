﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;
using DG.Tweening;


public class CScenePlayGame : MonoBehaviour {

    public CMap Map = null;

    public CBlock SelectBlock = null;
    public CBlock SwapBlock = null;
    public CBlock.Move SwapPos = CBlock.Move.None;
    public Vector2 MoveVec = Vector2.zero;

    public CBoomCheck BoomCheck = null;

    public CPossibleBoomCheck PossibleBoomCheck = null;

    public bool IsBlockBoom = false;
    private bool mIsDontMove = false;
    public bool IsDontMove
    {
        get
        {
            return mIsDontMove;
        }
        set
        {
            mIsDontMove = value;
        }
    }
    private void Awake()
    {
        Map = new CMap();
        BoomCheck = new CBoomCheck();
        BoomCheck.SetBlockArray(Map.BlockArray);

        PossibleBoomCheck = new CPossibleBoomCheck();
        PossibleBoomCheck.SetMapArray(Map.MapArray);

    }

    // Use this for initialization
    void Start() {
        Map.SetParent(this.transform);
        Map.CreateMap();
        //StartCoroutine(ReCreateBlock());
        StartCoroutine(IsCheckUpDate());


        for (int ti = 0; ti < CMap.Raw; ti++)
        {
            for (int tj = 0; tj < CMap.Col; tj++)
            {
                Map.BlockArray[ti, tj].SetScene(this);
            }
        }

        StartCoroutine(Map.BlockNullCheck());

    }

    // Update is called once per frame
    void Update()
    {

        PossibleBoomCheck.SetMapArray(Map.MapArray);
        if (MoveVec != Vector2.zero && IsDontMove == false)
            DoSwap(MoveVec);
        if (SelectBlock == null || SwapBlock == null)
            IsDontMove = false;

        //IsBombBlockCheck(SelectBlock);
        //IsCheckUpDate();
        //if (BoomCheck.IsBoomCheck == false)
        //UnSwap();

    }

    public void SetSwapPos(CBlock.Move tSwapPos)
    {
        SwapPos = tSwapPos;
    }

    public void SetSelectBlock(CBlock tBlock)
    {
        SelectBlock = tBlock;
    }

    public void SetSwapBlock(CBlock tBlock)
    {
        SwapBlock = tBlock;
    }

    [Button]
    public void InPossibleBoomCheck()
    {
        PossibleBoomCheck.IsCheck();
    }

    public void DoSwap(Vector2 tMoveVec)
    {
        int tX = (int)tMoveVec.x;
        int tY = (int)tMoveVec.y;
        if (SelectBlock != null && CBlock.Move.None != SwapPos)
        {
            foreach (CBlock tBlock in Map.BlockArray)
            {
                if (tBlock == SelectBlock)
                {
                    IsDontMove = true;

                    CBlock tTmepBlock = null;
                    Vector2 BlockVec = Vector2.zero;
                    Vector2 SwapVec = Vector2.zero;
                    Vector2 ReturnBlockVec = Vector2.zero;
                    Vector2 ReturnSwapVec = Vector2.zero;

                    var tBlockX = tBlock.BlockCoordinate.X;
                    var tBlockY = tBlock.BlockCoordinate.Y;
                    CMap.Kind tTmepKind = tBlock.Kind;
                    tTmepBlock = Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y];
                    BlockVec = tBlock.transform.position;
                    ReturnBlockVec = BlockVec;



                    if (SwapPos != CBlock.Move.None && Map.BlockArray[tBlockX + tX, tBlockY + tY].Kind != CMap.Kind.Wall)
                    {
                        SwapVec = Map.BlockArray[tBlockX + tX, tBlockY + tY].transform.position;
                        ReturnSwapVec = SwapVec;

                        tBlock.transform.DOMove(SwapVec, 0.1f);
                        Map.BlockArray[tBlockX + tX, tBlockY + tY].transform.DOMove(BlockVec, 0.1f);

                        SetSwapBlock(Map.BlockArray[tBlockX + tX, tBlockY + tY]);

                        Map.BlockArray[tBlockX, tBlockY] = Map.BlockArray[tBlockX + tX, tBlockY + tY];
                        Map.BlockArray[tBlockX + tX, tBlockY + tY] = tTmepBlock;

                        Map.BlockArray[tBlockX, tBlockY].BlockCoordinate.X -= tX;
                        Map.BlockArray[tBlockX + tX, tBlockY].BlockCoordinate.X += tX;
                        Map.BlockArray[tBlockX, tBlockY].BlockCoordinate.Y -= tY;
                        Map.BlockArray[tBlockX, tBlockY + tY].BlockCoordinate.Y += tY;

                        tTmepKind = Map.MapArray[tBlockX, tBlockY];
                        Map.MapArray[tBlockX, tBlockY] = Map.MapArray[tBlockX + tX, tBlockY + tY];
                        Map.MapArray[tBlockX + tX, tBlockY + tY] = tTmepKind;

                    }

                    tBlock.ReSetMove();
                }
            }
            Invoke("InvokeUnSwap", 0.3f);

        }
    }

    public void InvokeUnSwap()
    {
        //Debug.Log("IsBoomCheck" + BoomCheck.IsBoomCheck);
        //Debug.Log("IsBlockBoom" + IsBlockBoom);
        if (BoomCheck.IsBoomCheck == false)// && IsBlockBoom == false )
        {

            Invoke("UnSwap", 0.05f);
        }
        //if (IsBlockBoom == true)
        //{
        //    IsBlockBoom = false;
        //}
    }

    [Button]
    public void UnSwap()
    {
        if (false == Map.MapIsNull && SelectBlock != null && SwapBlock != null && SwapBlock.Kind != CMap.Kind.Wall)
        {
            //Debug.Log("UnSwap");
            Vector2 tMoveVec = MoveVec;

            var tBlock = SelectBlock;
            int tX = (int)-tMoveVec.x;
            int tY = (int)-tMoveVec.y;
            CBlock tTmepBlock = null;
            var tBlockX = tBlock.BlockCoordinate.X;
            var tBlockY = tBlock.BlockCoordinate.Y;
            CMap.Kind tTmepKind = tBlock.Kind;
            //Debug.Log(Map.BlockArray[tBlock.BlockCoordinate.X + tX , tBlock.BlockCoordinate.Y + tY].Kind);
            if (Map.BlockArray[tBlock.BlockCoordinate.X + tX, tBlock.BlockCoordinate.Y + tY].Kind != CMap.Kind.Wall)
            {
                tTmepBlock = Map.BlockArray[tBlock.BlockCoordinate.X + tX, tBlock.BlockCoordinate.Y + tY];

                Map.BlockArray[tBlockX, tBlockY].transform.DOMove(Map.VecArray[tBlockX + tX, tBlockY + tY], 0.1f);
                Map.BlockArray[tBlockX + tX, tBlockY + tY].transform.DOMove(Map.VecArray[tBlockX, tBlockY], 0.1f);


                Map.BlockArray[tBlockX + tX, tBlockY + tY] = Map.BlockArray[tBlockX, tBlockY];
                Map.BlockArray[tBlockX, tBlockY] = tTmepBlock;

                Map.BlockArray[tBlockX, tBlockY].BlockCoordinate.X -= tX;
                Map.BlockArray[tBlockX + tX, tBlockY].BlockCoordinate.X += tX;
                Map.BlockArray[tBlockX, tBlockY].BlockCoordinate.Y -= tY;
                Map.BlockArray[tBlockX, tBlockY + tY].BlockCoordinate.Y += tY;

                tTmepKind = Map.MapArray[tBlockX, tBlockY];
                Map.MapArray[tBlockX, tBlockY] = Map.MapArray[tBlockX + tX, tBlockY + tY];
                Map.MapArray[tBlockX + tX, tBlockY + tY] = tTmepKind;
            }



            //BoomCheck.IsBoomCheck = true;
        }
        SetSwapBlock(null);
        IsDontMove = false;

    }




    public void SetMoveVec(Vector2 tMoveVec)
    {
        MoveVec = tMoveVec;
    }

    public IEnumerator IsCheckUpDate()
    {
        for (;;)
        {

            BoomCheck.SetBlockArray(Map.BlockArray);
            foreach (CBlock tBlock in Map.BlockArray)
            {

                if (null != tBlock && (SelectBlock == tBlock && tBlock.Kind != CMap.Kind.None && tBlock.Kind != CMap.Kind.Wall))
                {

                    BoomCheck.SetSeletBlock(tBlock);

                    BoomCheck.RightBoom();
                    BoomCheck.LeftBoom();
                    BoomCheck.SideXBoom();
                    BoomCheck.UpBoom();
                    BoomCheck.DownBoom();
                    BoomCheck.SideYBoom();


                    //IsBombBlockCheck(tBlock);
                    tBlock.ReSetMove();
                }

                if (null != tBlock && SwapBlock == tBlock && tBlock.Kind != CMap.Kind.None && tBlock.Kind != CMap.Kind.Wall)
                {
                    BoomCheck.SetSeletBlock(tBlock);

                    BoomCheck.RightBoom();
                    BoomCheck.LeftBoom();
                    BoomCheck.SideXBoom();
                    BoomCheck.UpBoom();
                    BoomCheck.DownBoom();
                    BoomCheck.SideYBoom();
                    //IsBombBlockCheck(tBlock);
                    tBlock.ReSetMove();
                }

                if (null != tBlock && tBlock.Kind != CMap.Kind.None && tBlock.Kind != CMap.Kind.Wall)
                {
                    BoomCheck.SetSeletBlock(tBlock);

                    BoomCheck.RightBoom();
                    BoomCheck.LeftBoom();
                    BoomCheck.SideXBoom();
                    BoomCheck.UpBoom();
                    BoomCheck.DownBoom();
                    BoomCheck.SideYBoom();
                    //IsBombBlockCheck(tBlock);
                    if (BoomCheck.BoomBlockList.Count > 0)
                    {
                        tBlock.ReSetMove();
                        BoomCheck.IsBoomCheck = true;
                    }

                }
            }

            if (BoomCheck.BoomBlockList.Count > 0)
            {
                IsBlockBoom = true;
                BoomCheck.IsBoomCheck = true;
            }
            else
            {
                IsBlockBoom = false;
            }
            BoomCheck.Stack();
            //Debug.Log("count"+BoomCheck.BoomBlockList.Count);
            CBlock tBombBlock = null;
            foreach (CBlock tBlock in BoomCheck.BoomBlockList)
            {
                if(SelectBlock == tBlock)
                {
                    tBombBlock = tBlock;
                    Debug.Log("이건 선택이여");
                }
                else if(SwapBlock == tBlock)
                {
                    tBombBlock = tBlock;
                    Debug.Log("이건 스와비여");
                }
            }
            if(tBombBlock == null && BoomCheck.BoomBlockList.Count >0)
            {
                tBombBlock = BoomCheck.BoomBlockList.Peek();
            }
            BlockDestroy();
            //Invoke("BlockDestroy", 2.0f);
            IsBombBlockCheck(tBombBlock);

            Invoke("ReCreateBlock", 1.0f);
            //ReCreateBlock();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void IsBombBlockCheck(CBlock tBlock)
    {
        CBlock tBombBlock = null;
        if (BoomCheck.IsSideXBoomCheck == true || BoomCheck.IsRightBoomCheck == true || BoomCheck.IsLeftBoomCheck == true
            ||BoomCheck.IsUpBoomCheck == true || BoomCheck.IsDownBoomCheck == true || BoomCheck.IsSideYBoomCheck == true)
        {
            Debug.Log("뀨?" + MoveVec.x);

            if (MoveVec.x != 0)
            {
                tBombBlock = GameObject.Instantiate<CBlock>(Map.BlockLoader.GetPrefab(CMap.Kind.HorizontalBomb), Map.VecArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y], Quaternion.identity);
                tBombBlock.transform.SetParent(this.transform);
                Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y] = tBombBlock;
                Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y].SetScene(this);
                Map.MapArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y] = CMap.Kind.HorizontalBomb;
                tBombBlock.BlockCoordinate.X = tBlock.BlockCoordinate.X;
                tBombBlock.BlockCoordinate.Y = tBlock.BlockCoordinate.Y;
            }
            else
            {
                tBombBlock = GameObject.Instantiate<CBlock>(Map.BlockLoader.GetPrefab(CMap.Kind.VerticalBomb), Map.VecArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y], Quaternion.identity);
                tBombBlock.transform.SetParent(this.transform);
                Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y] = tBombBlock;
                Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y].SetScene(this);
                Map.MapArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y] = CMap.Kind.VerticalBomb;
                tBombBlock.BlockCoordinate.X = tBlock.BlockCoordinate.X;
                tBombBlock.BlockCoordinate.Y = tBlock.BlockCoordinate.Y;
            }
            //Map.MapArray[tBlock.BlockCoordinate.X,tBlock.BlockCoordinate.Y]
            BoomCheck.IsSideXBoomCheck = false;
            BoomCheck.IsRightBoomCheck = false;
            BoomCheck.IsLeftBoomCheck = false;
            BoomCheck.IsUpBoomCheck = false;
            BoomCheck.IsDownBoomCheck = false;
            BoomCheck.IsSideYBoomCheck = false;
        }
    }
 
    

    public void ReCreateBlock()
    {

        for (int ti = 1; ti < CMap.Raw - 1; ti++)
        {
            for (int tj = 1; tj < CMap.Col - 1; tj++)
            {
                if (Map.MapArray[tj, ti] == CMap.Kind.None)
                {
                    CBlock tBlock = null;
                    Vector2 tVec = new Vector2((float)tj / (float)1.11 - (float)3.6, (float)ti / (float)1.11 - (float)4.2);
                    Vector2 tCreateVec = new Vector2(tVec.x, tVec.y + 2.0f);

                    int tRandom = 0;
                    tRandom = Random.Range(4, 9);
                    CMap.Kind tCurrentBlock = (CMap.Kind)tRandom;

                    Map.MapArray[tj, ti] = tCurrentBlock;
                    CMap.Kind tRawBlock = tCurrentBlock;


                    if (tj >= 3)
                    {
                        if (Map.MapArray[tj, ti] == Map.MapArray[tj - 1, ti] && Map.MapArray[tj, ti] == Map.MapArray[tj - 2, ti])
                        {
                            do
                            {
                                tRandom = Random.Range(4, 9);
                            }
                            while (tCurrentBlock == (CMap.Kind)tRandom);

                            tCurrentBlock = (CMap.Kind)tRandom;
                            Map.MapArray[tj, ti] = tCurrentBlock;
                            tRawBlock = tCurrentBlock;
                        }
                    }
                    if (ti >= 3)
                    {
                        if (Map.MapArray[tj, ti] == Map.MapArray[tj, ti - 1] && Map.MapArray[tj, ti] == Map.MapArray[tj, ti - 2])
                        {
                            do
                            {
                                tRandom = Random.Range(4, 9);
                            }
                            while (tCurrentBlock == (CMap.Kind)tRandom && tRawBlock == (CMap.Kind)tRandom);

                            tCurrentBlock = (CMap.Kind)tRandom;
                            Map.MapArray[tj, ti] = tCurrentBlock;
                        }
                    }


                    tBlock = GameObject.Instantiate(Map.BlockLoader.GetPrefab(Map.MapArray[tj, ti]), tCreateVec, Quaternion.identity);
                    tBlock.transform.DOMove(tVec, 0.25f);
                    tBlock.transform.SetParent(this.transform);
                    Map.BlockArray[tj, ti] = tBlock;
                    Map.BlockArray[tj, ti].SetScene(this);
                    tBlock.BlockCoordinate.X = tj;
                    tBlock.BlockCoordinate.Y = ti;
                }
            }
        }
    }

    [Button]
    public void Stack()
    {
        BoomCheck.Stack();
    }

    [Button]
    public void select()
    {
        Debug.Log(SelectBlock);
    }
    [Button]
    public void swap()
    {
        Debug.Log(SwapBlock);
    }
    [Button]
    public void Dontmove()
    {
        Debug.Log(IsDontMove);
    }

    [Button]
    public void BlockDestroy()
    {
        

        if (BoomCheck.BoomBlockList.Count > 0)
        {
            while (BoomCheck.BoomBlockList.Count > 0)
            {
                CBlock tBlock = null;
                tBlock = BoomCheck.BoomBlockList.Pop();
               
                for (int ti = 0; ti < CMap.Raw; ti++)
                {
                    for (int tj = 0; tj < CMap.Col; tj++)
                    {
                        if (tBlock == Map.BlockArray[tj, ti] && Map.BlockArray[tj, ti].Kind != CMap.Kind.Wall)
                        {

                            Map.BlockArray[tj, ti].DoBoom();
                            Map.MapArray[tj, ti] = CMap.Kind.None;
                            IsBlockBoom = true;
                        }
                    }
                }
            }
        }
        else
        {
            BoomCheck.IsBoomCheck = false;
        }
        Map.BlockNullCheck();
    }

    [Button]
    public void BoomBlockListClear()
    {
        BoomCheck.BoomBlockList.Clear();
        Debug.Log("Clear");
    }

    [Button]
    public void Array()
    {
        for (int ti = 0; ti < 9; ti++)
        {
            for (int tj = 0; tj < 9; tj++)
            {
                Debug.Log("블록: (" + tj + "," + ti + ")" + "=" + Map.BlockArray[tj, ti]);
                Debug.Log("타입: (" + tj + "," + ti + ")" + "=" + Map.MapArray[tj, ti]);

            }
        }
    }
    
}
