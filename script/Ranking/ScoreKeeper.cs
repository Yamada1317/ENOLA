using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreKeeper
{
    public float MyScore;
    public int MyRank;
    public string MyMode;
    public string MyGrade;

    public ScoreKeeper(float myscore,int myrank,string mymode,string mygrade)
    {
        this.MyScore = myscore;
        this.MyRank = myrank;
        this.MyMode = mymode;
        this.MyGrade = mygrade;
    }

}
