using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    ManagerControl MC;//����}��

    public Rigidbody2D Rig;
    [Header("�����t��")] public float X_Speed = 10;
    [Header("�����t��")] public float Y_Speed = 10;

    //���y�������t
    float X_Speed_Max;
    float Y_Speed_Max;

    //�ˬd��
    //public float Rig_X;
    //public float Rig_Y;

    public bool BallDown = false;//�y���U�h�N��True

    bool OnceState = false;//�u����@��


    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("ManagerControl").GetComponent<ManagerControl>();//����}��
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


        //����y���t��
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
    /// �y���ʡA�������
    /// </summary>
    public void DelayStart()
    {
        Rig.velocity += new Vector2(X_Speed, Y_Speed);//��t��
    }


    /// <summary>
    /// �y���U�h
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Wall_Down")
        {
            BallDown = true;
            //print("�����F");
        }
    }

    /// <summary>
    /// �y����j��
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bricks")
        {
            Destroy(collision.gameObject);
            MC.Socre += 10;
            //print("����j��");
        }

    }

}
