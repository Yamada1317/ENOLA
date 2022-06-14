using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuffed_judge : MonoBehaviour
{
    [SerializeField] private Prismdata prismdata;
    [SerializeField] private Stuffed_Effect stuffed_effect;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private stuffeddata Stuffeddata;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject dataobj2 = GameObject.Find("Prismdata");
        prismdata = dataobj2.GetComponent<Prismdata>();

        GameObject dataobj = GameObject.FindWithTag("Stuffed_Effect");
        stuffed_effect = dataobj.GetComponent<Stuffed_Effect>();

        GameObject audioobj = GameObject.Find("SEobject_Sutuffed");
        audioSource = audioobj.GetComponent<AudioSource>();

        GameObject particleobj = GameObject.Find("Sutuffed Particle");
        particle = particleobj.GetComponent<ParticleSystem>();

        GameObject stuffeobj = GameObject.Find("StuffedData");
        Stuffeddata = stuffeobj.GetComponent<stuffeddata>();

        GameObject animobj = GameObject.Find("riry");
        animator = animobj.GetComponent<Animator>();

    }

    // Update is called once per frame
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            stuffed_effect.Switch = true;
            prismdata.judge = true;
            stuffed_effect.timeleft = Stuffeddata.time;
            audioSource.Play();
            particle.Play();
            animator.SetTrigger("Stuffed");
            Destroy(this.gameObject);
        }
    }
}
