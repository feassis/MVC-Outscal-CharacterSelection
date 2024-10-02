using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyController
{
    private EnemyModel enemyModel;
    public EnemyView EnemyView {  get; private set; }

    private int currentHP = 0;

    private TankController player;

    private const float thetaTolerance = 90;

    private float attackCoolDown = 0;

    private BulletView bulletView;
    private GameObject mortarTarget;

    public Action<EnemyController> OnDeath;

    public EnemyController(EnemyModel enemyModel, EnemyView enemyView, Transform spawnPos, TankController tankController, BulletView bulletView, GameObject mortarTarget)
    {
        this.bulletView = bulletView;
        this.enemyModel = enemyModel;
        this.enemyModel.SetEnemyController(this);
        currentHP = this.enemyModel.Health;
        player = tankController;

        this.EnemyView = GameObject.Instantiate<EnemyView>(enemyView, spawnPos.position, Quaternion.identity);
        this.EnemyView.SetEnemyController(this);
        this.EnemyView.Agent.speed = enemyModel.MovementSpeed;
        this.EnemyView.Agent.angularSpeed = enemyModel.RotationSpeed;
        this.mortarTarget = mortarTarget;
    }

    public void TakeDamage(int damage, int piercing)
    {
        int processedDamage = damage - Mathf.Max(0, enemyModel.Defense - piercing);

        currentHP = Mathf.Max(0, currentHP - processedDamage);

        this.EnemyView.UpdadeHealthBar(currentHP/(float)enemyModel.Health);

        if(currentHP <= 0)
        {
            GameObject.Destroy(this.EnemyView.gameObject);
            OnDeath?.Invoke(this);
        }
    }

    public void SetMovementTarget()
    {
        switch (enemyModel.Type)
        {
            case EnemyType.Scout:
                SetMovementToPlayerFlank();
                break;
            case EnemyType.Heavy:
                SetMovementToPlayer();
                break;
            case EnemyType.Artilhary:
                SetMovementToAvoidPlayer();
                break;
            case EnemyType.None:
                break;
        }
    }

    public Vector3 GetPlayerPos() => player.GetTankTransform().position;
    public Transform GetPlayerTransform() => player.GetTankTransform();

    public void ProcessAttack()
    {
        if(attackCoolDown > 0)
        {
            attackCoolDown = Mathf.Max(0, attackCoolDown - Time.deltaTime);
            return;
        }

        if (CanAttack())
        {
            Shoot(enemyModel.BulletVelocity, bulletView);
            attackCoolDown = enemyModel.AttackCooldown;
        }

    }

    private void Shoot(float velocity, BulletView bulletView)
    {
        bool isAffectedByGravity = EnemyType.Artilhary == enemyModel.Type ? true : false;
        BulletModel bulletModel = new BulletModel(enemyModel.BlastRadious, enemyModel.Damage, enemyModel.Piercing, velocity, false, isAffectedByGravity);

        if(EnemyType.Artilhary == enemyModel.Type)
        {
            var target = GameObject.Instantiate<GameObject>(mortarTarget, GetPlayerPos(), Quaternion.identity);

            new HomingBulletController(bulletModel, bulletView, EnemyView.GetFiringTransform(), target.transform, true);
        }
        else
        {
            new BulletController(bulletModel, bulletView, EnemyView.GetFiringTransform());
        }
    }

    private bool CanAttack()
    {
        if(enemyModel.Type == EnemyType.Artilhary)
        {
            return true;
        }
        else if(enemyModel.Type == EnemyType.Scout || enemyModel.Type == EnemyType.Heavy)
        {
            return EnemyView.TorretCanDirectHitPlayer();
        }

        return false;
    }


    private void SetMovementToPlayerFlank()
    {
        if (EnemyView.Agent.isOnNavMesh)
        {
            if(Vector3.Distance(player.GetTankTransform().position, EnemyView.transform.position) < enemyModel.AvoidanceRange / 2)
            {
                EnemyView.Agent.destination = player.GetTankTransform().right * enemyModel.AvoidanceRange;
                return;
            }


            EnemyView.Agent.destination = RandomPointOnPerimeter.GetRandomPointBehind(player.GetTankTransform().position, player.GetTankTransform().forward,
                enemyModel.AvoidanceRange, thetaTolerance);
        }
    }

    private void SetMovementToPlayer()
    {
        if (EnemyView.Agent.isOnNavMesh)
        {
            EnemyView.Agent.destination = player.GetTankTransform().position;
        }
    }

    private void SetMovementToAvoidPlayer()
    {
        if (EnemyView.Agent.isOnNavMesh)
        {
            if (Vector3.Distance(player.GetTankTransform().position, EnemyView.transform.position) < enemyModel.AvoidanceRange / 2)
            {
                EnemyView.Agent.destination = player.GetTankTransform().right * enemyModel.AvoidanceRange * (-1);
                return;
            }

            EnemyView.Agent.destination = RandomPointOnPerimeter.GetRandomPointOnPerimeter(player.GetTankTransform().position, enemyModel.AvoidanceRange);
        }
    }

    
}
