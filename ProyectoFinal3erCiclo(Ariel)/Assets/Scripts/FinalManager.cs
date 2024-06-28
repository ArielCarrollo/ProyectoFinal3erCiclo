using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalManager : MonoBehaviour
{
    public GaugeData gaugestatus;
    public MyOwnTree<Image> EndsTree;
    public Image Root;
    public Image Final1;
    public Image Final2;
    public Image Final3;
    public Image Final4;
    public Image Final5;
    public Image finalImage;

    void Start()
    {
        EndsTree = new MyOwnTree<Image>();
        if (Root == null)
        {
            Debug.LogError("Root no está asignado.");
            return;
        }

        EndsTree.AddNode(Root, Root); 
        EndsTree.AddNode(Final1, Root);
        EndsTree.AddNode(Final2, Root);
        EndsTree.AddNode(Final3, Root);
        EndsTree.AddNode(Final4, Root);
        EndsTree.AddNode(Final5, Root);

        if (gaugestatus != null)
        {
            finalImage.sprite = GetFinalBasedOnGauge(gaugestatus.currentValue).sprite;
        }
    }

    public Image GetFinalBasedOnGauge(float gaugeValue)
    {
        Image final = Root;

        if (gaugeValue == 20f)
        {
            final = EndsTree.FindNode(Final1).Value;
        }
        else if (gaugeValue == 40f)
        {
            final = EndsTree.FindNode(Final2).Value;
        }
        else if (gaugeValue == 60f)
        {
            final = EndsTree.FindNode(Final3).Value;
        }
        else if (gaugeValue == 80f)
        {
            final = EndsTree.FindNode(Final4).Value;
        }
        else if (gaugeValue == 100f)
        {
            final = EndsTree.FindNode(Final5).Value;
        }
        return final;
    }
}


