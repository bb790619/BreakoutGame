using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    ManagerControl MC;//抓取腳本

    public Rigidbody2D Rig;
    [Header("水平速度")] public float X_Speed = 10;
    [Header("垂直速度")] public float Y_Speed = 10;

    //讓球維持等速
    float X_Speed_Max;
    float Y_Speed_Max;

    //檢查用
    //public float Rig_X;
    //public float Rig_Y;

    public bool BallDown = false;//球掉下去就變True

    bool OnceState = false;//只執行一次


    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("ManagerControl").GetComponent<ManagerControl>();//抓取腳本
        OnceState = false;
        BallDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MC.GameState && OnceState == false)
        {
            Invoke("DelayStart", 0.5f);
            OnceState = true;
        }


        //限制球的速度
        if (MC.GameState)
        {
            if (Rig.velocity.x > 0)
                X_Speed_Max = X_Speed;
            else
                X_Speed_Max = -X_Speed;

            if (Rig.velocity.y > 0)
                Y_Speed_Max = Y_Speed;
            else
                Y_Speed_Max = -Y_Speed;

            Rig.velocity = new Vector2(X_Speed_Max, Y_Speed_Max);

            //Rig_X = Rig.velocity.x;
            //Rig_Y = Rig.velocity.y;
        }
    }

    /// <summary>
    /// 球移動，延遲執行
    /// </summary>
    public void DelayStart()
    {
        Rig.velocity += new Vector2(X_Speed, Y_Speed);//初速度
    }


    /// <summary>
    /// 球掉下去
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Wall_Down")
        {
            BallDown = true;
            //print("結束了");
        }
    }

    /// <summary>
    /// 球撞到磚塊
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bricks")
        {
            Destroy(collision.gameObject);
            MC.Socre += 10;
            //print("撞到磚塊");
        }

    }

}
