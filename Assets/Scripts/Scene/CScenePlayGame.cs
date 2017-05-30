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

    public CPossibleBoomCheck PossibleBoomCheck = null;

    private void Awake()
    {
        Map = new CMap();
        BoomCheck = new CBoomCheck();
        BoomCheck.SetBlockArray(Map.BlockArray);

        PossibleBoomCheck = new CPossibleBoomCheck();
        PossibleBoomCheck.SetMapArray(Map.MapArray);

    }

    // Use this for initialization
    void Start () {
        Map.SetParent(this.transform);
        Map.CreateMap();
        StartCoroutine(ReCreateBlock());

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
        
        PossibleBoomCheck.SetMapArray(Map.MapArray);
    }

    public void SetSwapPos(CBlock.Move tSwapPos)
    {
        SwapPos = tSwapPos;
    }

    public void SetSwapBlock(CBlock tBlock)
    {
        SeletBlock = tBlock;
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

        if (SeletBlock != null && CBlock.Move.None != SwapPos)
        {
            foreach (CBlock tBlock in Map.BlockArray)
            {
                if(tBlock == SeletBlock)
                {
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
                    

                    if (SwapPos != CBlock.Move.None)
                    {
                        SwapVec = Map.BlockArray[tBlockX + tX, tBlockY + tY].transform.position;
                        ReturnSwapVec = SwapVec;

                        tBlock.transform.DOMove(SwapVec,0.1f);
                        Map.BlockArray[tBlockX + tX, tBlockY + tY].transform.DOMove(BlockVec, 0.1f);

                        Map.BlockArray[tBlockX, tBlockY] = Map.BlockArray[tBlockX + tX, tBlockY + tY];
                        Map.BlockArray[tBlockX + tX, tBlockY + tY] = tTmepBlock;

                        Map.BlockArray[tBlockX, tBlockY].BlockCoordinate.X -= tX;
                        Map.BlockArray[tBlockX + tX, tBlockY].BlockCoordinate.X += tX;
                        Map.BlockArray[tBlockX, tBlockY].BlockCoordinate.Y -= tY;
                        Map.BlockArray[tBlockX, tBlockY + tY].BlockCoordinate.Y += tY;

                        tTmepKind = Map.MapArray[tBlockX, tBlockY];
                        Map.MapArray[tBlockX, tBlockY] = Map.MapArray[tBlockX + tX, tBlockY +tY];
                        Map.MapArray[tBlockX + tX, tBlockY + tY] = tTmepKind;

                        IsCheckUpDate();
                        if (false == BoomCheck.IsBoomCheck)
                        {
                            //tX *= -1;
                            //tY *= -1;
                            Debug.Log(ReturnBlockVec);
                            Debug.Log(ReturnSwapVec);
                            Debug.Log(tBlockX );
                            Debug.Log(tBlockY );

                            Debug.Log(tBlockX + tX);
                            Debug.Log(tBlockY + tY);



                            //SwapVec = Map.BlockArray[tBlockX + tX, tBlockY + tY].transform.position;
                         

                            //tBlock.transform.DOMove(ReturnBlockVec, 0.1f);
                            //Map.BlockArray[tBlockX + tX, tBlockY + tY].transform.DOMove(ReturnSwapVec, 0.1f);
                            

                            //Map.BlockArray[tBlockX, tBlockY] = Map.BlockArray[tBlockX + tX, tBlockY + tY];
                            //Map.BlockArray[tBlockX + tX, tBlockY + tY] = tTmepBlock;

                            //Map.BlockArray[tBlockX, tBlockY].BlockCoordinate.X -= tX;
                            //Map.BlockArray[tBlockX + tX, tBlockY].BlockCoordinate.X += tX;
                            //Map.BlockArray[tBlockX, tBlockY].BlockCoordinate.Y -= tY;
                            //Map.BlockArray[tBlockX, tBlockY + tY].BlockCoordinate.Y += tY;

                            //tTmepKind = Map.MapArray[tBlockX, tBlockY];
                            //Map.MapArray[tBlockX, tBlockY] = Map.MapArray[tBlockX + tX, tBlockY + tY];
                            //Map.MapArray[tBlockX + tX, tBlockY + tY] = tTmepKind;
                            //UnSwap(tMoveVec);
                        }
                    }
                    
                    tBlock.ReSetMove();
                }
            }
        }
    }


    public void UnSwap(Vector2 tMoveVec)
    {
        tMoveVec *=-1;
        int tX = (int)tMoveVec.x;
        int tY = (int)tMoveVec.y;
        Debug.Log("X"+tX+"Y"+tY);


  
            Debug.Log("1차");
        foreach (CBlock tBlock in Map.BlockArray)
        {

            if (tBlock == SeletBlock)
            {

                CBlock tTmepBlock = null;
                Vector2 BlockVec = Vector2.zero;
                Vector2 SwapVec = Vector2.zero;
                var tBlockX = tBlock.BlockCoordinate.X;
                var tBlockY = tBlock.BlockCoordinate.Y;
                Debug.Log("BlockX" + tBlockX);
                Debug.Log("BlockY" + tBlockY);

                CMap.Kind tTmepKind = tBlock.Kind;
                tTmepBlock = Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y];
                BlockVec = tBlock.transform.position;


                SwapVec = Map.BlockArray[tBlockX + tX, tBlockY + tY].transform.position;
                Debug.Log("SwapVec" + SwapVec);
                //if (new Vector2(tBlock.transform.position.x, tBlock.transform.position.y) == SwapVec)
                //{
                    tBlock.transform.DOMove(BlockVec, 0.1f);
                    Map.BlockArray[tBlockX + tX, tBlockY + tY].transform.DOMove(SwapVec, 0.1f);
                //}

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
        }
        
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



    public IEnumerator ReCreateBlock()
    {
        for (;;)
        {
            for (int ti = 0; ti < CMap.Raw; ti++)
            {
                for (int tj = 0; tj < CMap.Col; tj++)
                {
                    if (Map.MapArray[tj, ti] == CMap.Kind.None)
                    {
                        CBlock tBlock = null;
                        Vector2 tVec = new Vector2((float)tj / 2 - 2, (float)ti / 2 - 2);

                        int tRandom = 0;
                        tRandom = Random.Range(2, 7);
                        CMap.Kind tCurrentBlock = (CMap.Kind)tRandom;

                        Map.MapArray[tj, ti] = tCurrentBlock;
                        CMap.Kind tRawBlock = tCurrentBlock;


                        if (tj >= 3)
                        {
                            if (Map.MapArray[tj, ti] == Map.MapArray[tj - 1, ti] && Map.MapArray[tj, ti] == Map.MapArray[tj - 2, ti])
                            {
                                do
                                {
                                    tRandom = Random.Range(2, 6);
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
                                    tRandom = Random.Range(2, 6);
                                }
                                while (tCurrentBlock == (CMap.Kind)tRandom && tRawBlock == (CMap.Kind)tRandom);

                                tCurrentBlock = (CMap.Kind)tRandom;
                                Map.MapArray[tj, ti] = tCurrentBlock;
                            }
                        }


                        tBlock = GameObject.Instantiate(Map.BlockLoader.GetPrefab(Map.MapArray[tj, ti]), tVec, Quaternion.identity);
                        tBlock.transform.SetParent(this.transform);
                        Map.BlockArray[tj, ti] = tBlock;
                        Map.BlockArray[tj, ti].SetScene(this);
                        tBlock.BlockCoordinate.X = tj;
                        tBlock.BlockCoordinate.Y = ti;
                        Map.VecArray[tj, ti] = tVec;
                    }
                }
            }

            yield return new WaitForSeconds(1.0f);
        }
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
                //Debug.Log("(" + tj + "," + ti + ")" + "=" + Map.BlockArray[tj, ti]);
                Debug.Log("(" + tj + "," + ti + ")" + "=" + Map.MapArray[tj, ti]);

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
