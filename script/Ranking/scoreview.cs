using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreview : MonoBehaviour
{
    [SerializeField]
    private titledata Titledata;

    [SerializeField]
    private Text[] scoretexts;

    [SerializeField]
    private Text[] modetexts;

    [SerializeField]
    private GameObject[] PlayerSign;

    [SerializeField]
    private GameObject[] RankUI;

    [SerializeField]
    private Text mintext;

    [SerializeField]
    private Text minnum;

    [SerializeField]
    private Text minmode;

    private float Sa_score;
    private int Sa_rank;
    private string Sa_mode;
    private string Sa_grade;

    private float Re_score;
    private string Re_mode;
    private string Re_grade;

    private bool onetime = true;
    private int playerrank = 0;

    void Start()
    {
        Load();
    }

    public  void Load()
    {
        playerrank = 0;
        var json = PlayerPrefs.GetString("Parameter", "nodata");

        if (json.Equals("nodata"))
        {
            var objs = new ScoreKeeper[11];

            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    objs[i] = new ScoreKeeper(scoredata.score, i + 1, scoredata.Mode, scoredata.Grade);
                }
                else
                {
                    objs[i] = new ScoreKeeper(0.0f, i + 1, "none", "none");
                }
            }

            PlayerPrefs.SetString("Parameter", JsonHelper.ToJson(objs));

            for (int i = 0; i < scoretexts.Length - 1; i++)
            {
                scoretexts[i].text = " " + objs[i].MyScore;
                modetexts[i].text = objs[i].MyMode;
                RankDisplaying(objs[i].MyGrade, i);
            }
            mintext.text = " " + objs[10].MyScore;
            PlayerSign[0].SetActive(true);
            RankDisplaying(objs[10].MyGrade, 10);

        }
        else
        {
            ScoreKeeper[] Se_objs = JsonHelper.FromJson<ScoreKeeper>(json);
            var objs = new ScoreKeeper[Se_objs.Length + 1];
            for (var i = 0; i < Se_objs.Length; i++)
            {
                objs[i] = Se_objs[i];
            }

            Re_score = scoredata.score;
            Re_mode = scoredata.Mode;
            Re_grade = scoredata.Grade;

            for (var i = 0; i < objs.Length; i++)
            {
                if (objs[i] == null)
                {

                }
                else
                {
                    if (objs[i].MyScore <= Re_score)
                    {
                        Sa_score = Re_score;
                        Sa_rank = i + 1;
                        Sa_mode = Re_mode;
                        Sa_grade = Re_grade;

                        Re_score = objs[i].MyScore;
                        Re_mode = objs[i].MyMode;
                        Re_grade = objs[i].MyGrade;

                        objs[i].MyScore = Sa_score;
                        objs[i].MyRank = Sa_rank;
                        objs[i].MyMode = Sa_mode;
                        objs[i].MyGrade = Sa_grade;

                        if (onetime)
                        {
                            onetime = false;
                            playerrank = i + 1;
                        }


                    }
                }
            }

            PlayerPrefs.SetString("Parameter", JsonHelper.ToJson(objs));

            for (int i = 0; i < scoretexts.Length; i++)
            {
                modetexts[i].text = objs[i].MyMode;
                scoretexts[i].text = " " + objs[i].MyScore;
                RankDisplaying(objs[i].MyGrade, i);
            }

            if(playerrank <= 11)
            {
                minmode.text = objs[10].MyMode;
                mintext.text = " " + objs[10].MyScore;
                RankDisplaying(objs[10].MyGrade, 10);
            }
            else
            {
                minnum.text = " " + playerrank;
                minmode.text = objs[playerrank - 1].MyMode;
                mintext.text = " " + objs[playerrank - 1].MyScore;
                RankDisplaying(objs[playerrank - 1].MyGrade, 10);
            }

            if(playerrank <= 11)
            {
                PlayerSign[playerrank - 1].SetActive(true);
            }
            else
            {
                PlayerSign[10].SetActive(true);
            }
            
        }

        Titledata.titlegrade = scoredata.Grade;

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
        if(strank == "C")
        {
            GameObject childC = RankUI[ranknum].transform.GetChild(0).gameObject;
            childC.SetActive(true);
        }
        else if(strank == "B")
        {
            GameObject childB = RankUI[ranknum].transform.GetChild(1).gameObject;
            childB.SetActive(true);
        }
        else if(strank == "A")
        {
            GameObject childA = RankUI[ranknum].transform.GetChild(2).gameObject;
            childA.SetActive(true);
        }
        else if(strank == "S")
        {
            GameObject childS = RankUI[ranknum].transform.GetChild(3).gameObject;
            childS.SetActive(true);
        }
        else if(strank == "EX")
        {
            GameObject childEX = RankUI[ranknum].transform.GetChild(4).gameObject;
            childEX.SetActive(true);
        }
        else
        {

        }
    }




}
