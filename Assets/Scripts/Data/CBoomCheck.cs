using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;

public class CBoomCheck : MonoBehaviour {

    public CBlock[,] BlockArray = null;
    public CBlock SeletBlock = null;
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
        if (SeletBlock.BlockCoordinate.X - 2 > 0)
        {
            if (SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X - 1, SeletBlock.BlockCoordinate.Y].Kind &&
                SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X - 2, SeletBlock.BlockCoordinate.Y].Kind)
            {
                Debug.Log("Left");
                for (int ti = 0; SeletBlock.BlockCoordinate.X - ti > 0; ti++)
                {
                    if (BoomBlockList.Contains(BlockArray[SeletBlock.BlockCoordinate.X - ti, SeletBlock.BlockCoordinate.Y]) == false && ti < 3)
                    {
                        BoomBlockList.Push(BlockArray[SeletBlock.BlockCoordinate.X - ti, SeletBlock.BlockCoordinate.Y]);
                    }
                    if (SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X - ti, SeletBlock.BlockCoordinate.Y].Kind && ti >= 3)
                    {
                        if (BoomBlockList.Contains(BlockArray[SeletBlock.BlockCoordinate.X - ti, SeletBlock.BlockCoordinate.Y]) == false)
                        {
                            BoomBlockList.Push(BlockArray[SeletBlock.BlockCoordinate.X - ti, SeletBlock.BlockCoordinate.Y]);
                        }
                    }
                    else if (SeletBlockKind != BlockArray[SeletBlock.BlockCoordinate.X - ti, SeletBlock.BlockCoordinate.Y].Kind)
                    {
                        break;
                    }
                }
            }
        }
    }


    public void RightBoom()
    {
        
        if (SeletBlock.BlockCoordinate.X + 2 < CMap.Col)
        {
            if (SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X + 1, SeletBlock.BlockCoordinate.Y].Kind &&
                SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X + 2, SeletBlock.BlockCoordinate.Y].Kind)
            {
                Debug.Log("Right");

                for (int ti = 0; SeletBlock.BlockCoordinate.X + ti < CMap.Col; ti++)
                {
                    if (BoomBlockList.Contains(BlockArray[SeletBlock.BlockCoordinate.X + ti, SeletBlock.BlockCoordinate.Y]) == false && ti < 3)
                    {
                        BoomBlockList.Push(BlockArray[SeletBlock.BlockCoordinate.X + ti, SeletBlock.BlockCoordinate.Y]);
                    }
                    if (SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X + ti, SeletBlock.BlockCoordinate.Y].Kind && ti >= 3)
                    {
                        if (BoomBlockList.Contains(BlockArray[SeletBlock.BlockCoordinate.X + ti, SeletBlock.BlockCoordinate.Y]) == false)
                        {
                            BoomBlockList.Push(BlockArray[SeletBlock.BlockCoordinate.X + ti, SeletBlock.BlockCoordinate.Y]);
                        }
                    }
                    else if(SeletBlockKind != BlockArray[SeletBlock.BlockCoordinate.X + ti, SeletBlock.BlockCoordinate.Y].Kind)
                    {
                        break;
                    }
                }
            }
        }

    }


    public void SideXBoom()
    {

        if (SeletBlock.BlockCoordinate.X + 1 < CMap.Col && SeletBlock.BlockCoordinate.X - 1 > 0)
        {
            if (SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X + 1, SeletBlock.BlockCoordinate.Y].Kind &&
                SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X - 1, SeletBlock.BlockCoordinate.Y].Kind)
            {
                Debug.Log("Side");

                int tNumber = 0;

                for (int ti = 0; SeletBlock.BlockCoordinate.X + tNumber  < CMap.Col; ti++)
                {                   
                    int tMinus = 1;
                    if (ti % 2 == 0)
                    {
                        tMinus *= -1;
                    }

                    if (BoomBlockList.Contains(BlockArray[SeletBlock.BlockCoordinate.X + (tNumber * tMinus), SeletBlock.BlockCoordinate.Y]) == false && ti < 3)
                    {
                        BoomBlockList.Push(BlockArray[SeletBlock.BlockCoordinate.X + (tNumber * tMinus), SeletBlock.BlockCoordinate.Y]);
                    }
                    if (SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X + (tNumber * tMinus), SeletBlock.BlockCoordinate.Y].Kind && ti >= 3 && SeletBlock.BlockCoordinate.X - tNumber >0)
                    {
                        if (BoomBlockList.Contains(BlockArray[SeletBlock.BlockCoordinate.X + (tNumber * tMinus), SeletBlock.BlockCoordinate.Y]) == false)
                        {
                            BoomBlockList.Push(BlockArray[SeletBlock.BlockCoordinate.X + (tNumber * tMinus), SeletBlock.BlockCoordinate.Y]);
                        }
                    }
                    else if (SeletBlockKind != BlockArray[SeletBlock.BlockCoordinate.X + (tNumber * tMinus), SeletBlock.BlockCoordinate.Y].Kind)
                    {
                        break;
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

    public void SetSeletBlock(CBlock tSeletBlock)
    {
        SeletBlock = tSeletBlock;
        SeletBlockKind = SeletBlock.Kind;
        if(SeletBlockKind == CMap.Kind.Wall)
        {
            SeletBlockKind = CMap.Kind.None;
        }
    }
    
    public void Stack()
    {
        foreach (var ti in BoomBlockList)
        {
            Debug.Log("Stack = X: "+ti.BlockCoordinate.X +",Y: " + ti.BlockCoordinate.Y);          
        }
    }


}
