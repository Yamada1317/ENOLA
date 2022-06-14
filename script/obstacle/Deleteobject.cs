using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleteobject : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Prism")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Crystal")
        {
            Destroy(other.gameObject);
        }
    }
}
