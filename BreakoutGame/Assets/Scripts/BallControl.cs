using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    ManagerControl MC;//����}��

    public Rigidbody2D Rig;
    [Header("�����t��")] public float H_Speed = 10;
    [Header("�����t��")] public float V_Speed = 10;

    public bool BallDown = false;//�y���U�h�N��True

    bool OnceState = false;//�u����@��
   

    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("ManagerControl").GetComponent<ManagerControl>();//����}��
    }

    // Update is called once per frame
    void Update()
    {
        if (MC.GameState && OnceState == false)
        {
            Invoke("DelayStart", 0.5f);
            OnceState = true;
        }
    }

    /// <summary>
    /// �y���ʡA�������
    /// </summary>
    public void DelayStart()
    {
        Rig.velocity += new Vector2(H_Speed, V_Speed);//��t��
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
