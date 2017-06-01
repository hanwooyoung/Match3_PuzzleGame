using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inspector;

public class CNormalBlcok : CBlock {

    public Vector2 OnClickVec;
    public Vector2 OnDragVec;
    public Vector2 MoveVec;


 

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
        if (this.Kind != CMap.Kind.Wall )
        {
            IsClick = true;
            OnClickVec = Input.mousePosition;
            //OnClickVec = new Vector2(this.transform.position.x, this.transform.position.y);
            if (ScenePlayGeme.IsDontMove == false)
                ScenePlayGeme.SetSelectBlock(this);
        }
    }

    private void OnMouseDrag()
    {
        if (true == Input.GetMouseButton(0))
        {
            OnDragVec = Input.mousePosition;
            if (ScenePlayGeme.IsDontMove == false)
                MoveVec = OnDragVec - OnClickVec;

        }
    }

    private void OnMouseUp()
    {
        if(this.Kind != CMap.Kind.Wall)
        {
            if (MoveVec.x < 0 && MoveVec.y >= -45 && MoveVec.y <= 45)
            {
                BlockMove = Move.Left;
                MoveVec = Vector2.left;
                //Debug.Log("Left");
            }
            else if (MoveVec.x > 0 && MoveVec.y >= -45 && MoveVec.y <= 45)
            {
                BlockMove = Move.Right;
                MoveVec = Vector2.right;
                //Debug.Log("Right");

            }
            else if (MoveVec.y > 0 && MoveVec.x >= -45 && MoveVec.x <= 45)
            {
                BlockMove = Move.Up;
                MoveVec = Vector2.up;
                //Debug.Log("Up");
            }
            else if (MoveVec.y < 0 && MoveVec.x >= -45 && MoveVec.x <= 45)
            {
                BlockMove = Move.Down;
                MoveVec = Vector2.down;
                //Debug.Log("Down");
            }

            if (ScenePlayGeme.IsDontMove == false)
            {
                ScenePlayGeme.SetSwapPos(BlockMove);
                ScenePlayGeme.SetMoveVec(MoveVec);
            }
            //ScenePlayGeme.DoSwap(MoveVec);
            //ReSetMove();

            IsClick = false;

            //MoveVec = Vector2.zero;
            //ScenePlayGeme.SetMoveVec(MoveVec);

        }


    }

  

    [Button]
    public void Xy()
    {
        Debug.Log("X"+ BlockCoordinate.X);
        Debug.Log("Y" + BlockCoordinate.Y);
    }




}
