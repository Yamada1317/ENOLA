using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedmanager : MonoBehaviour
{
    [SerializeField] private grounddata Grounddata;
    [SerializeField] private Slowdata slowdata;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Grounddata.speedupjudge && !slowdata.slowcheck 
            && Grounddata.speed < Grounddata.maxspeed)
        {

            Grounddata.speed = Grounddata.speed + 0.005f;
        }

        if (Grounddata.speedupjudge && slowdata.slowcheck
            && Grounddata.speed < (Grounddata.maxspeed / 2.0f))
        {

            Grounddata.speed = Grounddata.speed + 0.0025f;
        }
        
        if(Grounddata.speed > Grounddata.maxspeed && !slowdata.slowcheck)
        {
            Grounddata.speed = Grounddata.maxspeed;
        }
    }
}
