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
        }
    }



    [Button]
    public void Xy()
    {
        Debug.Log("X" + BlockCoordinate.X);
        Debug.Log("Y" + BlockCoordinate.Y);
    }
}
