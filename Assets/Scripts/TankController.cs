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
        this.rb = this.tankView.Rb;
        this.tankView.ChangeColor(this.tankModel.color);
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
}
