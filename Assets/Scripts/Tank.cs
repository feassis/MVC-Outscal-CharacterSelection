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
}
