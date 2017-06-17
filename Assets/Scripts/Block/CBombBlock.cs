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
        if (ScenePlayGeme.IsBlockDontTouch == false)
        {
            switch (Kind)
            {
                case CMap.Kind.VerticalBomb:
                    BoomVerticalBomb(this);
                    ScenePlayGeme.CurrentHp.Value += 3;
                    break;
                case CMap.Kind.HorizontalBomb:
                    BoomHorizontalBomb(this);
                    ScenePlayGeme.CurrentHp.Value += 3;
                    break;
                case CMap.Kind.FiveBomb:
                    BoomFiveBomb(this);
                    ScenePlayGeme.CurrentHp.Value += 4;
                    break;
            }
            
        }
        //BoomCheck();
    }

    public void BoomVerticalBomb(CBlock tBlock)
    {
        for (int ti = 1; ti < CMap.Raw-1; ti++)
        {
            if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti]) == false)
            {
                if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti].Kind != CMap.Kind.FiveBomb)
                {
                    ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti]);
                }
            }
            if(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti].Kind == CMap.Kind.HorizontalBomb)
            {
                BoomHorizontalBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti]);
            }
            //if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti].Kind == CMap.Kind.HorizontalBomb)
            //{
            //    CBlock tHorizontalBlock = ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti];
            //    for (int tj = 1; tj < CMap.Col - 1; tj++)
            //    {
            //        if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tj, tHorizontalBlock.BlockCoordinate.Y]) == false)
            //        {
            //            ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tj, tHorizontalBlock.BlockCoordinate.Y]);
            //        }
            //    }
            //}
            //if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti].Kind == CMap.Kind.FiveBomb)
            //{
            //    BoomFiveBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, ti]);
            //}
        }
    }

    public void BoomHorizontalBomb(CBlock tBlock)
    {
        for (int tj = 1; tj < CMap.Col-1; tj++)
        {
            if(ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y]) == false)
            {
                if(ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y].Kind != CMap.Kind.FiveBomb)
                {
                    ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y]);
                }
            }
            if (ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y].Kind == CMap.Kind.VerticalBomb)
            {
                BoomVerticalBomb(ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y]);
            }

            //if (ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y].Kind == CMap.Kind.VerticalBomb)
            //{
            //    CBlock tVerticalBlock = ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y];
            //    for (int ti = 1; ti < CMap.Col - 1; ti++)
            //    {
            //        if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tVerticalBlock.BlockCoordinate.X, ti]) == false)
            //        {
            //            ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tVerticalBlock.BlockCoordinate.X, ti]);
            //        }
            //    }
            //}
            //if (ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y].Kind == CMap.Kind.FiveBomb)
            //{
            //    BoomFiveBomb(ScenePlayGeme.Map.BlockArray[tj, tBlock.BlockCoordinate.Y]);
            //}
        }
    }

    public void BoomFiveBomb(CBlock tBlock)
    {
        //int tNumber = 0;
        for(int tj = 0; tj <3;tj++)
        {
            switch(tj)
            {
                case 0:
                    if(tBlock.BlockCoordinate.X-2>0 )
                    {
                        if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 2, tBlock.BlockCoordinate.Y].Kind == CMap.Kind.VerticalBomb)
                        {
                            BoomVerticalBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 2, tBlock.BlockCoordinate.Y]);
                        }
                        if(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 2, tBlock.BlockCoordinate.Y].Kind == CMap.Kind.HorizontalBomb)
                        {
                            BoomHorizontalBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 2, tBlock.BlockCoordinate.Y]);
                        }


                        if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 2, tBlock.BlockCoordinate.Y]) == false)
                        {
                            ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 2, tBlock.BlockCoordinate.Y]);
                        }
                        
                       
                    }
                    if(tBlock.BlockCoordinate.X + 2 < CMap.Col)
                    {

                        if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 2, tBlock.BlockCoordinate.Y].Kind == CMap.Kind.VerticalBomb)
                        {
                            BoomVerticalBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 2, tBlock.BlockCoordinate.Y]);
                        }
                        if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 2, tBlock.BlockCoordinate.Y].Kind == CMap.Kind.HorizontalBomb)
                        {
                            BoomHorizontalBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 2, tBlock.BlockCoordinate.Y]);
                        }


                        if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 2, tBlock.BlockCoordinate.Y]) == false)
                        {
                            ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 2, tBlock.BlockCoordinate.Y]);
                        }
                    }
                    break;
                case 1:

                    for (int ti = 0; ti < 3; ti++)
                    {
                        if (tBlock.BlockCoordinate.X - 1 > 0 && tBlock.BlockCoordinate.Y + ti - 1 > 0 && tBlock.BlockCoordinate.Y + ti - 1<CMap.Raw)
                        {

                            if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + ti - 1].Kind == CMap.Kind.VerticalBomb)
                            {
                                BoomVerticalBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + ti - 1]);
                            }
                            if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + ti - 1].Kind == CMap.Kind.HorizontalBomb)
                            {
                                BoomHorizontalBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + ti - 1]);
                            }


                            if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + ti - 1]) == false)
                            {
                                ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + ti - 1]);
                            }
                        }
                        if (tBlock.BlockCoordinate.X + 1 < CMap.Col - 1 && tBlock.BlockCoordinate.Y + ti - 1 > 0 && tBlock.BlockCoordinate.Y + ti - 1 < CMap.Raw)
                        {
                            if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + ti - 1].Kind == CMap.Kind.VerticalBomb)
                            {
                                BoomVerticalBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + ti - 1]);
                            }
                            if (ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + ti - 1].Kind == CMap.Kind.HorizontalBomb)
                            {
                                BoomHorizontalBomb(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + ti - 1]);
                            }



                            if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + ti - 1]) == false)
                            {
                                ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + ti - 1]);
                            }
                        }
                    }
                    break;
                case 2:

                    for (int ti = 0; ti < 5; ti++)
                    {
                        if (tBlock.BlockCoordinate.Y + ti - 2 > 0 && tBlock.BlockCoordinate.Y + ti - 2 < CMap.Raw - 1)
                        {
                            if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y + ti - 2]) == false)
                            {
                                ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y + ti - 2]);
                            }
                        }
                    }
                  
                        break;
            }
        }

        //for (int ti = 0; ti <= 4; ti++)
        //{
        //    int tMinus = 1;
        //    if (ti % 2 == 0)
        //    {
        //        tMinus *= -1;
        //    }
        //    if (tBlock.BlockCoordinate.X + (tNumber * tMinus) > 0 && tBlock.BlockCoordinate.X + (tNumber * tMinus) < CMap.Col)
        //    {
        //        if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + (tNumber * tMinus), tBlock.BlockCoordinate.Y]) == false)
        //        {
        //            ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + (tNumber * tMinus), tBlock.BlockCoordinate.Y]);
        //        }

        //    }
        //    if (tBlock.BlockCoordinate.Y + (tNumber * tMinus) > 0 && tBlock.BlockCoordinate.Y + (tNumber * tMinus) < CMap.Raw)
        //    {
        //        if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y + (tNumber * tMinus)]) == false)
        //        {
        //            ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X, tBlock.BlockCoordinate.Y + (tNumber * tMinus)]);
        //        }
        //    }

        //    if (ti % 2 == 0 || ti == 0)
        //    {
        //        tNumber++;
        //    }

        //}

        //if (tBlock.BlockCoordinate.X + 1 < CMap.Col  && tBlock.BlockCoordinate.X - 1 > 0 &&
        //    tBlock.BlockCoordinate.Y + 1 < CMap.Raw  && tBlock.BlockCoordinate.Y - 1 > 0)
        //{
        //    if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + 1]) == false)
        //    {
        //        ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y + 1]);
        //    }
        //    if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y - 1]) == false)
        //    {
        //        ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X + 1, tBlock.BlockCoordinate.Y - 1]);
        //    }
        //    if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + 1]) == false)
        //    {
        //        ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y + 1]);
        //    }
        //    if (ScenePlayGeme.BoomCheck.BoomBlockList.Contains(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y - 1]) == false)
        //    {
        //        ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tBlock.BlockCoordinate.X - 1, tBlock.BlockCoordinate.Y - 1]);
        //    }


        //}



    }


    public void BoomCheck()
    {
        foreach(var tBlock in ScenePlayGeme.BoomCheck.BoomBlockList)
        {
            if(tBlock.Kind == CMap.Kind.HorizontalBomb)
            {
                BoomHorizontalBomb(tBlock);
            }
            if(tBlock.Kind == CMap.Kind.VerticalBomb)
            {
                BoomVerticalBomb(tBlock);
            }
            if(tBlock.Kind == CMap.Kind.FiveBomb)
            {
                BoomFiveBomb(tBlock);
            }
        }
    }

    [Button]
    public void Xy()
    {
        Debug.Log("X" + BlockCoordinate.X);
        Debug.Log("Y" + BlockCoordinate.Y);
    }
}
