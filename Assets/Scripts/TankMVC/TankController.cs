using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    private Rigidbody rb;
    private WaveServices waveService;

    public TankController(TankModel tankModel,TankView tankView, WaveServices waveService)
    {
        this.tankModel = tankModel;
        this.waveService = waveService;

        this.tankView = GameObject.Instantiate<TankView>(tankView);
        
        this.tankModel.SetTankController(this);
        this.tankView.SetTankController(this);
        this.tankView.SetAimMaxCharge(this.tankModel.MaxChargeTime);
        this.tankView.SetIsGuided(this.tankModel.IsHommingMissle);

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

    public List<EnemyView> GetEnemies()
    {
        var enemies = waveService.enemyControllers;

        List<EnemyView> enemyViews = new List<EnemyView>();
        
        foreach (var enemy in enemies)
        {
            enemyViews.Add(enemy.EnemyView);
        }

        return enemyViews;
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }

    public void Shoot(float aimPercentage, BulletView bulletView)
    {
        float firingForce = (tankModel.MaxShootingForce - tankModel.MinShootingForce) * aimPercentage 
            + this.tankModel.MinShootingForce;

        BulletModel buletModel = new BulletModel(tankModel.BlastRadious, tankModel.Damage, tankModel.Piercing, firingForce,
            tankModel.IsHommingMissle, tankModel.AffectedByGravity);
        

        if (tankModel.IsHommingMissle && tankView.Target != null)
        {
            new HomingBulletController(buletModel, bulletView, tankView.hommingSpawnPosition, tankView.Target.CenterOfMass);
        }
        else if(!tankModel.AffectedByGravity)
        {
            new BulletController(buletModel, bulletView, tankView.piercingSpawnPosition);
        }
        else
        {
            new BulletController(buletModel, bulletView, tankView.projectileSpawnPosition);
        }
    }
}
