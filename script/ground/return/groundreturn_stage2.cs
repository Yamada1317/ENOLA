using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundreturn_stage2 : MonoBehaviour
{
    [SerializeField] grounddata Grounddata;
    [SerializeField] Factorydata factorydata;
    [SerializeField] scoredata Scoredata;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            other.gameObject.transform.Translate(0f, 0f, 85f);
            Grounddata.groundcount++;
            factorydata.plicetalNum++;
            if (Scoredata.judge)
            {
                scoredata.score += 5;
            }

            GameObject pattern1 = other.transform.Find("Stage2_pattern1").gameObject;
            GameObject pattern2 = other.transform.Find("Stage2_pattern2").gameObject;
            GameObject pattern3 = other.transform.Find("Stage2_pattern3").gameObject;

            int rnd = Random.Range(0, 2 + 1);

            switch (rnd)
            {
                case 0:
                    pattern1.SetActive(true);
                    pattern2.SetActive(false);
                    pattern3.SetActive(false);
                    break;
                case 1:
                    pattern1.SetActive(false);
                    pattern2.SetActive(true);
                    pattern3.SetActive(false);
                    break;
                case 2:
                    pattern1.SetActive(false);
                    pattern2.SetActive(false);
                    pattern3.SetActive(true);
                    break;
                default:
                    pattern1.SetActive(false);
                    pattern2.SetActive(false);
                    pattern3.SetActive(false);
                    break;

            }

        }
    }
}
