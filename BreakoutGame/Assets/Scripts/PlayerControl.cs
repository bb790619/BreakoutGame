using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    ManagerControl MC;//����}��

    [Header("�����t��")] public float X_Speed = 10;
    [Header("���k���ʽd�򭭨�")] public float X_Move = 2;

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
            this.transform.position += new Vector3(Time.deltaTime * X_Speed, 0, 0);
        else if (Input.GetKey(KeyCode.LeftArrow))
            this.transform.position -= new Vector3(Time.deltaTime * X_Speed, 0, 0);

        //����ʽd��
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -X_Move, X_Move), this.transform.position.y, this.transform.position.z);
    }


}
