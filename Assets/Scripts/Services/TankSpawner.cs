using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankPrefab;

    private void Start()
    {
        
    }

    public TankController CreateTank(Tank tank, WaveServices waveService, UIService uiService)
    {
        TankModel tankModel = new TankModel(tank);
        TankController tankControler = new TankController(tankModel, tankPrefab, waveService, uiService);

        return tankControler;
    }
}
