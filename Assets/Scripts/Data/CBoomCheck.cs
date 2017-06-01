using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;

public class CBoomCheck : MonoBehaviour {

    public CBlock[,] BlockArray = null;
    public CBlock SelectBlock = null;
    public CMap.Kind SeletBlockKind = CMap.Kind.None;

    public Stack<CBlock> BoomBlockList = new Stack<CBlock>();

    //public int LeftBoomNumber = 0;
    //public int RightBoomNumber = 0;


    private bool mIsBoomCheck = true;
    public bool IsBoomCheck
    {
        get
        {
            return mIsBoomCheck;
        }
        set
        {
            mIsBoomCheck = value;
        }
    }


    public void LeftBoom()
    {
        
        if (SelectBlock.BlockCoordinate.X - 2 > 0)
        {
            if (BlockArray[SelectBlock.BlockCoordinate.X - 1, SelectBlock.BlockCoordinate.Y] == null || 
                BlockArray[SelectBlock.BlockCoordinate.X - 2, SelectBlock.BlockCoordinate.Y] == null)
            {
                Debug.Log("SelectBlock is null");
                return;
            }
            if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X - 1, SelectBlock.BlockCoordinate.Y].Kind &&
                SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X - 2, SelectBlock.BlockCoordinate.Y].Kind)
            {
                IsBoomCheck = true;
                //Debug.Log("Left");
                for (int ti = 0; SelectBlock.BlockCoordinate.X - ti > 0; ti++)
                {
                    if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X - ti, SelectBlock.BlockCoordinate.Y]) == false && ti < 3)
                    {
                        BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X - ti, SelectBlock.BlockCoordinate.Y]);
                    }
                    if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X - ti, SelectBlock.BlockCoordinate.Y].Kind && ti >= 3)
                    {
                        if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X - ti, SelectBlock.BlockCoordinate.Y]) == false)
                        {
                            BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X - ti, SelectBlock.BlockCoordinate.Y]);
                        }
                    }
                    else if (SeletBlockKind != BlockArray[SelectBlock.BlockCoordinate.X - ti, SelectBlock.BlockCoordinate.Y].Kind)
                    {
                        break;
                    }
                }
            }
        }
    }

    public void RightBoom()
    {
        

        if (SelectBlock.BlockCoordinate.X + 2 < CMap.Col)
        {
            if (BlockArray[SelectBlock.BlockCoordinate.X + 1, SelectBlock.BlockCoordinate.Y] == null || 
                BlockArray[SelectBlock.BlockCoordinate.X + 2, SelectBlock.BlockCoordinate.Y] == null)
            {
                Debug.Log("SelectBlock is null");
                return;
            }

            if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X + 1, SelectBlock.BlockCoordinate.Y].Kind &&
                SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X + 2, SelectBlock.BlockCoordinate.Y].Kind)
            {
                IsBoomCheck = true;
                //Debug.Log("Right");

                for (int ti = 0; SelectBlock.BlockCoordinate.X + ti < CMap.Col; ti++)
                {
                    if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X + ti, SelectBlock.BlockCoordinate.Y]) == false && ti < 3)
                    {
                        BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X + ti, SelectBlock.BlockCoordinate.Y]);
                    }
                    if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X + ti, SelectBlock.BlockCoordinate.Y].Kind && ti >= 3)
                    {
                        if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X + ti, SelectBlock.BlockCoordinate.Y]) == false)
                        {
                            BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X + ti, SelectBlock.BlockCoordinate.Y]);
                        }
                    }
                    else if(SeletBlockKind != BlockArray[SelectBlock.BlockCoordinate.X + ti, SelectBlock.BlockCoordinate.Y].Kind)
                    {
                        break;
                    }
                }
            }
        }
    }
   
    public void SideXBoom()
    {
        
        if (SelectBlock.BlockCoordinate.X + 1 < CMap.Col-1 && SelectBlock.BlockCoordinate.X - 1 > 0)
        {
            if (BlockArray[SelectBlock.BlockCoordinate.X + 1, SelectBlock.BlockCoordinate.Y] == null ||
                BlockArray[SelectBlock.BlockCoordinate.X - 1, SelectBlock.BlockCoordinate.Y] == null)
            {
                Debug.Log("SelectBlock is null");
                return;
            }

            if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X + 1, SelectBlock.BlockCoordinate.Y].Kind &&
                SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X - 1, SelectBlock.BlockCoordinate.Y].Kind)
            {
                IsBoomCheck = true;
                //Debug.Log("SideX");

                int tNumber = 0;

                for (int ti = 0; ti < 10; ti++)
                {                   
                    int tMinus = 1;
                    if (ti % 2 == 0)
                    {
                        tMinus *= -1;
                    }
                    if (SelectBlock.BlockCoordinate.X + (tNumber * tMinus) > 0 && SelectBlock.BlockCoordinate.X + (tNumber * tMinus) < CMap.Col)
                    {
                        if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X + (tNumber * tMinus), SelectBlock.BlockCoordinate.Y]) == false && ti < 3)
                        {
                            BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X + (tNumber * tMinus), SelectBlock.BlockCoordinate.Y]);
                        }

                        if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X + (tNumber * tMinus), SelectBlock.BlockCoordinate.Y].Kind && ti >= 3)
                        {
                            if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X + (tNumber * tMinus), SelectBlock.BlockCoordinate.Y]) == false)
                            {
                                BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X + (tNumber * tMinus), SelectBlock.BlockCoordinate.Y]);
                            }

                        }
                        else if (SeletBlockKind != BlockArray[SelectBlock.BlockCoordinate.X + (tNumber * tMinus), SelectBlock.BlockCoordinate.Y].Kind)
                        {
                            break;
                        }
                    }



                    if (ti % 2 == 0 || ti == 0)
                    {
                        tNumber++;
                    }
                }
            }
        }
    }


    public void UpBoom()
    {
        

        if (SelectBlock.BlockCoordinate.Y + 2 < CMap.Col && SeletBlockKind != CMap.Kind.None)
        {
            if (BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + 1] == null ||
                BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + 2] == null)
            {
                Debug.Log("SelectBlock is null");
                return;
            }
            if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + 1].Kind &&
                SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + 2].Kind)
            {
                IsBoomCheck = true;
                //Debug.Log("Up");

                for (int ti = 0; SelectBlock.BlockCoordinate.Y + ti < CMap.Raw; ti++)
                {
                    if (SelectBlock == null)
                    {
                        Debug.Log("SelectBlock is null");
                        return;
                    }
                    if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + ti]) == false && ti < 3)
                    {
                        BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + ti]);
                    }
                    if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + ti].Kind && ti >= 3)
                    {
                        if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + ti]) == false)
                        {
                            BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + ti]);
                        }
                    }
                    else if (SeletBlockKind != BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + ti].Kind)
                    {
                        break;
                    }
                }
            }
        }
    }

    public void DownBoom()
    {

        if (SelectBlock.BlockCoordinate.Y - 2 > 0 && SeletBlockKind != CMap.Kind.None)
        {
            if (BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y - 1] == null ||
                BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y - 2] == null)
            {
                Debug.Log("SelectBlock is null");
                return;
            }
            if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y - 1].Kind &&
                SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y - 2].Kind)
            {
                IsBoomCheck = true;
                //Debug.Log("Down");
                for (int ti = 0; SelectBlock.BlockCoordinate.Y - ti > 0; ti++)
                {
                    if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y - ti]) == false && ti < 3)
                    {
                        BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y - ti]);
                    }
                    if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y - ti].Kind && ti >= 3)
                    {
                        if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y - ti]) == false)
                        {
                            BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y - ti]);
                        }
                    }
                    else if (SeletBlockKind != BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y - ti].Kind)
                    {
                        break;
                    }
                }
            }
        }
    }


    public void SideYBoom()
    {

        if (SelectBlock.BlockCoordinate.Y + 1 < CMap.Raw - 1 && SelectBlock.BlockCoordinate.Y - 1 > 0)
        {
            if (BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + 1] == null ||
                BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y - 1] == null)
            {
                Debug.Log("SelectBlock is null");
                return;
            }
            if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y + 1].Kind &&
                SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y - 1].Kind)
            {
                IsBoomCheck = true;
                //Debug.Log("SideY");

                int tNumber = 0;

                for (int ti = 0; ti < 10; ti++)
                {
                    int tMinus = 1;
                    if (ti % 2 == 0)
                    {
                        tMinus *= -1;
                    }
                    if (SelectBlock.BlockCoordinate.Y + (tNumber * tMinus) > 0 && SelectBlock.BlockCoordinate.Y + (tNumber * tMinus) < CMap.Col)
                    {
                        if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y + (tNumber * tMinus)]) == false && ti < 3)
                        {
                            BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y + (tNumber * tMinus)]);
                        }

                        if (SeletBlockKind == BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y + (tNumber * tMinus)].Kind && ti >= 3)
                        {
                            if (BoomBlockList.Contains(BlockArray[SelectBlock.BlockCoordinate.X , SelectBlock.BlockCoordinate.Y + (tNumber * tMinus)]) == false)
                            {
                                BoomBlockList.Push(BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + (tNumber * tMinus)]);
                            }

                        }
                        else if (SeletBlockKind != BlockArray[SelectBlock.BlockCoordinate.X, SelectBlock.BlockCoordinate.Y + (tNumber * tMinus)].Kind)
                        {
                            break;
                        }
                    }

                    if (ti % 2 == 0 || ti == 0)
                    {
                        tNumber++;
                    }
                }
            }
        }
    }

    public void SetBlockArray(CBlock[,] tBlockArray)
    {
        BlockArray = tBlockArray;
    }

    public void SetSeletBlock(CBlock tSelectBlock)
    {
        SelectBlock = tSelectBlock;
        SeletBlockKind = SelectBlock.Kind;
        if(SeletBlockKind == CMap.Kind.Wall)
        {
            SeletBlockKind = CMap.Kind.None;
        }
    }
    
    public void Stack()
    {
        foreach (var ti in BoomBlockList)
        {
            //Debug.Log(ti + "Stack = X: "+ti.BlockCoordinate.X +",Y: " + ti.BlockCoordinate.Y);          
        }
    }

    public void BoomBlockListClear()
    {
        BoomBlockList.Clear();
    }
}
