using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    private Rigidbody rb;

    public TankController(TankModel tankModel,TankView tankView)
    {
        this.tankModel = tankModel;

        this.tankView = GameObject.Instantiate<TankView>(tankView);
        
        this.tankModel.SetTankController(this);
        this.tankView.SetTankController(this);
        this.tankView.SetAimMaxCharge(this.tankModel.MaxChargeTime);
        this.rb = this.tankView.Rb;
        this.tankView.ChangeColor(this.tankModel.Color);
    }

    public void Move(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movementSpeed * movement;
    }

    public void Rotate(float rotation, float rotationSpeed)
    {
        Vector3 vector = new Vector3(0f, rotation * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }

    public void Shoot(float aimPercentage, BulletView bulletView, Transform fireTrasform)
    {
        float firingForce = (tankModel.MaxShootingForce - tankModel.MinShootingForce) * aimPercentage 
            + this.tankModel.MinShootingForce;

        BulletModel buletModel = new BulletModel(firingForce);
        new BulletController(buletModel, bulletView, fireTrasform);
    }
}
