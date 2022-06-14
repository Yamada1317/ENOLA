using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpSlider : MonoBehaviour
{
    [SerializeField]
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.fillAmount = 0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = (playerdata.MP / 100) * 0.9f;
    }
}
