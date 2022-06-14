using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    public Slider Bgmslider;
    AudioSource audioSource;
    float Bgmvlume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Bgmslider.onValueChanged.AddListener(value => this.audioSource.volume = value);
    }

    void Update()
    {
        Bgmvlume = Bgmslider.value;
    }
}