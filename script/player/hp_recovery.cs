using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_recovery : MonoBehaviour
{
    [SerializeField] playerdata Playerdata;

    private float timeleft;

    void Update()
    {   
      if(Playerdata.HP < 100 && !Playerdata.invisible)
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0.0)
            {
                timeleft = 1.0f;
                Playerdata.HP += 10;
            }
        }
        if (Playerdata.HP > 100)
        {
            Playerdata.HP = 100;
        }
    }
}
