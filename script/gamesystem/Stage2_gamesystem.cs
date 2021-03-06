using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_gamesystem : MonoBehaviour
{

    private enum STATE
    {
        FADEIN,
        TITLEIN,
        TUTORIALSIN,
        TUTORIALSWATCHIN,
        TUTORIALSSTART,
        TUTORIALS,
        TUTORIALSOUT,
        GAMESTART,
        GAMEPLAY,
        CLEREIN,
        CLERE,
        OVERIN,
        OVER
    }

    private STATE state;
    private Action[] updatefanc;


    [Header("データ")]
    [SerializeField] private playerdata Playerdata;
    [SerializeField] private grounddata Grounddata;
    [SerializeField] private Factorydata factorydata;
    [SerializeField] private scoredata Scoredata;
    [SerializeField] private systemdata Systemdata;
    [SerializeField] private tutorialsdata Tutorialsdata;
    [SerializeField] private Sliderdata sliderdata;
    [SerializeField] private Posedata posedata;

    [Header("Fangus")]
    [SerializeField] private Fungus.Flowchart flowchart = null;

    [Header("オブジェクト パネル")]
    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private GameObject Blackpanel;
    [SerializeField] private GameObject Stagenamepanel;

    [SerializeField] private CanvasGroup blackpanel;
    [SerializeField] private CanvasGroup stagenamepanel;

    [Header("UI( 時計　スコア )")]
    [SerializeField] private GameObject clockUI;
    [SerializeField] private GameObject scoreUI;

    [Header("オブジェクト チュートリアルパネル")]
    [SerializeField] private GameObject TutorialsPanel;


    [Header("MPゲージ")]
    [SerializeField] private CanvasGroup Watch;
    [SerializeField] private Image Gauge;


    [Header("アニメーション")]
    [SerializeField] private Animator playeranim;

    [Header("ゲームオーバーボタン")]
    [SerializeField] private Button gameoverbutton;

    [Header("チュートリアル終点")]
    [SerializeField] private float tutorialslimittime = 0;

    [Header("終点")]
    [SerializeField] private int groundlimit = 0;

    [Header("オブジェクト生成停止")]
    [SerializeField] private int EP_adjustments;


    private bool onetime;
    private bool tutorialonetime;
    private bool mingting;

    private bool playgame;


    private bool oncetime = true;

    private float seconds;

    [Space(10)]
    public float timeleft = 0f;

    // Start is called before the first frame update
    void Start()
    {
        flowchart.SendFungusMessage("Fadein");

        onetime = true;
        tutorialonetime = true;
        Application.targetFrameRate = 60;

        factorydata.factoryJudge = false;
        Scoredata.judge = false;
        Playerdata.movejudge = false;
        Playerdata.playerstate = 1;
        Playerdata.slowgo = false;
        Grounddata.speedupjudge = false;

        stagenamepanel.alpha = 0;
        Systemdata.scenejudge = false;
        Systemdata.scenemovejudge = false;

        GameOverPanel.SetActive(false);
        Stagenamepanel.SetActive(false);
        Blackpanel.SetActive(true);

        timeleft = 2.0f;
        playgame = false;
        mingting = true;

        updatefanc = new Action[]
        {
            Fadein,
            Titlein,
            Tutorialsin,
            Tutorialswatchin,
            Tutorialsstart,
            Tutorials,
            Tutoruialsout,
            Gamestart,
            Gameplay,
            Clerein,
            Clere,
            Overin,
            Over,
        };

    }

    // Update is called once per frame
    void Update()
    {
        var fanc = updatefanc[(int)state];
        fanc.Invoke();
    }


    private void Fadein()
    {
        //パネルの透明度変更
        if (blackpanel.alpha > 0)
        {
            blackpanel.alpha -= 0.005f;
        }
        else
        {
            state = STATE.TITLEIN;
        }
    }

    private void Titlein()
    {
        if (onetime)
        {
            playeranim.SetTrigger("Start");
            onetime = false;
        }
        Stagenamepanel.SetActive(true);
        timeleft -= Time.deltaTime;

        if (stagenamepanel.alpha < 1)
        {
            stagenamepanel.alpha += 0.05f;
        }
        if (timeleft <= 0.0)
        {
            state = STATE.TUTORIALSIN;
        }
    }

    private void Tutorialsin()
    {
        if (stagenamepanel.alpha >= 0)
        {
            stagenamepanel.alpha -= 0.01f;
        }
        if (tutorialonetime)
        {
            tutorialonetime = false;
            flowchart.SendFungusMessage("Tutorials");
        }

    }

    public void TutorialsSTATEmove()
    {
        state = STATE.TUTORIALSWATCHIN;
    }

    private void Tutorialswatchin()
    {
        if (stagenamepanel.alpha >= 0)
        {
            stagenamepanel.alpha -= 0.01f;
        }

        if (Watch.alpha < 1.0f)
        {
            Watch.alpha += 0.02f;
        }
        else
        {
            if (Gauge.fillAmount < 0.9f)
            {
                Gauge.fillAmount += 0.05f;
            }
            else
            {
                sliderdata.sliderjadge = true;
                state = STATE.TUTORIALSSTART;
            }
            
        }
    }

    private void Tutorialsstart()
    {
        Tutorialsdata.TutorialsJudge = true;
        Blackpanel.SetActive(false);
        Playerdata.movejudge = true;
        Playerdata.slowgo = true;
        Grounddata.speedupjudge = true;
        TutorialsPanel.SetActive(true);
        state = STATE.TUTORIALS;
    }

    private void Tutorials()
    {
        if (stagenamepanel.alpha >= 0)
        {
            stagenamepanel.alpha -= 0.01f;
        }
        if (oncetime)
        {
            oncetime = false;
            Invoke("TutorialsSTATEmove2",tutorialslimittime);
        }
    }

    private void TutorialsSTATEmove2()
    {
        state = STATE.TUTORIALSOUT;
    }

    private void Tutoruialsout()
    {
        TutorialsPanel.SetActive(false);
        Tutorialsdata.TutorialsJudge = false;
        state = STATE.GAMESTART;
    }


    private void Gamestart()
    {
        Blackpanel.SetActive(false);
        factorydata.factoryJudge = true;
        Scoredata.judge = true;
        Playerdata.movejudge = true;
        Playerdata.slowgo = true;
        Grounddata.speedupjudge = true;
        posedata.posejadge = true;

        state = STATE.GAMEPLAY;
    }

    private void Gameplay()
    {
       

        if (Grounddata.groundcount + EP_adjustments >= groundlimit)
        {
            factorydata.factoryJudge = false;
        }

        if (Grounddata.groundcount >= groundlimit)
        {
            state = STATE.CLEREIN;
        }
        else if (Playerdata.HP <= 0)
        {
            state = STATE.OVERIN;
        }
    }

    private void Clerein()
    {
        playeranim.SetTrigger("Clear");

        flowchart.SendFungusMessage("Conversaion");

        Stagenamepanel.SetActive(false);

        clockUI.SetActive(false);
        scoreUI.SetActive(false);

        Scoredata.judge = false;
        Playerdata.movejudge = false;
        Playerdata.invisible = true;
        Playerdata.slowgo = false;
        Playerdata.HP = 100;

        posedata.posejadge = false;

        state = STATE.CLERE;
    }

    private void Clere()
    {
        Playerdata.invisible = true;
        if (Systemdata.scenejudge && blackpanel.alpha < 1)
        {
            Blackpanel.SetActive(true);
            blackpanel.alpha += 0.1f;
        }
        else if (blackpanel.alpha >= 1)
        {
            Systemdata.scenemovejudge = true;
        }
    }

    private void Overin()
    {
        playeranim.SetTrigger("GameOver");

        //Grounddata.movejudge = false;

        GameOverPanel.SetActive(true);
        Stagenamepanel.SetActive(false);

        clockUI.SetActive(false);
        scoreUI.SetActive(false);

        Scoredata.judge = false;
        factorydata.factoryJudge = false;
        Playerdata.invisible = true;
        Playerdata.slowgo = false;
        Playerdata.movejudge = false;
        Playerdata.HP = 0;
        playerdata.MP = 100;

        posedata.posejadge = false;

        gameoverbutton.Select();

        scoredata.Mode = "Story";

        if (SceneManager.GetActiveScene().buildIndex == 1
            || SceneManager.GetActiveScene().buildIndex == 2
            || SceneManager.GetActiveScene().buildIndex == 3)
        {
            scoredata.Grade = "C";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            scoredata.Grade = "B";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            scoredata.Grade = "A";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6 && playerdata.Herugesuto_get)
        {
            scoredata.Grade = "EX";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            scoredata.Grade = "S";
        }
        else
        {
            scoredata.Grade = "none";
        }




        state = STATE.OVER;
    }

    private void Over()
    {

        seconds += Time.deltaTime;
        if (seconds >= 0.3f)
        {
            Grounddata.movejudge = false;
        }

        if (Systemdata.scenejudge && blackpanel.alpha < 1)
        {
            Blackpanel.SetActive(true);
            blackpanel.alpha += 0.1f;
        }
        else if (blackpanel.alpha >= 1)
        {
            Systemdata.scenemovejudge = true;
        }
    }
}
