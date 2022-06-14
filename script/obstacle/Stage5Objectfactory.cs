using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;

public class Stage5Objectfactory : MonoBehaviour
{
    [Header("データ")]
    [SerializeField] private Factorydata factorydata;

    [Header("2レーンオブジェクト")]
    [SerializeField] private GameObject obstacle2;

    [Header("3レーンオブジェクト size 2")]
    [SerializeField] private GameObject[] obstacles3;

    [Header("アイテム")]
    [SerializeField] private GameObject Score_obj;
    [SerializeField] private GameObject BigScore_obj;
    [SerializeField] private GameObject MP_obj;
    [SerializeField] private GameObject Stuffed_obj;

    [Header("障害物生成確率（並び）size 7")]
    [SerializeField] private float[] probability;

    [Header("アイテム生成確率　size 4")]
    [SerializeField] private float[] itemProbability;

    [Header("障害物生成口")]
    [SerializeField] private GameObject Exit0;
    [SerializeField] private GameObject Exit1;
    [SerializeField] private GameObject Exit2;

    private int Adoption = 0;
    private float timeleft = 0f;

    private float rand = 0;
    private int rand_2 = 0;

    [Space(10)]
    [SerializeField] private bool onetime = false;
    private bool itemonetime = false;

    private float reservanem = 0;
    private float itemreservanem = 0;

    private float Reserve = 0;

    // Start is called before the first frame update
    void Start()
    {
        onetime = true;
        Reserve = factorydata.interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (factorydata.factoryJudge)
        {

            if (factorydata.interval != 1)
            {
                if ((factorydata.plicetalNum % factorydata.interval) == 0 && onetime)
                {

                    Object_Production();

                    onetime = false;
                }
                else if ((factorydata.plicetalNum % factorydata.interval) != 0)
                {
                    onetime = true;
                }

            }
            else if (factorydata.interval == 1)
            {
                if ((factorydata.plicetalNum - reservanem) >= 1 && onetime)
                {
                    Object_Production();

                    onetime = false;
                    reservanem = factorydata.plicetalNum;
                }
                else
                {
                    onetime = true;
                }
            }


            if ((factorydata.plicetalNum - itemreservanem) >= factorydata.itemInterval && itemonetime)
            {
                if (Random.Range(0, 100 + 1) <= 80)
                {
                    Item_Production();
                }
                itemreservanem = factorydata.plicetalNum;
                itemonetime = false;
            }
            else
            {
                itemonetime = true;
            }
        }

    }

    void Object_Production()
    {
        rand = Random.Range(0, 100);

        if (rand <= probability[0])
        {
            Exit_Go(0);
            factorydata.location = Random.Range(1, 2 + 1);
        }
        else if (rand <= probability[1])
        {
            Exit_Go(1);
            if (Random.Range(0, 1 + 1) == 0) { factorydata.location = 0; }
            else { factorydata.location = 2; }
        }
        else if (rand <= probability[2])
        {
            Exit_Go(2);
            factorydata.location = Random.Range(0, 1 + 1);
        }
        else if (rand <= probability[3])
        {
            rand_2 = Random.Range(0, 1 + 1);
            if (rand_2 == 0)
            {
                Exit_Go(0);
                Exit_Go(1);
            }
            else
            {
                Exit2Masu_Go(0);
            }
            factorydata.location = 2;
        }
        else if (rand <= probability[4])
        {
            Exit_Go(0);
            Exit_Go(2);
            factorydata.location = 1;
        }
        else if (rand <= probability[5])
        {
            rand_2 = Random.Range(0, 1 + 1);
            if (rand_2 == 0)
            {
                Exit_Go(1);
                Exit_Go(2);
            }
            else
            {
                Exit2Masu_Go(1);
            }
            factorydata.location = 0;
        }
        else if(rand <= probability[6])
        {
            Exit3Masu_Go();
        }
        else
        {

        }

        if (Random.Range(0, 100 + 1) < factorydata.changeProbability)
        {
            factorydata.interval = factorydata.changeInterval;
        }
        else
        {
            factorydata.interval = Reserve;
        }


    }

    void Exit_Go(int num)
    {
        int obsrand = Random.Range(0, factorydata.objects.Length);
        GameObject obs = Instantiate(factorydata.objects[obsrand]);
        switch (num)
        {
            case 0:
                obs.transform.position = Exit0.transform.position;
                break;
            case 1:
                obs.transform.position = Exit1.transform.position;
                break;
            case 2:
                obs.transform.position = Exit2.transform.position;
                break;
        }
    }

    void Exit2Masu_Go(int num)
    {
        GameObject obs = Instantiate(obstacle2);
        switch (num)
        {
            case 0:
                obs.transform.position = Exit0.transform.position;
                break;
            case 1:
                obs.transform.position = Exit1.transform.position;
                break;
            case 2:
                obs.transform.position = Exit2.transform.position;
                break;
        }
    }

    void Exit3Masu_Go()
    {
        int obsrand = Random.Range(0, obstacles3.Length);
        GameObject obs = Instantiate(obstacles3[obsrand]);
       
        obs.transform.position = Exit1.transform.position;
    }


    void Item_Production()
    {
        int randm = Random.Range(0, 100 + 1);
        GameObject itemobj = null;
        if (randm <= itemProbability[0] && itemProbability[0] > 0.0f)
        {
            itemobj = Instantiate(Score_obj);
        }
        else if (randm <= itemProbability[1] && itemProbability[1] > 0.0f)
        {
            itemobj = Instantiate(MP_obj);
        }
        else if (randm <= itemProbability[2] && itemProbability[2] > 0.0f)
        {
            itemobj = Instantiate(Stuffed_obj);
        }
        else if (randm <= itemProbability[3] && itemProbability[3] > 0.0f)
        {
            itemobj = Instantiate(BigScore_obj);
        }


        switch (factorydata.location)
        {
            case 0: itemobj.transform.position = Exit0.transform.position; break;
            case 1: itemobj.transform.position = Exit1.transform.position; break;
            case 2: itemobj.transform.position = Exit2.transform.position; break;
        }


    }

}