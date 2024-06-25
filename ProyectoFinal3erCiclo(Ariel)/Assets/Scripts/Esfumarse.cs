using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EsfumarseAlRecoger : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(Vector3.zero, 1f).OnComplete(() => {
            gameObject.SetActive(false);
        });
    }
}
