using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNormalBlcok : CBlock {

    public Vector2 OnClickVec;
    public Vector2 OnDragVec;
    public Vector2 MoveVec;


    public Move BlockMove = Move.None; 

    private bool mIsClick = false;
    public bool IsClick
    {
        get
        {
            return mIsClick;
        }
        set
        {
            mIsClick = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}


    private void OnMouseDown()
    {
        Debug.Log("나는야" + "X:" + BlockCoordinate.X + "Y:" + BlockCoordinate.Y);
        IsClick = true;
        OnClickVec = Input.mousePosition;
        ScenePlayGeme.SetSwapBlock(this);
    }

    private void OnMouseDrag()
    {
        if (true == Input.GetMouseButton(0))
        {
            OnDragVec = Input.mousePosition;

            MoveVec = OnDragVec - OnClickVec;

        }
    }

    private void OnMouseUp()
    {
        if (MoveVec.x < 0 && MoveVec.y >= -45 && MoveVec.y <= 45)
        {
            BlockMove = Move.Left;
            Debug.Log("Left");
            

        }
        else if (MoveVec.x > 0 && MoveVec.y >= -45 && MoveVec.y <= 45)
        {
            BlockMove = Move.Right;
            Debug.Log("Right");

        }
        else if (MoveVec.y > 0 && MoveVec.x >= -45 && MoveVec.x <= 45)
        {
            BlockMove = Move.Up;
            Debug.Log("Up");
        }
        else if (MoveVec.y < 0 && MoveVec.x >= -45 && MoveVec.x <= 45)
        {
            BlockMove = Move.Down;
            Debug.Log("Down");
        }

       
        ScenePlayGeme.SetSwapPos(BlockMove);
        ScenePlayGeme.IsSwap();
        IsClick = false;
        

        MoveVec = Vector2.zero;

    }

    
}
