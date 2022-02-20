using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    ManagerControl MC;//����}��

    [Header("�����t��")] public float H_Speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("ManagerControl").GetComponent<ManagerControl>();//����}��
    }

    // Update is called once per frame
    void Update()
    {
        if (MC.GameState)
            PlayerMove();
    }

    /// <summary>
    /// ����k����
    /// </summary>
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            this.transform.position += new Vector3(Time.deltaTime * H_Speed, 0, 0);
        else if (Input.GetKey(KeyCode.LeftArrow))
            this.transform.position -= new Vector3(Time.deltaTime * H_Speed, 0, 0);

        //����ʽd��
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -1.85f, 1.85f), this.transform.position.y, this.transform.position.z);
    }


}
