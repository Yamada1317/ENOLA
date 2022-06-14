using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herugesuto_Effect : MonoBehaviour
{
    [SerializeField] Factorydata factorydata;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private AudioSource HeruBGMSource;
    [SerializeField] private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {

        GameObject dataobj2 = GameObject.Find("Factorydata");
        factorydata = dataobj2.GetComponent<Factorydata>();

        GameObject audioobj = GameObject.Find("SEobject_Herugesuto");
        audioSource = audioobj.GetComponent<AudioSource>();

        GameObject bgmobj = GameObject.Find("BGM_Object");
        BGMSource = bgmobj.GetComponent<AudioSource>();

        GameObject heruobj = GameObject.Find("Herugesuto_BGM_Object");
        HeruBGMSource = heruobj.GetComponent<AudioSource>();

        GameObject particleobj = GameObject.Find("HerugesutoParticle");
        particle = particleobj.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            playerdata.Herugesuto_get = true;
            factorydata.appearingJudge = false;
            BGMSource.Stop();
            HeruBGMSource.Play();
            audioSource.Play();
            particle.Play();
            Destroy(this.gameObject);
        }
    }
}
