using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanedamage : MonoBehaviour
{

    [SerializeField] playerdata Playerdata;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private lanedata Lanedata;
    private float timeleft = 0f;


    void Start()
    {
        GameObject dataobj = GameObject.FindWithTag("PlayerData");
        Playerdata = dataobj.GetComponent<playerdata>();
        GameObject particleobj = GameObject.Find("Poison Particle");
        particle = particleobj.GetComponent<ParticleSystem>();
        GameObject laneobj = GameObject.Find("LaneData");
        Lanedata = laneobj.GetComponent<lanedata>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            timeleft = 1.0f;
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
                if (!Playerdata.invisible)
                {
                    Playerdata.HP = Playerdata.HP - Lanedata.Damage;
                    timeleft = 0.3f;
                }
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
