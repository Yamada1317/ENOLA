using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibletime : MonoBehaviour
{
    [SerializeField] playerdata Playerdata;
    private float timelate;

    void Start()
    {
        timelate = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Playerdata.invisible)
        {
            timelate -= Time.deltaTime;
            if(timelate <= 0.0f)
            {
                Playerdata.invisible = false;
                timelate = 2.0f;
            }
        }
    }
}
