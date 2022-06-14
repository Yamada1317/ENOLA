using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datahandover : MonoBehaviour
{
    [SerializeField] private grounddata Grounddata;
    [SerializeField] private Factorydata factorydata;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        factorydata.plicetalNum = (float)Grounddata.groundcount;
    }
}
