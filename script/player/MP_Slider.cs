using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_Slider : MonoBehaviour
{
    [SerializeField] public Slider slider;
    // Update is called once per frame
    void Update()
    {
        slider.value = playerdata.MP;
    }
}
