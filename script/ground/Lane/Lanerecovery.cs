using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanerecovery : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private lanedata Lanedata;
    private float timeleft = 0f;


    void Start()
    {
        GameObject particleobj = GameObject.Find("Recovery Particle");
        particle = particleobj.GetComponent<ParticleSystem>();
        GameObject laneobj = GameObject.Find("LaneData");
        Lanedata = laneobj.GetComponent<lanedata>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            timeleft = 0.1f;
            particle.Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            timeleft -= Time.deltaTime;

            if (timeleft <= 0.0)
            {
                playerdata.MP = playerdata.MP + Lanedata.Recovery;
                if(playerdata.MP > 100)
                {
                    playerdata.MP = 100;
                }
                timeleft = 0.1f;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            particle.Stop();
        }
    }
}
