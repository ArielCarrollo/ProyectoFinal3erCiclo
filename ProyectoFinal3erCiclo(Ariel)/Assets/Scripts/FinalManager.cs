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
        // Ajusta las relaciones de nodos según sea necesario
        EndsTree.AddNode(Final1, Root);
        EndsTree.AddNode(Final2, Root);
        EndsTree.AddNode(Final3, Root);
        EndsTree.AddNode(Final4, Root);

        // Asegúrate de que gaugestatus esté inicializado antes de llamar GetFinalBasedOnGauge()
        if (gaugestatus != null)
        {
            finalImage.sprite = GetFinalBasedOnGauge(gaugestatus.currentValue).sprite;
        }
        else
        {
            Debug.LogError("GaugeData no está asignado en FinalManager.");
        }
    }

    public Image GetFinalBasedOnGauge(float gaugeValue)
    {
        Image Final = Root;

        // Ajusta las condiciones según sea necesario
        if (gaugeValue == 20f)
        {
            Final = Final1;
        }
        else if (gaugeValue == 40f)
        {
            Final = Final2;
        }
        else if (gaugeValue == 60f)
        {
            Final = Final3;
        }
        else if (gaugeValue == 80f)
        {
            Final = Final4;
        }
        else if (gaugeValue == 100f)
        {
            Final = Final5;
        }
        // Añade más casos según sea necesario

        return Final;
    }
}

