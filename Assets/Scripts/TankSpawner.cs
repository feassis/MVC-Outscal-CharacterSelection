using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankPrefab;

    [Serializable]
    public class Tank
    {
        public TankTypes tankType;
        public float movementSpeed = 20f;
        public float rotationSpeed = 60f;
        public Material Color;
    }

    public List<Tank> tankList;

    private void Start()
    {
        
    }

    public void CreateTank(TankTypes tankType)
    {
        Tank tank = tankList.Find(t => t.tankType == tankType);

        TankModel tankModel = new TankModel(tank.tankType, tank.movementSpeed, 
            tank.rotationSpeed, tank.Color);
        TankController tankControler = new TankController(tankModel, tankPrefab);
    }
}
