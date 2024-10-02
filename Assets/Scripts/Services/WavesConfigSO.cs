using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new wave config", menuName ="WaveConfig")]
public class WavesConfigSO : ScriptableObject
{
    public List<Wave> waves;
}
