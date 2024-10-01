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

    public void CalculateBlastZone()
    {
        List<Collider> colliders = new List<Collider>();

        colliders.AddRange(Physics.OverlapSphere(bulletView.transform.position, bulletModel.BlastRadious));

        foreach (Collider collider in colliders)
        {
            if(collider.gameObject.TryGetComponent<IDamageble>(out IDamageble damageble))
            {
                damageble.TakeDamage(bulletModel.Damage, bulletModel.Piercing);
            }
        }

        GameObject.Destroy(bulletView.gameObject);
    }
}

public class HomingBulletController : BulletController
{
    private Transform target;

    public HomingBulletController(BulletModel bulletModel, BulletView bulletView, Transform spawnTransform, Transform target, bool destroyTarget = false)
        : base(bulletModel, bulletView, spawnTransform) 
    {
        this.target = target;
        this.bulletView.SetDestroyTarget(destroyTarget);
        this.bulletView.SetTarget(target);
    }
}
