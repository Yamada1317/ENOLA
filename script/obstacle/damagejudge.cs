using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Permissions;
using UnityEngine;

public class damagejudge : MonoBehaviour
{
    [SerializeField] playerdata Playerdata;
    [SerializeField] grounddata Grounddata;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Animator animator;

    void Start()
    {
        GameObject dataobj = GameObject.FindWithTag("PlayerData");
        Playerdata = dataobj.GetComponent<playerdata>();
        GameObject audioobj = GameObject.Find("player");
        audioSource = audioobj.GetComponent<AudioSource>();
        GameObject particleobj = GameObject.FindWithTag("Particle");
        particle = particleobj.GetComponent<ParticleSystem>();
        GameObject groundobj = GameObject.FindWithTag("GroundData");
        Grounddata = groundobj.GetComponent<grounddata>();
        GameObject animobj = GameObject.Find("riry");
        animator = animobj.GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            if (!Playerdata.invisible)
            {
                Playerdata.invisible = true;
                Playerdata.HP = Playerdata.HP -  70f;
                Grounddata.speed = -0.15f;
                audioSource.Play();
                animator.SetTrigger("Damage");
                particle.Play();
            }
        }
    }
}
