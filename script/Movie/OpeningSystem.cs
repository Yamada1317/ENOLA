using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class OpeningSystem : MonoBehaviour
{
    private enum MOVING
    {
        MOVESTART,
        MOVESCREENING,
        MOVESKIP,
        MOVEEND
    };

    [SerializeField] public VideoClip videoClip;
    [SerializeField] private CanvasGroup blackpanel;
    [SerializeField] public float MaxTime;
    [SerializeField] public float DisplayTimer;
    [SerializeField] GameObject Skip_judge;
    private float waittimer;
    private float SkipTime;
    public Slider Skiptimer;
    public GameObject screen;
    private MOVING _movie;
    private Action[] _move_now;

    private bool judge = true;

    void Awake()
    {
        Application.targetFrameRate = 60;
        var videoPlayer = screen.AddComponent<VideoPlayer>();   // videoPlayeコンポーネントの追加

        videoPlayer.loopPointReached += LoopPointReached;

        videoPlayer.source = VideoSource.VideoClip; // 動画ソースの設定
        videoPlayer.clip = videoClip;
    }
    // Start is called before the first frame update
    void Start()
    {
        _move_now = new Action[]
       {
            Updatestart,
            Updatescreening,
            Updateskip,
            Updatemoveend
       };
    }

    // Update is called once per frame
    void Update()
    {
        var movied = _move_now[(int)_movie];
        movied.Invoke();
    }

    private void Updatestart()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
        _movie = MOVING.MOVESCREENING;
    }

    private void Updatescreening()
    {
        Skip_judge.SetActive(false);
        Skiptimer.value = 0;
        waittimer = 0;
        if (judge)
        {
            blackpanel.alpha -= 0.05f;
        }
        else
        {
            blackpanel.alpha += 0.05f;
            if (blackpanel.alpha >= 1.0f)
            {
                SceneManager.LoadScene("Stage1");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Skip"))
        {
            _movie = MOVING.MOVESKIP;
        }
    }

    private void Updateskip()
    {
        Skip_judge.SetActive(true);
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Skip"))
        {
            Skiptimer.value += Time.deltaTime;
            if (Skiptimer.value >= MaxTime)
            {
                judge = false;
                SceneManager.LoadScene("Stage1");
            }
        }
        else if (Skiptimer.value > 0)
        {
            Skiptimer.value -= Time.deltaTime;
            waittimer += Time.deltaTime;
        }
        else if (Skiptimer.value == 0)
        {
            waittimer += Time.deltaTime;
        }

        if (waittimer >= DisplayTimer) 
        {
            _movie = MOVING.MOVESCREENING;
        }
    }

    private void Updatemoveend()
    {
        judge = false;
        SceneManager.LoadScene("Stage1");
    }

    public void LoopPointReached(VideoPlayer vp)
    {
        judge = false;
    }
}
        /*if (judge)
        {
            blackpanel.alpha -= 0.05f;
        }
        else
        {
            blackpanel.alpha += 0.05f;
            if(blackpanel.alpha >= 1.0f)
            {
                SceneManager.LoadScene("Stage1");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Skipjudge = 1;

        if (Skipjudge = 1) 
        {
            if (Input.GetKey(KeyCode.Space)) 
            {
                Skiptimer.value += Time.deltaTime;
                if (Skiptimer.value >= MaxTime) 
                {

                }
            }
        }*/
