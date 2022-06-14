using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    [Header("データ")]
    [SerializeField] 
    private playerdata Playerdata;

    [Header("オーディオ")]
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioSource slowAudio;

    [SerializeField]
    private AudioSource weakerAudio;

    [Header("ダメージボイス")]
    [SerializeField] 
    private AudioClip Damage1;
    [SerializeField]
    private AudioClip Damage2;
    [SerializeField]
    private AudioClip Damage3;


    [Header("アイテムボイス")]
    [SerializeField]
    private AudioClip Item1;
    [SerializeField]
    private AudioClip Item2;
    [SerializeField]
    private AudioClip Item3;

    [Header("ゲームオーバーボイス")]
    [SerializeField]
    private AudioClip GameOver1;
    [SerializeField]
    private AudioClip GameOver2;
    [SerializeField]
    private AudioClip GameOver3;

    //[Header("瀕死ボイス")]
    //[SerializeField]
    //private AudioSource DyingOfDeath;

    private int num = 0;

    private bool onetime = true;

    private bool weakertime = false;

    private float seconds;

    void Update()
    {
        if (Playerdata.HP <= 70.0f && Playerdata.HP > 0.0f && !audioSource.isPlaying && !slowAudio.isPlaying && weakertime)
        {
            WeakerVoice();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        
            if (other.gameObject.tag == "Obstacle" )
            {

                if (Playerdata.HP <= 0.0f)
                {
                    weakerAudio.Stop();
                    GameOverVoice();
                }
                else
                {
                    DamageVoice();
                    weakertime = true;
                }
            }
            if (other.gameObject.tag == "Prism" && !audioSource.isPlaying && !slowAudio.isPlaying)
            {
                ItemVoice();
            }
    }

    void DamageVoice()
    {
        if (!audioSource.isPlaying && !slowAudio.isPlaying)
        {
            num = Random.Range(0, 2 + 1);
            switch (num)
            {
                case 0:
                    audioSource.clip = Damage1;
                    audioSource.Play();
                    break;
                case 1:
                    audioSource.clip = Damage2;
                    audioSource.Play();
                    break;
                case 2:
                    audioSource.clip = Damage3;
                    audioSource.Play();
                    break;
            }
        }
        
    }

    void GameOverVoice()
    {
        audioSource.Stop();
        slowAudio.Stop();
        if (!audioSource.isPlaying && !slowAudio.isPlaying && !weakerAudio.isPlaying)
        {
            num = Random.Range(0, 2 + 1);
            switch (num)
            {
                case 0:
                    audioSource.clip = GameOver1;
                    audioSource.Play();
                    break;
                case 1:
                    audioSource.clip = GameOver2;
                    audioSource.Play();
                    break;
                case 2:
                    audioSource.clip = GameOver3;
                    audioSource.Play();
                    break;
            }
        }
            
    }

    void ItemVoice()
    {
        if (!audioSource.isPlaying && !slowAudio.isPlaying)
        {
            num = Random.Range(0, 2 + 1);
            switch (num)
            {
                case 0:
                    audioSource.clip = Item1;
                    audioSource.Play();
                    break;
                case 1:
                    audioSource.clip = Item2;
                    audioSource.Play();
                    break;
                case 2:
                    audioSource.clip = Item3;
                    audioSource.Play();
                    break;
            }
        }
            
    }


    private void WeakerVoice()
    {
        seconds += Time.deltaTime;
        if (seconds >= 0.1f)
        {
            seconds = 0.0f;
            weakerAudio.Play();
            weakertime = false;
        }

       
    }


}
