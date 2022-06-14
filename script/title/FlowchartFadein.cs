using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartFadein : MonoBehaviour
{
    [SerializeField] private Fungus.Flowchart flowchart = null;

    // Start is called before the first frame update
    void Start()
    {
        flowchart.SendFungusMessage("Fadein");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
