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


    public TankModel(Tank tank)
    {
        this.TankType = tank.tankType;
        this.MovementSpeed = tank.movementSpeed;
        this.RotationSpeed = tank.rotationSpeed;
        this.Color = tank.Color;
        this.MinShootingForce = tank.MinShootingForce;
        this.MaxShootingForce = tank.MaxShooingForce;
        this.MaxChargeTime = tank.MaxChargeTime;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
