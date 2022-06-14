using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpSliderStage2 : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private Sliderdata sliderdata;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderdata.sliderjadge)
        {
            image.fillAmount = (playerdata.MP / 100) * 0.9f;
        }
        
    }
}