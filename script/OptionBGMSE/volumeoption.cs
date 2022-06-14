using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class volumeoption : MonoBehaviour
{
    [SerializeField] public GameObject Optionpanel;
    [SerializeField] public grounddata Grounddata;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void OnClick()
    {
        Grounddata.movejudge = true;
        Optionpanel.SetActive(false);
    }
}
