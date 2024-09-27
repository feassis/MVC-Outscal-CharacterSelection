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
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(tankList[0].tankType, tankList[0].movementSpeed, 
            tankList[0].rotationSpeed, tankList[0].Color);
        TankController tankControler = new TankController(tankModel, tankPrefab);
    }
}
