using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankPrefab;

    private void Start()
    {
        Instantiate(tankPrefab, transform.position, Quaternion.identity) ;
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel();
        TankController tankControler = new TankController(tankModel, tankPrefab);

    }
}
