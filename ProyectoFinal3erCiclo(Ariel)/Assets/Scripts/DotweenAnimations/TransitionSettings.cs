using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransitionSettings : MonoBehaviour
{
    public Transform UIobject;
    public Transform objetive;
    public Transform objetiveReverse;

    public void Move()
    {
        UIobject.DOMove(objetive.position, 1f);
    }
    public void ReverseMove()
    {
        UIobject.DOMove(objetiveReverse.position, 1f);
    }
}
