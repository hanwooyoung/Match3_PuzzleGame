using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;

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

    public void IsSwap()
    {

        if (SeletBlock != null && CBlock.Move.None != SwapPos)
        {
            Vector2 SwapVec = Map.BlockArray[SeletBlock.BlockCoordinate.X - 1, SeletBlock.BlockCoordinate.Y].BlockCoordinate.Vec;

        Debug.Log("여긴옴?");


            Debug.Log("여긴옴???:"+ SwapPos);


            switch (SwapPos)
            {
                case CBlock.Move.Left:
                    Map.BlockArray[SeletBlock.BlockCoordinate.X, SeletBlock.BlockCoordinate.Y] = Map.BlockArray[SeletBlock.BlockCoordinate.X - 1, SeletBlock.BlockCoordinate.Y];
                    Map.BlockArray[SeletBlock.BlockCoordinate.X - 1, SeletBlock.BlockCoordinate.Y] = SeletBlock;
                    break;

            }

            Map.BlockArray[SeletBlock.BlockCoordinate.X, SeletBlock.BlockCoordinate.Y].transform.position = SwapVec;
            Map.BlockArray[SeletBlock.BlockCoordinate.X - 1, SeletBlock.BlockCoordinate.Y].transform.position = SeletBlock.BlockCoordinate.Vec;
        }
    }
	
    [Button]
    public void asd()
    {
        Map.BlockArray[1, 1].transform.position = new Vector2(10, 10);
    }
    

}
