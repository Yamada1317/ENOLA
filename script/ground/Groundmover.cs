using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundmover : MonoBehaviour
{
    [SerializeField] private grounddata Grounddata;
    GameObject[] grounds;
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("ground");
        GameObject dataobj = GameObject.FindWithTag("GroundData");
        Grounddata = dataobj.GetComponent<grounddata>();
    }

    void Update()
    {
        foreach(GameObject ground in grounds)
        {
            if (Grounddata.movejudge)
            {
                ground.gameObject.transform.Translate(0f, 0f, -Grounddata.speed);
            }
        }
    }
}
