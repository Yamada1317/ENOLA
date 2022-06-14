using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanedelete : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lane")
        {
            Destroy(other.gameObject);
        }
    }
}
