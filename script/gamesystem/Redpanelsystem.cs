using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redpanelsystem : MonoBehaviour
{
    [SerializeField] private playerdata Playerdata;
    [SerializeField] private CanvasGroup redpanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playerdata.HP <= 70)
        {
            if(redpanel.alpha <= 1)
            {
                redpanel.alpha += 0.1f;
            }
        }
        else
        {
            if(redpanel.alpha >= 0.0f)
            {
                redpanel.alpha -= 0.1f;
            }
           
        }
        
    }
}
