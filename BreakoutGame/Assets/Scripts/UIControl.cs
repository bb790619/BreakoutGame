using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//����������

public class UIControl : MonoBehaviour
{
    ManagerControl MC; BricksCreater BCr; BallControl BC;//����}��

    public GameObject ExplainBG;//����BG
    public Text SocreText;//���Ƥ�r
    public Text TimerText;//�ɶ���r

    public GameObject EndBG;//����BG
    public Text EndSocerText;//���������Ƥ�r

    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("ManagerControl").GetComponent<ManagerControl>();//����}��
        BCr = GameObject.Find("BricksCreater").GetComponent<BricksCreater>();
        BC = GameObject.Find("Ball").GetComponent<BallControl>();

        //��l��
        ExplainBG.SetActive(true);
        EndBG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SocreText.text = "����:" + MC.Socre;//�@�ӿj��+10

        TimerText.text = "�ɶ�:" + MC.NowTime.ToString("F0");
    }


    /// <summary>
    /// �C���}�l-����
    /// </summary>
    public void GameStartBtn()
    {
        ExplainBG.SetActive(false);
    }

    /// <summary>
    /// �C������
    /// </summary>
    public void GameEnd()
    {
        MC.GameState = false;
        EndSocerText.text= "�`��:" + (MC.Socre +MC.NowTime*1).ToString("F0"); //�@�ӿj��+10�A�Ѿl�ɶ�*1
        EndBG.SetActive(true);

        Time.timeScale = 0;
    }

    /// <summary>
    /// �A���@��-����
    /// </summary>
    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);//��������
    }

}
