using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksCreater : MonoBehaviour
{
    [Header("�j��Prefab")] public GameObject BricksPrefab;
    [Header("�j�����ͪ���m")] public GameObject BricksPoint;

    [Header("�j��X���ƶq")] public int X_Num;
    [Header("�j��X�����j")] public float X_Interval;
    [Header("�j��Y���ƶq")] public int Y_Num;
    [Header("�j��Y�����j")] public float Y_Interval;

    int SerialNum = 0;//���Ϳj�����y����

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
    /// ���Ϳj��
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
