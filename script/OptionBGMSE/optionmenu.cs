using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionmenu : MonoBehaviour
{

    [SerializeField]
    private Button[] OptionButtons;
    [SerializeField]
    private Slider[] OptionSliders;
    private int optionnum = 0;
    private bool moveones = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetAxis("move2") == 1 && moveones)) 
        {
            optionnum -= 1;
            moveones = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetAxis("move2") == -1 && moveones)) 
        {
            optionnum += 1;
            moveones = false;
        }

        if(Input.GetAxis("move2") == 0)
        {
            moveones = true;
        }

        if (optionnum < 0)
        {
            optionnum = (OptionButtons.Length + OptionSliders.Length) - 1;
        }
        else if (optionnum >= (OptionButtons.Length + OptionSliders.Length)) 
        {
            optionnum = 0;
        }

        if (optionnum < OptionSliders.Length)
        {
            OptionSliders[optionnum].Select();
        }
        else 
        {
            OptionButtons[optionnum - OptionSliders.Length].Select();
        }
    }
}
