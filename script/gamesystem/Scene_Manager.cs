using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] private systemdata Systemdata;
    [SerializeField] private int nextnumber;
    [SerializeField] private int number;
    [SerializeField] private int numbertwo;
    [SerializeField] private AudioSource audioSource;

    private bool scenemover = false;
    private bool scenemovertwo = false;
    private bool titlemover = false;
    private bool rankingmover = false;
    private bool challengemover = false;
    public void Scene_move()
    {
        scenemover = true;
        Systemdata.scenejudge = true;
        audioSource.Play();
    }

    public void Scene_move_two()
    {
        scenemovertwo = true;
        Systemdata.scenejudge = true;
        audioSource.Play();
    }

    public void Next_move()
    {
        SceneManager.LoadScene(nextnumber);
        audioSource.Play();
    }
    public void Title_Go()
    {
        titlemover = true;
        Systemdata.scenejudge = true;
        audioSource.Play();
    }

    public void Ranking_Go()
    {
        rankingmover = true;
        Systemdata.scenejudge = true;
        audioSource.Play();
    }

    public void ChallengeGo()
    {
        challengemover = true;
        Systemdata.scenejudge = true;
        audioSource.Play();
    }

    void Update()
    {
        if (Systemdata.scenemovejudge)
        {
            if (scenemover)
            {
                SceneManager.LoadScene(number);
            }
            if (scenemovertwo)
            {
                SceneManager.LoadScene(numbertwo);
            }
            if (titlemover)
            {
                SceneManager.LoadScene(0);
            }
            if (rankingmover)
            {
                SceneManager.LoadScene("Ranking");
            }
           
            if (challengemover)
            {
                SceneManager.LoadScene("Challenge");
            }
        }
    }
}
