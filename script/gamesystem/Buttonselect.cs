using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonselect : MonoBehaviour
{
    [SerializeField] private Button firsetbutton;

    void Start()
    {
        firsetbutton.Select();
    }


}
