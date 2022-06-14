using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdata : MonoBehaviour
{
    [SerializeField] public int playerstate;
    [SerializeField] public float HP;
    [SerializeField] public static float MP = 100;
    [SerializeField] public float decrease;
    [SerializeField] public bool movejudge = true;
    [SerializeField] public bool invisible = false;
    [SerializeField] public bool slowgo = false;

    public static bool Herugesuto_get = false;
}
