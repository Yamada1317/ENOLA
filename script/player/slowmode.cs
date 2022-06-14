using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class slowmode : MonoBehaviour
{
    private enum STATE
    {
        INPUT,
        SLOWIN,
        SLOW,
        SLOWOUT
    }

    private STATE state;
    private Action[] updatefanc;
    [SerializeField] private GameObject slowpanel;
    [SerializeField] private GameObject MPbar;
    [SerializeField] public playerdata Playerdata;
    [SerializeField] public grounddata Grounddata;
    [SerializeField] public Slowdata slowdata;

    [Header("魔法ボイス")]
    [SerializeField]
    private AudioClip Magic1;
    [SerializeField]
    private AudioClip Magic2;
    [SerializeField]
    private AudioClip Magic3;

    [SerializeField]
    private AudioSource voiceSource;

    [SerializeField]
    private AudioSource playerAudio;


    [SerializeField] private float SlowCost;

    [SerializeField] private AudioSource audioSource;


    private float timeleft = 0f;



    void Awake()
    {
        slowpanel.SetActive(false);
        MPbar.SetActive(false);

        updatefanc = new Action[]
        {
            Keyinput,
            Slowin,
            Slow,
            Slowout,
        };

    }

    void Update()
    {

        var fanc = updatefanc[(int)state];
        fanc.Invoke();
    }


    void Keyinput()
    {
        if (Playerdata.slowgo)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Slow"))
            {
                audioSource.Play();
                if (playerdata.MP > 0)
                {
                    state = STATE.SLOWIN;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Slow"))
            {
                state = STATE.INPUT;
            }

        }
    }

    void Slowin()
    {
        Grounddata.maxspeed = Grounddata.maxspeed / 2.0f;
        Grounddata.speed = Grounddata.speed / 2.0f;
        slowpanel.SetActive(true);
        MPbar.SetActive(true);

        if (!voiceSource.isPlaying && !playerAudio.isPlaying)
        {
            int num = UnityEngine.Random.Range(0, 2 + 1);
            switch (num)
            {
                case 0:
                    voiceSource.clip = Magic1;
                    voiceSource.Play();
                    break;
                case 1:
                    voiceSource.clip = Magic2;
                    voiceSource.Play();
                    break;
                case 2:
                    voiceSource.clip = Magic3;
                    voiceSource.Play();
                    break;
            }
        }


        state = STATE.SLOW;

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Slow"))
        {
            state = STATE.SLOWOUT;
        }

        
    }

    void Slow()
    {
        slowdata.slowInactivation = true;
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            playerdata.MP -= SlowCost;
            timeleft = 0.1f;
        }

        if (Input.GetKeyUp(KeyCode.Space) || playerdata.MP <= 0 || Playerdata.HP <= 0.0f || Input.GetButtonUp("Slow"))
        {
            state = STATE.SLOWOUT;
        }

    }

    void Slowout()
    {
        slowdata.slowInactivation = false;
        Grounddata.maxspeed = Grounddata.maxspeed * 2.0f;
        Grounddata.speed = Grounddata.speed * 2.0f;
        slowpanel.SetActive(false);
        MPbar.SetActive(false);

        state = STATE.INPUT;
    }
}
