using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    protected BulletModel bulletModel;
    protected BulletView bulletView;

    public BulletController(BulletModel bulletModel, BulletView bulletView, Transform spawnTrasform)
    {
        this.bulletModel = bulletModel;
        this.bulletModel.SetBulletController(this);

        this.bulletView = GameObject.Instantiate<BulletView>(bulletView, spawnTrasform.position, spawnTrasform.rotation);
        this.bulletView.SetController(this);
        this.bulletView.SetVelocity(this.bulletModel.Velocity);
        this.bulletView.ToggleGravity(this.bulletModel.AffectedByGravity);
    }


}

public class HomingBulletController : BulletController
{
    private Transform target;

    public HomingBulletController(BulletModel bulletModel, BulletView bulletView, Transform spawnTransform, Transform target)
        : base(bulletModel, bulletView, spawnTransform) 
    {
        this.target = target;
        this.bulletView.SetTarget(target);
    }
}
