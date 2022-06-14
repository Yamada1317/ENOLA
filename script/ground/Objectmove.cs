using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class Objectmove : MonoBehaviour
{
    [SerializeField] private grounddata Grounddata;

    void Start()
    {
        GameObject dataobj = GameObject.FindWithTag("GroundData");
        Grounddata = dataobj.GetComponent<grounddata>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Grounddata.movejudge)
        {
        this.transform.Translate(0f, 0f, -Grounddata.speed);
        }
    }
}
