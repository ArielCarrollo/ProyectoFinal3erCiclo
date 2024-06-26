using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimesData", menuName = "Game/BestTimetoComplete", order = 1)]
public class TimeData : ScriptableObject
{
    [System.Serializable]
    public struct BestTimeData
    {
        public string playerName;
        public float time;
    }
    public ListaInventadaPropia<BestTimeData> Times = new ListaInventadaPropia<BestTimeData>();
}
