using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingScenesManager : MonoBehaviour
{
    [SerializeField] private systemdata Systemdata;
    [SerializeField] private titledata Titledata;
    [SerializeField] private int number;

    private bool scenemover = false;
    private bool retrymover = false;


    public void ChangeTitleGo()
    {
        scenemover = true;
        Systemdata.scenejudge = true;
    }

    public void RetryGo()
    {
        retrymover = true;
        Systemdata.scenejudge = true;
    }

    void Update()
    {
        if (Systemdata.scenemovejudge)
        {
            if (scenemover)
            {
                if(Titledata.titlegrade == "C")
                {
                    SceneManager.LoadScene("Start1006");
                }
                else if(Titledata.titlegrade == "B")
                {
                    SceneManager.LoadScene("Start1420");
                }
                else if (Titledata.titlegrade == "A")
                {
                    SceneManager.LoadScene("Start1835");
                }
                else if (Titledata.titlegrade == "S")
                {
                    SceneManager.LoadScene("Start1952");
                }
                else if (Titledata.titlegrade == "EX")
                {
                    SceneManager.LoadScene("Start1006");
                }
                else
                {
                    SceneManager.LoadScene("Start1006");
                }
            }

            if (retrymover)
            {
                SceneManager.LoadScene(number);
            }
        }
    }
}
