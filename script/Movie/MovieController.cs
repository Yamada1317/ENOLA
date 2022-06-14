using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieController : MonoBehaviour
{
    [SerializeField] public VideoClip videoClip;
    public GameObject screen;

    void Start()
    {
        var videoPlayer = screen.AddComponent<VideoPlayer>();   // videoPlayeコンポーネントの追加

        videoPlayer.source = VideoSource.VideoClip; // 動画ソースの設定
        videoPlayer.clip = videoClip;
    }

    public void play()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
    }

    public void pause()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Pause();
    }
}
