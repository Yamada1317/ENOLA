using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rankingsystem : MonoBehaviour
{
    [SerializeField] private GameObject Blackpanel;
    [SerializeField] private CanvasGroup blackpanel;

    [SerializeField] private systemdata Systemdata;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Blackpanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (blackpanel.alpha > 0 && !Systemdata.scenejudge)
        {
            blackpanel.alpha -= 0.01f;
        }
        else if (!Systemdata.scenejudge)
        {
            Blackpanel.SetActive(false);
        }

        if (Systemdata.scenejudge && blackpanel.alpha < 1)
        {
            Blackpanel.SetActive(true);
            blackpanel.alpha += 0.1f;
        }
        else if (blackpanel.alpha >= 1)
        {
            Systemdata.scenemovejudge = true;
        }

    }
}
