using UnityEngine;
using UnityEngine.UI;
using System;
public class pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    public bool Pausecheck = false;

    [SerializeField] public playerdata Playerdata;
    [SerializeField] public grounddata Grounddata;
    [SerializeField] public Posedata posedata;
    private float speedchange = 0;

    void Start()
    {
        pausePanel.SetActive(false);
         Pausecheck = false;
        speedchange = Grounddata.maxspeed;
    }
    private void Update()
    {
        if (posedata.posejadge)
        {
            if (Grounddata.movejudge)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Option"))
                {
                    Grounddata.speed = speedchange;
                    pausePanel.SetActive(true);
                    Time.timeScale = 0;
                    Pausecheck = true;
                    Grounddata.movejudge = false;
                    Playerdata.movejudge = false;
                    Playerdata.slowgo = false;
                }
            }
            else if (Grounddata.movejudge == false)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Option"))
                {
                    pausePanel.SetActive(false);
                    Grounddata.speed = speedchange;
                    Time.timeScale = 1;
                    Pausecheck = false;
                    Grounddata.movejudge = true;
                    Playerdata.movejudge = true;
                    Playerdata.slowgo = true;
                }
            }
        }
        
    }

    public void OnClick()
    {
        pausePanel.SetActive(false);
        Grounddata.speed = speedchange;
        Time.timeScale = 1;
        Pausecheck = false;
        Grounddata.movejudge = true;
        Playerdata.movejudge = true;
        Playerdata.slowgo = true;
    }
}
           