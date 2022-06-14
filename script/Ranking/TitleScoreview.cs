using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScoreview : MonoBehaviour
{
    [Header("データ")]
    [SerializeField]
    private titledata Titledata;

    [Header("スコアテキスト")]
    [SerializeField]
    private Text[] scoretexts;

    [Header("モードテキスト")]
    [SerializeField]
    private Text[] modetexts;

    [Header("ランクUI")]
    [SerializeField]
    private GameObject[] RankUI;

    void Start()
    {
        Load();
    }

    public void Load()
    {
        var json = PlayerPrefs.GetString("Parameter", "nodata");

        if (json.Equals("nodata"))
        {
            var objs = new ScoreKeeper[10];

            for (int i = 0; i < 10; i++)
            {
                objs[i] = new ScoreKeeper(0.0f, i + 1, "none", "none");
            }

            PlayerPrefs.SetString("Parameter", JsonHelper.ToJson(objs));

            for (int i = 0; i < scoretexts.Length; i++)
            {
                scoretexts[i].text = " " + objs[i].MyScore;
                modetexts[i].text = objs[i].MyMode;
                RankDisplaying(objs[i].MyGrade, i);
            }

        }
        else
        {
            ScoreKeeper[] objs = JsonHelper.FromJson<ScoreKeeper>(json);

            for (int i = 0; i < scoretexts.Length; i++)
            {
                modetexts[i].text = objs[i].MyMode;
                scoretexts[i].text = " " + objs[i].MyScore;
                RankDisplaying(objs[i].MyGrade, i);
            }

        }

        Titledata.titlegrade = "C";

        scoredata.score = 0.0f;
        scoredata.Mode = "none";
        scoredata.Grade = "none";

    }

    public void Delete()
    {
        PlayerPrefs.DeleteKey("Parameter");
    }



    private void RankDisplaying(string strank, int ranknum)
    {
        if (strank == "C")
        {
            GameObject childC = RankUI[ranknum].transform.GetChild(0).gameObject;
            childC.SetActive(true);
        }
        else if (strank == "B")
        {
            GameObject childB = RankUI[ranknum].transform.GetChild(1).gameObject;
            childB.SetActive(true);
        }
        else if (strank == "A")
        {
            GameObject childA = RankUI[ranknum].transform.GetChild(2).gameObject;
            childA.SetActive(true);
        }
        else if (strank == "S")
        {
            GameObject childS = RankUI[ranknum].transform.GetChild(3).gameObject;
            childS.SetActive(true);
        }
        else if (strank == "EX")
        {
            GameObject childEX = RankUI[ranknum].transform.GetChild(4).gameObject;
            childEX.SetActive(true);
        }
        else
        {

        }
    }




}
