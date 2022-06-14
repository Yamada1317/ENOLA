using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Challengegamesystem : MonoBehaviour
{
    private enum STATE
    {
        FADEIN,
        TITLEIN,
        GAMESTART,
        GAMEPLAY,
        OVERIN,
        OVER,
    }

    private STATE state;
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

   


    private bool onetime;
    private bool mingting;

    private bool playgame;

    public float timeleft = 0f;

    private float seconds;

    void Start()
    {
        flowchart.SendFungusMessage("Fadein");

        onetime = true;
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
            Gamestart,
            Gameplay,
            Overin,
            Over
        };

    }

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
            state = STATE.GAMESTART;
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

        state = STATE.GAMEPLAY;
    }

    private void Gameplay()
    {
        if (stagenamepanel.alpha >= 0)
        {
            stagenamepanel.alpha -= 0.01f;
        }

        if (Playerdata.HP <= 0)
        {
            state = STATE.OVERIN;
        }
    }

    private void Overin()
    {
        playeranim.SetTrigger("GameOver");

        //Grounddata.movejudge = false;

        GameOverPanel.SetActive(true);
        Stagenamepanel.SetActive(false);

        Scoredata.judge = false;
        factorydata.factoryJudge = false;
        Playerdata.invisible = true;
        Playerdata.slowgo = false;
        Playerdata.movejudge = false;
        Playerdata.HP = 0;
        playerdata.MP = 100;

        posedata.posejadge = false;

        clockUI.SetActive(false);
        scoreUI.SetActive(false);

        gameoverbutton.Select();

        scoredata.Mode = "Challenge";

        scoredata.Grade = "none";



        state = STATE.OVER;
    }

    private void Over()
    {

        gameoverbutton.Select();

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
