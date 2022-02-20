using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksCreater : MonoBehaviour
{
    [Header("磚塊Prefab")] public GameObject BricksPrefab;
    [Header("磚塊產生的位置")] public GameObject BricksPoint;

    [Header("磚塊X的數量")] public int X_Num;
    [Header("磚塊X的間隔")] public float X_Interval;
    [Header("磚塊Y的數量")] public int Y_Num;
    [Header("磚塊Y的間隔")] public float Y_Interval;

    int SerialNum = 0;//產生磚塊的流水號

    // Start is called before the first frame update
    void Start()
    {
        MakeBricks();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 產生磚塊
    /// </summary>
    void MakeBricks()
    {
        for (int i = 0; i < X_Num; i++)
            for (int j = 0; j < Y_Num; j++)
            {
                Instantiate(BricksPrefab, new Vector3(BricksPoint.transform.position.x + i * X_Interval,
                    BricksPoint.transform.position.y - j * Y_Interval,
                    BricksPoint.transform.position.z),
                    Quaternion.identity).name = "Bricks" + SerialNum;

                GameObject.Find("Bricks" + SerialNum).transform.SetParent(GameObject.Find("BricksCreater").transform);
                SerialNum++;

            }


    }

}
