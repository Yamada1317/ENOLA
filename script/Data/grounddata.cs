using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class grounddata : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float maxspeed;
    [SerializeField] public bool movejudge ;
    [SerializeField] public int groundcount;
    [SerializeField] public bool speedupjudge;
}
