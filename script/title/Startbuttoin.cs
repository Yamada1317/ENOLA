using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startbuttoin : MonoBehaviour
{
    [SerializeField]
    private Button storybutton;
    // Start is called before the first frame update
    void Start()
    {
        storybutton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
