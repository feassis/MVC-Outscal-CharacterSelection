using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private BulletController controller;
    public float Velocity { get; private set; }

    public BulletModel(float velocity)
    {
        Velocity = velocity;
    }

    public void SetBulletController(BulletController controller)
    {
        this.controller = controller;
    }
}
