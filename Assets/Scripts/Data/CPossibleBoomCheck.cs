using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPossibleBoomCheck : MonoBehaviour {

    public CMap.Kind[,] MapArray = null;

    public struct PossibleBlockcoordinates
    {
        public int X;
        public int Y;
    }

    public PossibleBlockcoordinates[] PossiblsBoomList = new PossibleBlockcoordinates[3];



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
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti+1) + ")");
                        //Debug.Log("(" + (tj-2) + "," + (ti+1) + ")");

                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj - 1;
                        PossiblsBoomList[1].Y = ti + 1;
                        PossiblsBoomList[2].X = tj - 2;
                        PossiblsBoomList[2].Y = ti + 1;
                    }
                }

                //2
                if (tj - 2 > 1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti - 1] && MapArray[tj, ti] == MapArray[tj - 2, ti - 1])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti - 1) + ")");
                        //Debug.Log("(" + (tj - 2) + "," + (ti - 1) + ")");
                        //Debug.Log("ㅇㅋ");

                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj - 1;
                        PossiblsBoomList[1].Y = ti - 1;
                        PossiblsBoomList[2].X = tj - 2;
                        PossiblsBoomList[2].Y = ti - 1;
                    }
                }
                //3
                if (tj - 3 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 2, ti] && MapArray[tj, ti] == MapArray[tj - 3, ti])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj - 1) + "," + ti + ")");
                        //Debug.Log("(" + (tj - 3) + "," + ti + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj - 2;
                        PossiblsBoomList[1].Y = ti;
                        PossiblsBoomList[2].X = tj - 3;
                        PossiblsBoomList[2].Y = ti;
                    }
                }
                //4
                if (tj + 2 < CMap.Col-1 && ti + 1 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti + 1] && MapArray[tj, ti] == MapArray[tj + 2, ti + 1])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti + 1) + ")");
                        //Debug.Log("(" + (tj + 2) + "," + (ti + 1) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj + 1;
                        PossiblsBoomList[1].Y = ti + 1;
                        PossiblsBoomList[2].X = tj + 2;
                        PossiblsBoomList[2].Y = ti + 1;
                    }
                }
                //5
                if (tj + 2 < CMap.Col-1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti - 1] && MapArray[tj, ti] == MapArray[tj + 2, ti - 1])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti - 1) + ")");
                        //Debug.Log("(" + (tj + 2) + "," + (ti - 1) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj + 1;
                        PossiblsBoomList[1].Y = ti - 1;
                        PossiblsBoomList[2].X = tj + 2;
                        PossiblsBoomList[2].Y = ti - 1;
                    }
                }
                //6
                if (tj + 3 < CMap.Col-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 2, ti] && MapArray[tj, ti] == MapArray[tj + 3, ti])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj + 2) + "," + ti + ")");
                        //Debug.Log("(" + (tj + 3) + "," + ti + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj + 2;
                        PossiblsBoomList[1].Y = ti;
                        PossiblsBoomList[2].X = tj + 3;
                        PossiblsBoomList[2].Y = ti;
                    }
                }

                //7
                if (tj - 1 > 1 && tj + 1 < CMap.Col-1 && ti + 1 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti + 1] && MapArray[tj, ti] == MapArray[tj + 1, ti + 1])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti + 1) + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti + 1) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj - 1;
                        PossiblsBoomList[1].Y = ti + 1;
                        PossiblsBoomList[2].X = tj + 1;
                        PossiblsBoomList[2].Y = ti + 1;
                    }
                }
                //8
                if (tj - 1 > 1 && tj + 1 < CMap.Col-1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti - 1] && MapArray[tj, ti] == MapArray[tj + 1, ti - 1])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti - 1) + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti - 1) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj - 1;
                        PossiblsBoomList[1].Y = ti - 1;
                        PossiblsBoomList[2].X = tj + 1;
                        PossiblsBoomList[2].Y = ti - 1;
                    }
                }
                //9
                if (tj - 1 > 1 && ti + 2 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti + 1] && MapArray[tj, ti] == MapArray[tj - 1, ti + 2])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti + 1) + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti + 2) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj - 1;
                        PossiblsBoomList[1].Y = ti + 1;
                        PossiblsBoomList[2].X = tj - 1;
                        PossiblsBoomList[2].Y = ti + 2;
                    }
                }
                //10
                if (tj + 1 < CMap.Col-1 && ti + 2 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti + 1] && MapArray[tj, ti] == MapArray[tj + 1, ti + 2])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti + 1) + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti + 2) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj + 1;
                        PossiblsBoomList[1].Y = ti + 1;
                        PossiblsBoomList[2].X = tj + 1;
                        PossiblsBoomList[2].Y = ti + 2;
                    }
                }
                //11
                if (ti + 3 < CMap.Raw-1)
                {
                    if (MapArray[tj, ti] == MapArray[tj, ti + 2] && MapArray[tj, ti] == MapArray[tj, ti + 3])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + tj + "," + (ti + 2) + ")");
                        //Debug.Log("(" + tj + "," + (ti + 3) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj;
                        PossiblsBoomList[1].Y = ti + 2;
                        PossiblsBoomList[2].X = tj;
                        PossiblsBoomList[2].Y = ti + 3;
                    }
                }

                //12
                if (tj - 1 > 1 && ti - 2 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti - 1] && MapArray[tj, ti] == MapArray[tj - 1, ti - 2])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti - 1) + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti - 2) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj - 1;
                        PossiblsBoomList[1].Y = ti - 1;
                        PossiblsBoomList[2].X = tj - 1;
                        PossiblsBoomList[2].Y = ti - 2;
                    }
                }
                //13
                if (tj + 1 < CMap.Col-1 && ti - 2 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti - 1] && MapArray[tj, ti] == MapArray[tj + 1, ti - 2])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti - 1) + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti - 2) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj + 1;
                        PossiblsBoomList[1].Y = ti - 1;
                        PossiblsBoomList[2].X = tj + 1;
                        PossiblsBoomList[2].Y = ti - 2;
                    }
                }
                //14
                if (ti - 3 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj, ti - 2] && MapArray[tj, ti] == MapArray[tj, ti - 3])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + tj + "," + (ti - 2) + ")");
                        //Debug.Log("(" + tj + "," + (ti - 3) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj;
                        PossiblsBoomList[1].Y = ti - 2;
                        PossiblsBoomList[2].X = tj;
                        PossiblsBoomList[2].Y = ti - 3;
                    }
                }

                //15
                if (tj + 1 < CMap.Col-1 && ti + 1 < CMap.Raw-1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj + 1, ti + 1] && MapArray[tj, ti] == MapArray[tj + 1, ti - 1])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti + 1) + ")");
                        //Debug.Log("(" + (tj + 1) + "," + (ti - 1) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj + 1;
                        PossiblsBoomList[1].Y = ti + 1;
                        PossiblsBoomList[2].X = tj + 1;
                        PossiblsBoomList[2].Y = ti - 1;
                    }
                }

                //16
                if (tj - 1 > 1 && ti + 1 < CMap.Raw-1 && ti - 1 > 1)
                {
                    if (MapArray[tj, ti] == MapArray[tj - 1, ti + 1] && MapArray[tj, ti] == MapArray[tj - 1, ti - 1])
                    {
                        //Debug.Log("(" + tj + "," + ti + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti + 1) + ")");
                        //Debug.Log("(" + (tj - 1) + "," + (ti - 1) + ")");
                        //Debug.Log("ㅇㅋ");
                        PossiblsBoomList[0].X = tj;
                        PossiblsBoomList[0].Y = ti;
                        PossiblsBoomList[1].X = tj - 1;
                        PossiblsBoomList[1].Y = ti + 1;
                        PossiblsBoomList[2].X = tj - 1;
                        PossiblsBoomList[2].Y = ti - 1;
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
