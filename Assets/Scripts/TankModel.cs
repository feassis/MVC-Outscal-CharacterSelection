using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public TankTypes tankType {  get; private set; }
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }
    public Material color {  get; private set; }


    public TankModel(TankTypes type, float movement, float rotation, Material color)
    {
        this.tankType = type;
        this.movementSpeed = movement;
        this.rotationSpeed = rotation;
        this.color = color;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
