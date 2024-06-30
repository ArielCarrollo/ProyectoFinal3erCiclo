using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public TextMeshProUGUI FinalDescriptionText;

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

        if (gaugeValue <= 20f)
        {
            final = EndsTree.FindNode(Final1).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia es inutil, probablemente no sobrevivas.";
        }
        else if (gaugeValue <= 40f && gaugeValue > 20)
        {
            final = EndsTree.FindNode(Final2).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia tiene poca utilidad, probablemente sobrevivas a rastras.";
        }
        else if (gaugeValue <= 60f && gaugeValue > 40)
        {
            final = EndsTree.FindNode(Final3).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia tiene media utilidad, probablemente sobrevivas a con heridas que necesiten tratarse.";
        }
        else if (gaugeValue <= 80f && gaugeValue > 60)
        {
            final = EndsTree.FindNode(Final4).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia tiene mucha utilidad, sobreviviras.";
        }
        else if (gaugeValue <= 100f && gaugeValue > 80)
        {
            final = EndsTree.FindNode(Final5).Value;
            FinalDescriptionText.text = "Tu mochila de emergencia es de total utilidad, sobreviviras e incluso ayudarás a otros.";
        }
        return final;
    }
}


