using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            scoredata.score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "score:" + scoredata.score;
    }
}
