using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp_Recovery : MonoBehaviour
{
    [SerializeField] playerdata Playerdata;
    [SerializeField] itizikudata Itizikudata;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Animator animator;
    void Start()
    {
        GameObject itizikudata = GameObject.Find("ItizikuData");
        Itizikudata = itizikudata.GetComponent<itizikudata>();
        GameObject dataobj = GameObject.FindWithTag("PlayerData");
        Playerdata = dataobj.GetComponent<playerdata>();
        GameObject audioobj = GameObject.Find("SEobject_itijiku");
        audioSource = audioobj.GetComponent<AudioSource>();
        GameObject particleobj = GameObject.Find("Itiziku Particle");
        particle = particleobj.GetComponent<ParticleSystem>();
       // GameObject animobj = GameObject.Find("riry");
       // animator = animobj.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            playerdata.MP = playerdata.MP + Itizikudata.recovery_amount;
            if(playerdata.MP > 100)
            {
                playerdata.MP = 100;
                
            }
            audioSource.Play();
            particle.Play();
            //animator.SetTrigger("Itiziku");
            Destroy(this.gameObject);
        }
    }
}
