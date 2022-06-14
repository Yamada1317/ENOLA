using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


public class Stage6_gamesystem : MonoBehaviour
{

    private enum STETE
    {
        FADEIN,
        TITLEIN,
        GAMESTART,
        GAMEPLAY,
        HERUGESUTOIN,
        HERUGESUTO,
        OVERIN,
        OVER
    }

    private STETE state;
    private Action[] updatefanc;

    [Header("データ")]
    [SerializeField] private playerdata Playerdata;
    [SerializeField] private grounddata Grounddata;
    [SerializeField] private Factorydata factorydata;
    [SerializeField] private scoredata Scoredata;
    [SerializeField] private systemdata Systemdata;
    [SerializeField] private Posedata posedata;

    [Header("Fangus")]
    [SerializeField] private Fungus.Flowchart flowchart = null;

    [Header("オブジェクト パネル")]
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject HeruGameOverPanel;

    [SerializeField] private GameObject Blackpanel;
    [SerializeField] private GameObject Stagenamepanel;

    [SerializeField] private CanvasGroup blackpanel;
    [SerializeField] private CanvasGroup stagenamepanel;

    [Header("UI( 時計　スコア )")]
    [SerializeField] private GameObject clockUI;
    [SerializeField] private GameObject scoreUI;

    [Header("アニメーション")]
    [SerializeField] private Animator playeranim;

    [Header("ゲームオーバーボタン")]
    [SerializeField] private Button gameoverbutton;
    [SerializeField] private Button Herugameoverbutton;



    private bool mingting;

    private bool playgame;

    private bool onetime = true;

    private float seconds;

    [Space(10)]
    public float timeleft = 0f;
    // Start is called before the first frame update
    void Start()
    {
        flowchart.SendFungusMessage("Fadein");

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

        playerdata.Herugesuto_get = false;

        timeleft = 2.0f;
        playgame = false;
        mingting = true;

        updatefanc = new Action[]
        {
            Fadein,
            Titlein,
            Gamestart,
            Gameplay,
            Herugesutoin,
            Herugesuto,
            Overin,
            Over
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
        if (blackpanel.alpha > 0)
        {
            blackpanel.alpha -= 0.005f;
        }
        else
        {
            state = STETE.TITLEIN;
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
            state = STETE.GAMESTART;
        }
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

        state = STETE.GAMEPLAY;
    }

    private void Gameplay()
    {
        if (stagenamepanel.alpha >= 0)
        {
            stagenamepanel.alpha -= 0.01f;
        }

        if (Playerdata.HP <= 0)
        {
            if (playerdata.Herugesuto_get)
            {
                state = STETE.HERUGESUTOIN;
            }
            else
            {
                state = STETE.OVERIN;
            }
        }
    }

    private void Herugesutoin()
    {
        playeranim.SetTrigger("GameOver");

        //Grounddata.movejudge = false;

        HeruGameOverPanel.SetActive(true);
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

        scoredata.Mode = "Story";
        scoredata.Grade = "EX";

        Herugameoverbutton.Select();


        state = STETE.HERUGESUTO;
    }

    private void Herugesuto()
    {
        seconds += Time.deltaTime;
        if (seconds >= 0.3f)
        {
            Grounddata.movejudge = false;
        }

        Herugameoverbutton.Select();
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

        scoredata.Mode = "Story";
        scoredata.Grade = "S";

        gameoverbutton.Select();

        state = STETE.OVER;
    }

    private void Over()
    {

        seconds += Time.deltaTime;
        if (seconds >= 0.3f)
        {
            Grounddata.movejudge = false;
        }

        gameoverbutton.Select();
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

