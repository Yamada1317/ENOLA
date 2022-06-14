using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorereset : MonoBehaviour
{
    public void reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
