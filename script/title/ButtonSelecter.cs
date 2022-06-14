using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelecter : MonoBehaviour
{
    private enum STATE
    {
        STARTNORMAL,
        NORMALMODE,
        STARTOPTION,
        OPTIONMODE,
        STOPMODE
    }

    private STATE _state;
    private Action[] updatefanc;

    [Header("タイトル構成UI")]
    [SerializeField]
    private Button[] nomalButtons;

    [Header("待機用ボタン")]
    [SerializeField]
    private Button standByButton;

    [Header("オプション構成UI")]
    [SerializeField]
    private Button[] optionButtons;
    [SerializeField]
    private Slider[] optionSliders;

    [Header("オプションUI")]
    [SerializeField]
    private GameObject optionUI;

    private int nomalChooseNum = 0;

    private int optionChooseNum = 0;

    private bool moveones = false;


    void Start()
    {

        updatefanc = new Action[]
        {
            StartNormal,
            NormalMode,
            StartOption,
            OptionMode,
            StopMode
        };


        
    }


    void Update()
    {
        var fanc = updatefanc[(int)_state];
        fanc.Invoke();
    }



    private void StartNormal()
    {

        nomalChooseNum = 0;

        optionUI.SetActive(false);
        
        _state = STATE.NORMALMODE;
       
    }

    private void NormalMode()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetAxis("move2") == -1 && moveones))
        {
            nomalChooseNum += 1;
            moveones = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetAxis("move2") == 1 && moveones))
        {
            nomalChooseNum -= 1;
            moveones = false;
        }

        if (Input.GetAxis("move2") == 0)
        {
            moveones = true;
        }


        if (nomalChooseNum < 0)
        {
            nomalChooseNum = nomalButtons.Length - 1;
        }
        else if (nomalChooseNum > nomalButtons.Length - 1)
        {
            nomalChooseNum = 0;
        }

       

 
        nomalButtons[nomalChooseNum].Select();
    }

    private void StartOption()
    {


        optionChooseNum = optionSliders.Length;

        optionUI.SetActive(true);

        _state = STATE.OPTIONMODE;
    }

    private void OptionMode()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetAxis("move2") == -1 && moveones))
        {
            optionChooseNum += 1;
            moveones = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetAxis("move2") == 1 && moveones))
        {
            optionChooseNum -= 1;
            moveones = false;
        }

        if (Input.GetAxis("move2") == 0)
        {
            moveones = true;
        }

        if (optionChooseNum < 0)
        {
            optionChooseNum = (optionSliders.Length + optionButtons.Length) - 1;
        }
        else if(optionChooseNum > (optionSliders.Length + optionButtons.Length) - 1)
        {
            optionChooseNum = 0;
        }

        if(optionChooseNum < optionSliders.Length)
        {
            optionSliders[optionChooseNum].Select();
        }
        else
        {
            optionButtons[optionChooseNum - optionSliders.Length].Select();
        }

    }


    private void StopMode()
    {
        standByButton.Select();
    }


    public void ModeChangeNormal()
    {

        _state = STATE.STARTNORMAL;
    }

    public void ModeChangeOption()
    {
        _state = STATE.STARTOPTION;
    }

    public void ModeChangeStop()
    {
        _state = STATE.STOPMODE;
    }
}
