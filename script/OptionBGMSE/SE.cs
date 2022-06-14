using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SE : MonoBehaviour
{
    public Slider SEslider;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SEslider.onValueChanged.AddListener(value => this.audioSource.volume = value);
    }

    void Update()
    {
    }
}