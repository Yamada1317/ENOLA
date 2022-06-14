using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigScorePlse : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        GameObject audioobj = GameObject.Find("SEobject_BIgCrystal");
        audioSource = audioobj.GetComponent<AudioSource>();
        GameObject particleobj = GameObject.Find("Crystal Particle");
        particle = particleobj.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            scoredata.score += 200;
            particle.Play();
            audioSource.Play();
            Destroy(this.gameObject);
        }
    }
}
