using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class optiontitle : MonoBehaviour
{

    public void OnClick() 
    {
        scoredata.score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
