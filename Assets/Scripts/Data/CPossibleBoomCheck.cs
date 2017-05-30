using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPossibleBoomCheck : MonoBehaviour {

    public CMap.Kind[,] MapArray = null;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IsCheck()
    {
        for(int ti = 1; ti < CMap.Raw-1; ti++)
        {
            for (int tj = 1; tj < CMap.Col-1; tj++)
            {
                //1
                if(tj - 2 > 1 && ti + 1 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti + 1] && MapArray[tj, ti] == MapArray[tj - 2, ti + 1])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti+1) + ")");
                        Debug.Log("(" + (tj-2) + "," + (ti+1) + ")");

                        Debug.Log("ㅇㅋ");
                    }
                }

                //2
                if (tj - 2 > 1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti - 1] && MapArray[tj, ti] == MapArray[tj - 2, ti - 1])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti - 1) + ")");
                        Debug.Log("(" + (tj - 2) + "," + (ti - 1) + ")");
                        Debug.Log("ㅇㅋ");
                    }
                }
                //3
                if (tj - 3 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 2, ti] && MapArray[tj, ti] == MapArray[tj - 3, ti])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj - 1) + "," + ti + ")");
                        Debug.Log("(" + (tj - 3) + "," + ti + ")");
                        Debug.Log("ㅇㅋ");
                    }
                }
                //4
                if (tj + 2 < CMap.Col-1 && ti + 1 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti + 1] && MapArray[tj, ti] == MapArray[tj + 2, ti + 1])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti + 1) + ")");
                        Debug.Log("(" + (tj + 2) + "," + (ti + 1) + ")");
                        Debug.Log("ㅇㅋ");
                    }
                }
                //5
                if (tj + 2 < CMap.Col-1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti - 1] && MapArray[tj, ti] == MapArray[tj + 2, ti - 1])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti - 1) + ")");
                        Debug.Log("(" + (tj + 2) + "," + (ti - 1) + ")");
                        Debug.Log("ㅇㅋ");
                    }
                }
                //6
                if (tj + 3 < CMap.Col-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 2, ti] && MapArray[tj, ti] == MapArray[tj + 3, ti])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj + 2) + "," + ti + ")");
                        Debug.Log("(" + (tj + 3) + "," + ti + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }

                //7
                if (tj - 1 > 1 && tj + 1 < CMap.Col-1 && ti + 1 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti + 1] && MapArray[tj, ti] == MapArray[tj + 1, ti + 1])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti + 1) + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti + 1) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }
                //8
                if (tj - 1 > 1 && tj + 1 < CMap.Col-1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti - 1] && MapArray[tj, ti] == MapArray[tj + 1, ti - 1])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti - 1) + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti - 1) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }
                //9
                if (tj - 1 > 1 && ti + 2 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti + 1] && MapArray[tj, ti] == MapArray[tj - 1, ti + 2])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti + 1) + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti + 2) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }
                //10
                if (tj + 1 < CMap.Col-1 && ti + 2 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti + 1] && MapArray[tj, ti] == MapArray[tj + 1, ti + 2])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti + 1) + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti + 2) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }
                //11
                if (ti + 3 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj, ti + 2] && MapArray[tj, ti] == MapArray[tj, ti + 3])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + tj + "," + (ti + 2) + ")");
                        Debug.Log("(" + tj + "," + (ti + 3) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }

                //12
                if (tj - 1 > 1 && ti - 2 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti - 1] && MapArray[tj, ti] == MapArray[tj - 1, ti - 2])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti - 1) + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti - 2) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }
                //13
                if (tj + 1 < CMap.Col-1 && ti - 2 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti - 1] && MapArray[tj, ti] == MapArray[tj + 1, ti - 2])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti - 1) + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti - 2) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }
                //14
                if (ti - 3 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj, ti - 2] && MapArray[tj, ti] == MapArray[tj, ti - 3])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + tj + "," + (ti - 2) + ")");
                        Debug.Log("(" + tj + "," + (ti - 3) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }

                //15
                if (tj + 1 < CMap.Col-1 && ti + 1 < CMap.Raw-1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti + 1] && MapArray[tj, ti] == MapArray[tj + 1, ti - 1])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti + 1) + ")");
                        Debug.Log("(" + (tj + 1) + "," + (ti - 1) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }

                //16
                if (tj - 1 > 1 && ti + 1 < CMap.Raw-1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti + 1] && MapArray[tj, ti] == MapArray[tj - 1, ti - 1])
                    {
                        Debug.Log("(" + tj + "," + ti + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti + 1) + ")");
                        Debug.Log("(" + (tj - 1) + "," + (ti - 1) + ")");
                        Debug.Log("ㅇㅋ");

                    }
                }
            }
        }
    }

    public void SetMapArray(CMap.Kind[,] tMapArray)
    {
        MapArray = tMapArray;
    }
}
