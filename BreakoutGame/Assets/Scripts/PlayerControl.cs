using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    ManagerControl MC;//抓取腳本

    [Header("水平速度")] public float H_Speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("ManagerControl").GetComponent<ManagerControl>();//抓取腳本
    }

    // Update is called once per frame
    void Update()
    {
        if (MC.GameState)
            PlayerMove();
    }

    /// <summary>
    /// 控制左右移動
    /// </summary>
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            this.transform.position += new Vector3(Time.deltaTime * H_Speed, 0, 0);
        else if (Input.GetKey(KeyCode.LeftArrow))
            this.transform.position -= new Vector3(Time.deltaTime * H_Speed, 0, 0);

        //限制移動範圍
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -1.85f, 1.85f), this.transform.position.y, this.transform.position.z);
    }


}
