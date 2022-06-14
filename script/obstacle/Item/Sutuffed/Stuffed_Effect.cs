using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuffed_Effect : MonoBehaviour
{
    [SerializeField] private Prismdata prismdata;
    [SerializeField] private ParticleSystem particle;
    public bool Switch = false;
    public float timeleft = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Switch)
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0.0)
            {
                particle.Stop();
                Switch = false;
                prismdata.judge = false;
            }
        }
    }
}
