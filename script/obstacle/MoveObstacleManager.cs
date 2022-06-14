using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacleManager : MonoBehaviour
{
    private Slowdata slowdata;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject dataobj = GameObject.Find("Slowdata");
        slowdata = dataobj.GetComponent<Slowdata>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slowdata.slowInactivation)
        {
            animator.SetFloat("Speed", 0.05f);
        }
        else
        {
            animator.SetFloat("Speed", 1.0f);
        }
    }
}
