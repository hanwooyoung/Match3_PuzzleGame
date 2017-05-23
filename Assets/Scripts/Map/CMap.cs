using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


        for (int ti = 0; ti <Raw;ti++)
        {
            for(int tj = 0; tj <Col;tj++)
            {
                CBlock tBlock = null;
                Vector2 tVec = new Vector2((float)tj / 2 - 2, (float)ti / 2 - 2);

                if (MapArray[ti, tj] == Kind.Wall)
                {
                    tBlock = GameObject.Instantiate(BlockLoader.GetPrefab(Kind.Wall), tVec, Quaternion.identity);
                    tBlock.transform.SetParent(tParent);
                    BlockArray[ti, tj] = tBlock;
                    tBlock.BlockCoordinate.X = tj;
                    tBlock.BlockCoordinate.Y = ti;
                    tBlock.BlockCoordinate.Vec = tVec;
                }
                else if(MapArray[ti,tj] == Kind.None)
                {
                    int tRandom = 0;
                    tRandom = Random.Range(2, 7);
                    Kind tCurrentBlock = (Kind)tRandom;
                  
                    MapArray[ti, tj] = tCurrentBlock;
                    Kind tRawBlock = tCurrentBlock;


                    if (tj >= 3)
                    {
                        if (MapArray[ti, tj] == MapArray[ti, tj - 1] && MapArray[ti, tj] == MapArray[ti,tj-2])
                        {
                            do
                            {
                                tRandom = Random.Range(2, 6);
                            }
                            while (tCurrentBlock == (Kind)tRandom);

                            tCurrentBlock = (Kind)tRandom;
                            MapArray[ti, tj] = tCurrentBlock;
                            tRawBlock = tCurrentBlock;
                        }
                    }
                    if(ti >= 3)
                    {
                        if (MapArray[ti, tj] == MapArray[ti - 1, tj] && MapArray[ti, tj] == MapArray[ti - 2, tj])
                        {
                            do
                            {
                                tRandom = Random.Range(2, 6);
                            }
                            while (tCurrentBlock == (Kind)tRandom && tRawBlock == (Kind)tRandom);

                            tCurrentBlock = (Kind)tRandom;
                            MapArray[ti, tj] = tCurrentBlock;
                        }
                    }


                    tBlock = GameObject.Instantiate(BlockLoader.GetPrefab(MapArray[ti, tj]), tVec, Quaternion.identity);
                    tBlock.transform.SetParent(tParent);
                    BlockArray[ti, tj] = tBlock;
                    tBlock.BlockCoordinate.X = tj;
                    tBlock.BlockCoordinate.Y = ti;
                    tBlock.BlockCoordinate.Vec = tVec;
                }
                Debug.Log("(" + ti + "," + tj + ")"+ "=" + MapArray[ti, tj]);
            }
        }
    }

}
