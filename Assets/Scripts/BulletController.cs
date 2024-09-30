using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    private BulletModel bulletModel;
    private BulletView bulletView;

    public BulletController(BulletModel bulletModel, BulletView bulletView, Transform spawnTrasform)
    {
        this.bulletModel = bulletModel;
        this.bulletModel.SetBulletController(this);

        this.bulletView = GameObject.Instantiate<BulletView>(bulletView, spawnTrasform.position, spawnTrasform.rotation);
        this.bulletView.SetController(this);
        this.bulletView.SetVelocity(this.bulletModel.Velocity);

    }


}
