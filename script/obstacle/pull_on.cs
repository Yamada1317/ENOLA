using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pull_on : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private grounddata Grounddata;
    [SerializeField] private Prismdata prismdata;
    private float speed = 1.0f;
    private bool pull = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("player");
        Player = player.transform;

        GameObject dataobj = GameObject.FindWithTag("GroundData");
        Grounddata = dataobj.GetComponent<grounddata>();

        GameObject dataobj2 = GameObject.FindWithTag(" Prismdata");
        prismdata = dataobj2.GetComponent<Prismdata>();
    }

    // Update is called once per frame
    void Update()
    {
        if (prismdata.judge)
        {
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.position - transform.position), 1.0f);
            this.transform.position += transform.forward * speed;
        }
        else
        {
            if (Grounddata.movejudge)
            {
                this.transform.Translate(0f, 0f, Grounddata.speed);
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }
}
