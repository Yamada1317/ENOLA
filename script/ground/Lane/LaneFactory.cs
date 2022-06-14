using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneFactory : MonoBehaviour
{
    [SerializeField] private Factorydata factorydata;

    private float timeleft = 20f;

    [SerializeField] private GameObject damagelane;
    [SerializeField] private GameObject recoverylane;

    [SerializeField] private GameObject Exit0;
    [SerializeField] private GameObject Exit1;
    [SerializeField] private GameObject Exit2;


    private float lanereservanem;
    private bool laneonetime;

    [SerializeField] private int[] probability;
    // Start is called before the first frame update
    void Start()
    {
        timeleft = 5f;
        laneonetime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (factorydata.factoryJudge)
        {

            if ((factorydata.plicetalNum - lanereservanem) >= factorydata.laneInterval && laneonetime)
            {
                if (Random.Range(0, 100 + 1) <= 80)
                {
                    LaneGO(Random.Range(1, 100 + 1), Random.Range(0, 2 + 1));
                }
                lanereservanem = factorydata.plicetalNum;
                laneonetime = false;
            }
            else
            {
                laneonetime = true;
            }

        }
    }


    void LaneGO(int Lane, int num)
    {
        if (Lane <= probability[0])
        {
            GameObject obs = Instantiate(damagelane);
            if (num == 0)
            {
                obs.transform.position = Exit0.transform.position;
            }
            else if (num == 1)
            {
                obs.transform.position = Exit1.transform.position;
            }
            else if (num == 2)
            {
                obs.transform.position = Exit2.transform.position;
            }

        }
        else if (Lane <= probability[1])
        {
            GameObject obs = Instantiate(recoverylane);
            if (num == 0)
            {
                obs.transform.position = Exit0.transform.position;
            }
            else if (num == 1)
            {
                obs.transform.position = Exit1.transform.position;
            }
            else if (num == 2)
            {
                obs.transform.position = Exit2.transform.position;
            }
        }
    }

}
