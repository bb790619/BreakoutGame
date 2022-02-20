using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerControl : MonoBehaviour
{
    UIControl UC; BricksCreater BCr; BallControl BC;//����}��

    public float Timer = 60;//�C���ɶ�
    public float NowTime;//�ثe�ɶ�
    public float Socre;
    public bool GameState = false;//True�~�i�H�}�l���C��

    // Start is called before the first frame update
    void Start()
    {
        UC = GameObject.Find("UIControl").GetComponent<UIControl>();//����}��
        BCr= GameObject.Find("BricksCreater").GetComponent<BricksCreater>();
        BC = GameObject.Find("Ball").GetComponent<BallControl>();
        NowTime = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        //����BG������~��}�l�C���A�o�Ӫ��A����L�}���ϥ�
        if (UC.ExplainBG.activeSelf == false)
            GameState = true;
        else
            GameState = false;

        if (GameState)
            NowTime -= Time.deltaTime;


        //�C������(�j�������� �Ϊ� �D���U�h)
        if (Socre == BCr.X_Num * BCr.Y_Num * 10 || BC.BallDown==true)  {
            Invoke("DelayGameEnd", 1f);
        }
    }

    /// <summary>
    /// ���𵲧�
    /// </summary>
    void DelayGameEnd() {
        UC.GameEnd();
    }
}
