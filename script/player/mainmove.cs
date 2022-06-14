using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using DG.Tweening;
using UnityEngine;
using System;

public class mainmove : MonoBehaviour
{
    private enum STATE
    {
        INPUT,
        RIGHTMOVE,
        LEFTMOVE,
        WAIT
    };

    [SerializeField] public float MAX_WAIT_TIME;
    [SerializeField] public playerdata Playerdata;
    [SerializeField] private Animator playeranim;
    private STATE _state;
    private float _wait;
    private Action[] _updateFunc;
    private float x;
    private int count = 0;
    private int counted = 0;

    private bool moveones = false;

    [SerializeField] private GameObject camera;
    [SerializeField] private float moveX = 0.0f;

    private void Start()
    {
        _updateFunc = new Action[]
        {
            UpdateInput,
            UpdateRightMove,
            UpdateLeftMove,
            UpdateWait
        };
    }

    private void Update()
    {
        if (Playerdata.movejudge)
        {
            x = this.transform.position.x;
            var func = _updateFunc[(int)_state];
            func.Invoke();
        }
    }

    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetAxis("move1") == 1 && moveones))
        {
            if (counted == 1)
                counted = 0;
            count += 1;
            _wait = 0.0f;
            moveones = false;
            _state = STATE.RIGHTMOVE;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetAxis("move1") == -1 && moveones))
        {
            if (count == 1)
                count = 0;
            counted += 1;
            _wait = 0.0f;
            moveones = false;
            _state = STATE.LEFTMOVE;
        }

        if(Input.GetAxis("move1") == 0)
        {
            moveones = true;
        }
    }

    private void UpdateRightMove()
    {
        if (0 <= x && x <= 2.5)
        {
            transform.DOLocalMove(new Vector3(2.5f, 0.0f, 0.0f), 0.2f);
            camera.transform.DOLocalMove(new Vector3(moveX, 2.75f, -3.4f), 0.4f);
            count = 0;
            _state = STATE.WAIT;
        }
        else if (-2.5 <= x && x <= 0)
        {
            transform.DOLocalMove(new Vector3(0.0f, 0.0f, 0.0f), 0.2f);
            camera.transform.DOLocalMove(new Vector3(0.0f, 2.75f, -3.4f), 0.4f);
            _state = STATE.WAIT;
        }
        if (count >= 2)
        {
            transform.DOLocalMove(new Vector3(2.5f, 0.0f, 0.0f), 0.2f);
            camera.transform.DOLocalMove(new Vector3(moveX, 2.75f, -3.4f), 0.4f);
            count = 0;
            _state = STATE.WAIT;
        }
        playeranim.SetTrigger("Move_right");
    }

    private void UpdateLeftMove()
    {
        if (-2.5 <= x && x <= 0)
        {
            transform.DOLocalMove(new Vector3(-2.5f, 0.0f, 0.0f), 0.2f);
            camera.transform.DOLocalMove(new Vector3(-moveX, 2.75f, -3.4f), 0.4f);
            counted = 0;
            _state = STATE.WAIT;
        }
        else if (0 <= x && x <= 2.5)
        {
            transform.DOLocalMove(new Vector3(0.0f, 0.0f, 0.0f), 0.2f);
            camera.transform.DOLocalMove(new Vector3(0.0f, 2.75f, -3.4f), 0.4f);
            _state = STATE.WAIT;
        }
        if (counted >= 2)
        {
            transform.DOLocalMove(new Vector3(-2.5f, 0.0f, 0.0f), 0.2f);
            camera.transform.DOLocalMove(new Vector3(-moveX, 2.75f, -3.4f), 0.4f);
            counted = 0;
            _state = STATE.WAIT;
        }
        playeranim.SetTrigger("Move_left");
    }

    private void UpdateWait()
    {
        _wait += 0.1f;
        if (_wait >= MAX_WAIT_TIME)
        {
            _state = STATE.INPUT;
        }
    }
}