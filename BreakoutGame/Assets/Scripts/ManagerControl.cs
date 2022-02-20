using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerControl : MonoBehaviour
{
    UIControl UC; BricksCreater BCr; BallControl BC;//抓取腳本

    public float Timer = 60;//遊戲時間
    public float NowTime;//目前時間
    public float Socre;
    public bool GameState = false;//True才可以開始玩遊戲

    // Start is called before the first frame update
    void Start()
    {
        UC = GameObject.Find("UIControl").GetComponent<UIControl>();//抓取腳本
        BCr= GameObject.Find("BricksCreater").GetComponent<BricksCreater>();
        BC = GameObject.Find("Ball").GetComponent<BallControl>();
        NowTime = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        //說明BG消失後才能開始遊戲，這個狀態給其他腳本使用
        if (UC.ExplainBG.activeSelf == false)
            GameState = true;
        else
            GameState = false;

        if (GameState)
            NowTime -= Time.deltaTime;


        //遊戲結束(磚塊全消失 或者 求掉下去)
        if (Socre == BCr.X_Num * BCr.Y_Num * 10 || BC.BallDown==true)  {
            Invoke("DelayGameEnd", 1f);
        }
    }

    /// <summary>
    /// 延遲結束
    /// </summary>
    void DelayGameEnd() {
        UC.GameEnd();
    }
}
