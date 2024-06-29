using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransitionGauge : MonoBehaviour
{
    public Transform Gauge;
    public Transform objetivo; 

    public void Move()
    {
        Gauge.DOMove(objetivo.position, 1f);
    }
}

