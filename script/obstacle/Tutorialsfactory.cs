using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorialsfactory : MonoBehaviour
{
    [Header("データ")]
    [SerializeField] private tutorialsdata Tutorialsdata;

    [Header("障害物")]
    [SerializeField] private GameObject[] objects;

    [Header("イチジク")]
    [SerializeField] private GameObject itiziku;

    [Header("射出口")]
    [SerializeField] private GameObject Exit0;
    [SerializeField] private GameObject Exit1;
    [SerializeField] private GameObject Exit2;

    private float seconds = 0.0f;
    private int num = 0;

    private bool itizikujudge = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Tutorialsdata.TutorialsJudge && num <= (objects.Length - 1))
        {
            seconds += Time.deltaTime;
            if (seconds >= Tutorialsdata.Timing)
            {
                seconds = 0;
                GameObject obs = Instantiate(objects[num]);
                obs.transform.position = Exit1.transform.position;
                num++;
            }

            if (num > (objects.Length - 1))
            {
                itizikujudge = true;
            }
        }else if (Tutorialsdata.TutorialsJudge && itizikujudge)
        {
            seconds += Time.deltaTime;
            if (seconds >= Tutorialsdata.Timing)
            {
                seconds = 0;
                GameObject itiziku1 = Instantiate(itiziku);
                GameObject itiziku2 = Instantiate(itiziku);
                GameObject itiziku3 = Instantiate(itiziku);
                itiziku1.transform.position = Exit0.transform.position;
                itiziku2.transform.position = Exit1.transform.position;
                itiziku3.transform.position = Exit2.transform.position;
                itizikujudge = false;
            }
        }
    }
}
