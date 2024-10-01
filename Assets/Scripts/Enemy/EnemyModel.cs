public class EnemyModel
{
    private EnemyController enemyController;

    public EnemyType Type {  get; private set; }
    public int Health { get; private set; }
    public int Defense { get; private set; }
    public int Piercing { get; private set; }
    public int Damage { get; private set; }
    public float BlastRadious { get; private set; }
    public float MovementSpeed { get; private set; }
    public float RotationSpeed { get; private set; }
    public float AttackCooldown { get; private set; }
    public float AttackRange { get; private set; }
    public float AvoidanceRange { get; private set; }
    public float BulletVelocity { get; private set; }


    public EnemyModel(EnemySO enemySO)
    {
        Type = enemySO.Type;
        Health = enemySO.Health;
        Defense = enemySO.Defense;
        Piercing = enemySO.Piercing;
        Damage = enemySO.Damage;
        BlastRadious = enemySO.BlastRadious;
        MovementSpeed = enemySO.MovementSpeed;
        RotationSpeed = enemySO.RotationSpeed;
        AttackCooldown = enemySO.AttackCooldown;
        AttackRange = enemySO.AttackRange;
        AvoidanceRange = enemySO.AvoidanceRange;
        BulletVelocity = enemySO.BulletVelocity;
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
}