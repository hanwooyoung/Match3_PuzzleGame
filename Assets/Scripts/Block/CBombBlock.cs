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
                for (int ti = 0; ti < CMap.Raw; ti++)
                {
                    ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[this.BlockCoordinate.X,ti]);
                    if(ScenePlayGeme.Map.BlockArray[this.BlockCoordinate.X, ti].Kind == CMap.Kind.HorizontalBomb)
                    {
                        CBlock tHorizontalBlock = ScenePlayGeme.Map.BlockArray[this.BlockCoordinate.X, ti];
                        for (int tj = 0; tj < CMap.Col; tj++)
                        {
                            ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tj, tHorizontalBlock.BlockCoordinate.Y]);
                        }
                    }
                }
                break;
            case CMap.Kind.HorizontalBomb:
                for (int tj = 0; tj < CMap.Col; tj++)
                {
                    ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tj, this.BlockCoordinate.Y]);

                    if (ScenePlayGeme.Map.BlockArray[tj, this.BlockCoordinate.Y].Kind == CMap.Kind.VerticalBomb)
                    {
                        CBlock tVerticalBlock = ScenePlayGeme.Map.BlockArray[tj, this.BlockCoordinate.Y];
                        for (int ti = 0; ti < CMap.Col; ti++)
                        {
                            ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[tVerticalBlock.BlockCoordinate.X, ti]);
                        }
                    }
                }
                break;
            case CMap.Kind.FiveBomb:
                int tNumber = 0;

                for (int ti = 0; ti <= 4; ti++)
                {
                    int tMinus = 1;
                    if (ti % 2 == 0)
                    {
                        tMinus *= -1;
                    }
                    if (this.BlockCoordinate.X + (tNumber * tMinus) > 0 && this.BlockCoordinate.X + (tNumber * tMinus) < CMap.Col &&
                        this.BlockCoordinate.Y + (tNumber * tMinus) > 0 && this.BlockCoordinate.Y + (tNumber * tMinus) < CMap.Raw)
                    {
                        ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[this.BlockCoordinate.X + (tNumber * tMinus), this.BlockCoordinate.Y]);
                        ScenePlayGeme.BoomCheck.BoomBlockList.Push(ScenePlayGeme.Map.BlockArray[this.BlockCoordinate.X, this.BlockCoordinate.Y + (tNumber * tMinus)]);
                    }
                   
                }
                    break;
        }
    }



    [Button]
    public void Xy()
    {
        Debug.Log("X" + BlockCoordinate.X);
        Debug.Log("Y" + BlockCoordinate.Y);
    }
}
