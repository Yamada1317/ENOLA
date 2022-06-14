using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factorydata : MonoBehaviour
{
    [SerializeField] public int probability;
    [SerializeField] public float interval;
    [SerializeField] public float changeInterval;
    [SerializeField] public float changeProbability;
    [SerializeField] public int itemInterval;
    [SerializeField] public int laneInterval;
    [SerializeField] public float plicetalNum;
    [SerializeField] public bool factoryJudge = false;
    [SerializeField] public int location = 0;
    [SerializeField] public GameObject[] objects;

    public bool appearingJudge;
}
