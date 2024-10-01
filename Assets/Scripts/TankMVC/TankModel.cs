using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public TankTypes TankType {  get; private set; }
    public float MovementSpeed { get; private set; }
    public float RotationSpeed { get; private set; }
    public Material Color {  get; private set; }

    public float MinShootingForce { get; private set; } = 15f;

    public float MaxShootingForce { get; private set; } = 30f;

    public float MaxChargeTime { get; private set; } = 0.75f;

    public float BlastRadious {  get; private set; }
    public int Piercing {  get; private set; }
    public int Damage {  get; private set; }

    public bool IsHommingMissle { get; private set; }
    public bool AffectedByGravity { get; private set; }

    public int MaxHealth { get; private set; }
    public int Armor {  get; private set; }


    public TankModel(Tank tank)
    {
        this.TankType = tank.tankType;
        this.MovementSpeed = tank.movementSpeed;
        this.RotationSpeed = tank.rotationSpeed;
        this.Color = tank.Color;
        this.MinShootingForce = tank.MinShootingForce;
        this.MaxShootingForce = tank.MaxShooingForce;
        this.MaxChargeTime = tank.MaxChargeTime;
        this.BlastRadious = tank.BlastRadious;
        this.Piercing = tank.Piercing;
        this.Damage = tank.Damage;
        this.IsHommingMissle = tank.IsHommingMissle;
        this.AffectedByGravity = tank.AffectedByGravity;
        this.MaxHealth = tank.Health;
        this.Armor = tank.Armor;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
