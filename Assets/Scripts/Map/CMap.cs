using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CMap : MonoBehaviour {

    public const int Raw = 9;
    public const int Col = 9;

    public enum Kind
    {
        None = 0,
        Wall = 1,
        FiveBomb = 2,
        VerticalBomb = 3,
        HorizontalBomb = 4,
        Blue = 5,
        Yellow = 6,
        Green = 7,
        Gray = 8,
        Pink = 9,
    }

    public Kind[,] MapArray = null;
    public CBlock[,] BlockArray = null;
    public Vector2[,] VecArray = null;
    public CBlockLoader BlockLoader = null;
    public Transform Parent = null;
    private bool mMapIsNull = false;
    public bool MapIsNull
    {
        get
        {
            return mMapIsNull;
        }
        set
        {
            mMapIsNull = value;
        }
    }

    public void CreateMap()
    {
        BlockLoader = new CBlockLoader();
        BlockLoader.Load();

        MapArray = new Kind[Raw, Col]
         {
                {Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall},
                {Kind.Wall,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.Wall},
                {Kind.Wall,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.Wall},
                {Kind.Wall,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.Wall},
                {Kind.Wall,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.Wall},
                {Kind.Wall,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.Wall},
                {Kind.Wall,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.Wall},
                {Kind.Wall,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.None,Kind.Wall},
                {Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall,Kind.Wall}
         };
        BlockArray = new CBlock[9,9];
        VecArray = new Vector2[9, 9];


        for (int ti = 0; ti <Raw;ti++)
        {
            for(int tj = 0; tj <Col;tj++)
            {
                CBlock tBlock = null;
                Vector2 tVec = new Vector2((float)tj/(float)1.11   - (float)3.6 , (float)ti / (float)1.11 - (float)4.2);

                if (MapArray[tj, ti] == Kind.Wall)
                {
                    tBlock = GameObject.Instantiate(BlockLoader.GetPrefab(Kind.Wall), tVec, Quaternion.identity);
                    tBlock.transform.SetParent(Parent);
                    BlockArray[tj, ti] = tBlock;
                    tBlock.BlockCoordinate.X = tj;
                    tBlock.BlockCoordinate.Y = ti;
                    VecArray[tj, ti] = tVec;
                }
                else if(MapArray[tj,ti] == Kind.None)
                {
                    int tRandom = 0;
                    tRandom = Random.Range(5, 10);
                    Kind tCurrentBlock = (Kind)tRandom;
                  
                    MapArray[tj, ti] = tCurrentBlock;
                    Kind tRawBlock = tCurrentBlock;


                    if (tj >= 3)
                    {
                        if (MapArray[tj, ti] == MapArray[tj - 1, ti] && MapArray[tj, ti] == MapArray[tj - 2,ti])
                        {
                            do
                            {
                                tRandom = Random.Range(5, 10);
                            }
                            while (tCurrentBlock == (Kind)tRandom);

                            tCurrentBlock = (Kind)tRandom;
                            MapArray[tj, ti] = tCurrentBlock;
                            tRawBlock = tCurrentBlock;
                        }
                    }
                    if(ti >= 3)
                    {
                        if (MapArray[tj, ti] == MapArray[tj, ti - 1] && MapArray[tj, ti] == MapArray[tj, ti - 2])
                        {
                            do
                            {
                                tRandom = Random.Range(5, 10);
                            }
                            while (tCurrentBlock == (Kind)tRandom && tRawBlock == (Kind)tRandom);

                            tCurrentBlock = (Kind)tRandom;
                            MapArray[tj, ti] = tCurrentBlock;
                        }
                    }


                    tBlock = GameObject.Instantiate(BlockLoader.GetPrefab(MapArray[tj, ti]), tVec, Quaternion.identity);
                    tBlock.transform.SetParent(Parent);
                    BlockArray[tj, ti] = tBlock;
                    tBlock.BlockCoordinate.X = tj;
                    tBlock.BlockCoordinate.Y = ti;
                    VecArray[tj, ti] = tVec;
                }
                //Debug.Log("(" + tj + "," + ti + ")"+ "=" + MapArray[tj, ti]);
            }
        }
    }

    /// <summary>
    /// 빈곳을 찾아 블록을 아래로 정렬 해주는 함수
    /// </summary>
    /// <returns></returns>
    public IEnumerator BlockNullCheck()
    {
        for (;;)
        {
            int ti = 0;
            int tDownCount = 0;
            for (ti = 1; ti < Col; ti++)
            {
                for (int tj = 1; tj < Raw-1; tj++)
                {
                    if (BlockArray[ti, tj] == null)
                    {
                        MapIsNull = true;
                        //Debug.Log(BlockArray[ti, tj] + " ti " + ti + " tj " + tj);
                        for (int tk = 1; tk + tj < Raw-1; tk++)
                        {
                            if (BlockArray[ti, tj + tk] != null)
                            {
                                BlockArray[ti, tj + tk].transform.DOMove(VecArray[ti, tj + tDownCount], 0.3f);
                                BlockArray[ti, tj + tDownCount] = BlockArray[ti, tj + tk];
                                BlockArray[ti, tj + tk] = null;
                                BlockArray[ti, tj + tDownCount].BlockCoordinate.X = ti;
                                //Debug.Log(tj + tk);
                                BlockArray[ti, tj + tDownCount].BlockCoordinate.Y = tj + tDownCount;
                                MapArray[ti, tj + tDownCount] = MapArray[ti, tj + tk];
                                MapArray[ti, tj + tk] = Kind.None;
                                tDownCount++;
                            }

                        }
                        //ti++;
                        tDownCount = 0;
                        break;
                    }
                    else
                    {
                        //Debug.Log("안옴?");
                        MapIsNull = false;
                    }

                }
            }

            yield return new WaitForSeconds(0.0f);
        }
       

        //foreach (var tBlock in BlockArray)
        //{
        //    if (tBlock == null)
        //    {
        //        var tX = tBlock.BlockCoordinate.X;
        //        var tY = tBlock.BlockCoordinate.Y;
        //        int tN = 0;
        //        int tDownCount = 0;
        //        while (BlockArray[tX, tY + tN+1].Kind != Kind.Wall)
        //        {
        //            if(BlockArray[tX, tY + tN + 1] != null && (tY + tN + 1) < 8)
        //            {
                        
        //                BlockArray[tX, tY + tN + 1].transform.DOMove(VecArray[tX, tY + tN - tDownCount], 0.5f);
        //                BlockArray[tX, tY + tN - tDownCount] = BlockArray[tX, tY + tN + 1];
        //                BlockArray[tX, tY + tN - tDownCount].BlockCoordinate.X = tX;
        //                BlockArray[tX, tY + tN - tDownCount].BlockCoordinate.Y = tY + tN - tDownCount;
        //                MapArray[tX, tY + tN - tDownCount] = MapArray[tX, tY + tN + 1];
        //            }
        //            else
        //            {
        //                tDownCount++;
        //            }         
        //            tN++;
        //        }
        //        MapArray[tX, tY + tN] = Kind.None;
        //        //Debug.Log("Null X:" + tX + "Y: " + tY);
        //    }

        //}
    }



  



    public void SetParent(Transform tParent)
    {
        Parent = tParent;
    }

}
