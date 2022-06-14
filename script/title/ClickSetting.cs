using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSetting : MonoBehaviour
{
    Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
    }

    public void OneClick()
    {
        btn.interactable = false;
    }
}
