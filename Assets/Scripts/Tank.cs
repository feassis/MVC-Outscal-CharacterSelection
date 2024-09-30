using System;
using UnityEngine;

[Serializable]
public class Tank
{
    public TankTypes tankType;
    public float movementSpeed = 20f;
    public float rotationSpeed = 60f;
    public Material Color;
    public float MinShootingForce = 15f;
    public float MaxShooingForce = 30f;
    public float MaxChargeTime = 0.75f;
    public float BlastRadious = 0.2f;
    public int Piercing = 0;
    public int Damage = 10;
    public bool IsHommingMissle = false;
    public bool AffectedByGravity = true;
}
