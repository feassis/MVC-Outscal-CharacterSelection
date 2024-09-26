using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }


    public TankModel(float movement, float rotation)
    {
        this.movementSpeed = movement;
        this.rotationSpeed = rotation;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
