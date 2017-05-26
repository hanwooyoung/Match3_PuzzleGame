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
        Blue = 2,
        Yellow = 3,
        Green = 4,
        Gray = 5,
        Pink = 6,
    }

    public Kind[,] MapArray = null;
    public CBlock[,] BlockArray = null;
    public Vector2[,] VecArray = null;
    public CBlockLoader BlockLoader = null;


    public void CreateMap(Transform tParent)
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
                Vector2 tVec = new Vector2((float)tj / 2 - 2, (float)ti / 2 - 2);

                if (MapArray[tj, ti] == Kind.Wall)
                {
                    tBlock = GameObject.Instantiate(BlockLoader.GetPrefab(Kind.Wall), tVec, Quaternion.identity);
                    tBlock.transform.SetParent(tParent);
                    BlockArray[tj, ti] = tBlock;
                    tBlock.BlockCoordinate.X = tj;
                    tBlock.BlockCoordinate.Y = ti;
                    VecArray[tj, ti] = tVec;
                }
                else if(MapArray[tj,ti] == Kind.None)
                {
                    int tRandom = 0;
                    tRandom = Random.Range(2, 7);
                    Kind tCurrentBlock = (Kind)tRandom;
                  
                    MapArray[tj, ti] = tCurrentBlock;
                    Kind tRawBlock = tCurrentBlock;


                    if (tj >= 3)
                    {
                        if (MapArray[tj, ti] == MapArray[tj - 1, ti] && MapArray[tj, ti] == MapArray[tj - 2,ti])
                        {
                            do
                            {
                                tRandom = Random.Range(2, 6);
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
                                tRandom = Random.Range(2, 6);
                            }
                            while (tCurrentBlock == (Kind)tRandom && tRawBlock == (Kind)tRandom);

                            tCurrentBlock = (Kind)tRandom;
                            MapArray[tj, ti] = tCurrentBlock;
                        }
                    }


                    tBlock = GameObject.Instantiate(BlockLoader.GetPrefab(MapArray[tj, ti]), tVec, Quaternion.identity);
                    tBlock.transform.SetParent(tParent);
                    BlockArray[tj, ti] = tBlock;
                    tBlock.BlockCoordinate.X = tj;
                    tBlock.BlockCoordinate.Y = ti;
                    VecArray[tj, ti] = tVec;
                }
                Debug.Log("(" + tj + "," + ti + ")"+ "=" + MapArray[tj, ti]);
            }
        }
    }


    public void BlockNullCheck()
    {
        foreach (var ti in BlockArray)
        {
            if (ti == null)
            {
                var tX = ti.BlockCoordinate.X;
                var tY = ti.BlockCoordinate.Y;
                int tN = 0;

                while ((tY + tN + 1) < 8)
                {
                    BlockArray[tX, tY + tN + 1].transform.DOMove(VecArray[tX, tY + tN], 0.5f);
                    tN++;
                }
                //Debug.Log("Null X:" + tX + "Y: " + tY);
            }
        }
    }

}
