using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel tankModel,TankView tankView)
    {
        this.tankModel = tankModel;

        this.tankView = GameObject.Instantiate(tankView);
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
    }
}
