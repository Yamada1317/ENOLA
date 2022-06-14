using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlphaChange : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup img;

    [SerializeField]
    private float timer;

    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        img.alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= timer)
        {
            img.alpha += 0.05f;
        }
    }
}
