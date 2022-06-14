using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCall : MonoBehaviour
{

    [Header("オーディオ")]
    [SerializeField]
    private AudioSource audioSource;


    [Header("タイトルボイス")]
    [SerializeField]
    private AudioClip Title1;
    [SerializeField]
    private AudioClip Title2;
    [SerializeField]
    private AudioClip Title3;

    [Header("ストーリーモード画像")]
    [SerializeField]
    private CanvasGroup img;

    private bool oncetime;
    // Start is called before the first frame update
    void Start()
    {
        oncetime = true;  
    }

    // Update is called once per frame
    void Update()
    {
        if(img.alpha >= 0.5f && oncetime)
        {
            TitleVoice();
            oncetime = false;
        }
    }

    private void TitleVoice()
    {
        var num = Random.Range(0, 2 + 1);
        switch (num)
        {
            case 0:
                audioSource.clip = Title1;
                audioSource.Play();
                break;
            case 1:
                audioSource.clip = Title2;
                audioSource.Play();
                break;
            case 2:
                audioSource.clip = Title3;
                audioSource.Play();
                break;
        }
    }
}
