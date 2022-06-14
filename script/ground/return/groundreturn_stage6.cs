using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundreturn_stage6 : MonoBehaviour
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

    void OnTriggerEnter(Collider other)
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

            GameObject pattern1 = other.transform.GetChild(0).gameObject;
            GameObject pattern2 = other.transform.GetChild(1).gameObject;
            GameObject pattern3 = other.transform.GetChild(2).gameObject;
            GameObject pattern4 = other.transform.GetChild(3).gameObject;
            GameObject pattern5 = other.transform.GetChild(4).gameObject;
            GameObject pattern6 = other.transform.GetChild(5).gameObject;

            int rnd = Random.Range(0, 5 + 1);

            switch (rnd)
            {
                case 0:
                    pattern1.SetActive(true);
                    pattern2.SetActive(false);
                    pattern3.SetActive(false);
                    pattern4.SetActive(false);
                    pattern5.SetActive(false);
                    pattern6.SetActive(false);
                    break;
                case 1:
                    pattern1.SetActive(false);
                    pattern2.SetActive(true);
                    pattern3.SetActive(false);
                    pattern4.SetActive(false);
                    pattern5.SetActive(false);
                    pattern6.SetActive(false);
                    break;
                case 2:
                    pattern1.SetActive(false);
                    pattern2.SetActive(false);
                    pattern3.SetActive(true);
                    pattern4.SetActive(false);
                    pattern5.SetActive(false);
                    pattern6.SetActive(false);
                    break;
                case 3:
                    pattern1.SetActive(false);
                    pattern2.SetActive(false);
                    pattern3.SetActive(false);
                    pattern4.SetActive(true);
                    pattern5.SetActive(false);
                    pattern6.SetActive(false);
                    break;

                case 4:
                    pattern1.SetActive(false);
                    pattern2.SetActive(false);
                    pattern3.SetActive(false);
                    pattern4.SetActive(false);
                    pattern5.SetActive(true);
                    pattern6.SetActive(false);
                    break;
                case 5:
                    pattern1.SetActive(false);
                    pattern2.SetActive(false);
                    pattern3.SetActive(false);
                    pattern4.SetActive(false);
                    pattern5.SetActive(false);
                    pattern6.SetActive(true);
                    break;
                default:
                    pattern1.SetActive(false);
                    pattern2.SetActive(false);
                    pattern3.SetActive(false);
                    pattern4.SetActive(false);
                    pattern5.SetActive(false);
                    pattern6.SetActive(false);
                    break;

            }

        }
    }
}
