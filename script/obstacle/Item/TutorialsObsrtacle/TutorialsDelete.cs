using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialsDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Del", 15);
    }

    void Del()
    {
        Destroy(this.gameObject);
    }
}
