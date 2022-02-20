using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//切換場景用

public class UIControl : MonoBehaviour
{
    ManagerControl MC; BricksCreater BCr; BallControl BC;//抓取腳本

    public GameObject ExplainBG;//說明BG
    public Text SocreText;//分數文字
    public Text TimerText;//時間文字

    public GameObject EndBG;//結束BG
    public Text EndSocerText;//結束的分數文字

    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("ManagerControl").GetComponent<ManagerControl>();//抓取腳本
        BCr = GameObject.Find("BricksCreater").GetComponent<BricksCreater>();
        BC = GameObject.Find("Ball").GetComponent<BallControl>();

        //初始化
        ExplainBG.SetActive(true);
        EndBG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SocreText.text = "分數:" + MC.Socre;//一個磚塊+10

        TimerText.text = "時間:" + MC.NowTime.ToString("F0");
    }


    /// <summary>
    /// 遊戲開始-按鍵
    /// </summary>
    public void GameStartBtn()
    {
        ExplainBG.SetActive(false);
    }

    /// <summary>
    /// 遊戲結束
    /// </summary>
    public void GameEnd()
    {
        MC.GameState = false;
        EndSocerText.text= "總分:" + (MC.Socre +MC.NowTime*1).ToString("F0"); //一個磚塊+10，剩餘時間*1
        EndBG.SetActive(true);

        Time.timeScale = 0;
    }

    /// <summary>
    /// 再玩一次-按鍵
    /// </summary>
    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);//切換場景
    }

}
