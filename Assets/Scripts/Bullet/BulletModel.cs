using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private BulletController controller;
    public float BlastRadious {  get; private set; }

    public int Damage { get; private set; }

    public int Piercing { get; private set; }

    public float Velocity { get; private set; }

    public bool IsHommingMissle { get; private set; }
    public bool AffectedByGravity {  get; private set; }

    public BulletModel(float blastRadious, int damage, int piercing, float velocity, bool isHommingMissle, bool affectedByGravity)
    {
        BlastRadious = blastRadious;
        Damage = damage;
        Piercing = piercing;
        Velocity = velocity;
        IsHommingMissle = isHommingMissle;
        AffectedByGravity = affectedByGravity;
    }

    public void SetBulletController(BulletController controller)
    {
        this.controller = controller;
    }
}
