using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankPrefab;

    private void Start()
    {
        
    }

    public void CreateTank(Tank tank, WaveServices waveService)
    {
        TankModel tankModel = new TankModel(tank);
        TankController tankControler = new TankController(tankModel, tankPrefab, waveService);
    }
}
