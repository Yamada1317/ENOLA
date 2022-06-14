using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private playerdata Playerdata;
    public float timeleft = 0.0f;
    private bool time = false;

    void Start()
    {
        particle.Stop();
        timeleft = 1.0f;
    }

    void Update()
    {
        if (time)
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0.0)
            {
                particle.Stop();
                time = false;
                timeleft = 1.0f;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (!Playerdata.invisible)
            {
                time = true;
                particle.Play();
            }
           
        }
       
    }

}
