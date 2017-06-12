using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;

public class CBombBlock : CBlock {



    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseUp()
    {
        switch(Kind)
        {
            case CMap.Kind.VerticalBomb:
                BoomVerticalBomb(this);
                break;
            case CMap.Kind.HorizontalBomb:
                BoomHorizontalBomb(this);
                break;
            case CMap.Kind.FiveBomb:
                BoomFiveBomb(this);
                break;
        }
    }

    public void BoomVerticalBomb(CBlock tBlock)
    {
        for (int ti = 1; ti < CMap.Raw-1; ti++)
        {
            if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti]) == false)
            {
                ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti]);
            }
            if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti].Kind == CMap.Kind.HorizontalBomb)
            {
                CBlock tHorizontalBlock = ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti];
                for (int tj = 1; tj < CMap.Col-1; tj++)
                {
                    if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tj, tHorizontalBlock.BlockCoordinate.Y]) == false)
                    {
                        ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tj, tHorizontalBlock.BlockCoordinate.Y]);
                    }
                }
            }
            if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti].Kind == CMap.Kind.FiveBomb)
            {
                BoomFiveBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti]);
            }
        }
    }

    public void BoomHorizontalBomb(CBlock tBlock)
    {
        for (int tj = 1; tj < CMap.Col-1; tj++)
        {
            if(ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y]) == false)
            {
                ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y]);
            }
            

            if (ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y].Kind == CMap.Kind.VerticalBomb)
            {
                CBlock tVerticalBlock = ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y];
                for (int ti = 1; ti < CMap.Col-1; ti++)
                {
                    if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tVerticalBlock.BlockCoordinate.X, ti]) == false)
                    {
                        ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tVerticalBlock.BlockCoordinate.X, ti]);
                    }
                }
            }
            if (ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y].Kind == CMap.Kind.FiveBomb)
            {
                BoomFiveBomb(ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y]);
            }
        }
    }

    public void BoomFiveBomb(CBlock tBlock)
    {
        int tNumber = 0;
        List<CBlock> BoomList = new List<CBlock>();

        for (int ti = 0; ti <= 4; ti++)
        {
            int tMinus = 1;
            if (ti % 2 == 0)
            {
                tMinus *= -1;
            }
            if (tBlock.BlockCoordinate.X + (tNumber * tMinus) > 0 && tBlock.BlockCoordinate.X + (tNumber * tMinus) < CMap.Col)
            {
                if(ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + (tNumber * tMinus), tBlock.BlockCoordinate.Y]) == false)
                {
                    ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + (tNumber * tMinus), tBlock.BlockCoordinate.Y]);
                }
                //BoomList.Add(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + (tNumber * tMinus), tBlock.BlockCoordinate.Y]);
            }
            if (tBlock.BlockCoordinate.Y + (tNumber * tMinus) > 0 && tBlock.BlockCoordinate.Y + (tNumber * tMinus) < CMap.Raw)
            {
                if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y + (tNumber * tMinus)]) == false)
                {
                    ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y + (tNumber * tMinus)]);
                }
                //BoomList.Add(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y + (tNumber * tMinus)]);
            }

            if (ti % 2 == 0 || ti == 0)
            {
                tNumber++;
            }

        }
        if (tBlock.BlockCoordinate.X + 1 < CMap.Col  && tBlock.BlockCoordinate.X - 1 > 0 &&
            tBlock.BlockCoordinate.Y + 1 < CMap.Raw  && tBlock.BlockCoordinate.Y - 1 > 0)
        {
            if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + 1]) == false)
            {
                ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + 1]);
            }
            if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y - 1]) == false)
            {
                ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y - 1]);
            }
            if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + 1]) == false)
            {
                ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + 1]);
            }
            if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y - 1]) == false)
            {
                ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y - 1]);
            }
            //BoomList.Add(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + 1]);
            //BoomList.Add(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y - 1]);
            //BoomList.Add(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + 1]);
            //BoomList.Add(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y - 1]);

        }

        //foreach(CBlock Block in BoomList)
        //{
        //    if(Block.Kind == CMap.Kind.HorizontalBomb)
        //    {
        //        BoomHorizontalBomb(Block);
        //    }
        //    if(Block.Kind == CMap.Kind.VerticalBomb)
        //    {
        //        BoomVerticalBomb(Block);
        //    }
        //    if(ScenePlayGeme.BoomCheck.BoomBlockList.Contains(Block) == false)
        //    {
        //        ScenePlayGeme.BoomCheck.BoomBlockList.Push(Block);
        //    }
        //}


    }


    [Button]
    public void Xy()
    {
        Debug.Log("X" + BlockCoordinate.X);
        Debug.Log("Y" + BlockCoordinate.Y);
    }
}
