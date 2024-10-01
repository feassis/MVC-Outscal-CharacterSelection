using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyTankConfig", menuName ="")]
public class EnemySO : ScriptableObject
{
    public EnemyType Type;
    public int Health;
    public int Defense;
    public int Piercing;
    public int Damage;
    public float BlastRadious;
    public float MovementSpeed;
    public float RotationSpeed;
    public float AttackCooldown;
    public float AttackRange;
    public float AvoidanceRange;
    public EnemyView EnemyView;
    public float BulletVelocity = 100;
    public BulletView BulletView;
    public GameObject MortarTarget;
}
