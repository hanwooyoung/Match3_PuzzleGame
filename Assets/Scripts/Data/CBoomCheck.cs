using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;

public class CBoomCheck : MonoBehaviour {

    public CBlock[,] BlockArray = null;
    public CBlock SeletBlock = null;
    public CMap.Kind SeletBlockKind = CMap.Kind.None;

    public Stack<CBlock> BoomBlockList = new Stack<CBlock>();

    public int LeftBoomNumber = 0;

    private bool mIsBoomCheck = false;
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
        bool tIsResult = true;
        int LeftBoomCount = 0;

        if (SeletBlock.BlockCoordinate.X - LeftBoomNumber > 0)
        {
            while (tIsResult)
            {
                //Debug.Log("asdX" + (SeletBlock.BlockCoordinate.X - LeftBoomNumber) + "asdY" + SeletBlock.BlockCoordinate.Y);
                //Debug.Log(BlockArray[SeletBlock.BlockCoordinate.X - LeftBoomNumber, SeletBlock.BlockCoordinate.Y].Kind);

                if (SeletBlockKind == BlockArray[SeletBlock.BlockCoordinate.X - LeftBoomNumber, SeletBlock.BlockCoordinate.Y].Kind)
                {
                    //foreach (var tBlock in BoomBlockList)
                    //{
                        if (BoomBlockList.Contains(BlockArray[SeletBlock.BlockCoordinate.X - LeftBoomNumber, SeletBlock.BlockCoordinate.Y]) == false)
                        {
                            BoomBlockList.Push(BlockArray[SeletBlock.BlockCoordinate.X - LeftBoomNumber, SeletBlock.BlockCoordinate.Y]);
                            LeftBoomCount++;
                        }
                    //}
                }
                else
                {
                    tIsResult = false;
                }

                if (SeletBlock.BlockCoordinate.X - LeftBoomNumber > 0)
                {
                    //tIsResult = true;
                    LeftBoomNumber++;
                }
                else
                {
                    tIsResult = false;
                }


            }
            
        }
        if(LeftBoomCount <= 2)
        {
            IsBoomCheck = false;
            BoomBlockList.Clear();
        }
        else
        {
            IsBoomCheck = true;
        }
        LeftBoomCount = 0;
    }

    public void SetBlockArray(CBlock[,] tBlockArray)
    {
        BlockArray = tBlockArray;
    }

    public void SetSeletBlock(CBlock tSeletBlock)
    {
        SeletBlock = tSeletBlock;
        SeletBlockKind = SeletBlock.Kind;
    }
    
    public void Stack()
    {
        foreach (var ti in BoomBlockList)
        {
            Debug.Log("Stack = X: "+ti.BlockCoordinate.X +",Y: " + ti.BlockCoordinate.Y);          
        }
    }


}
