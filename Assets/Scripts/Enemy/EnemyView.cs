using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour, IDamageble
{
    [SerializeField] private GameObject targetMarker;
    [field: SerializeField] public Transform CenterOfMass {  get; private set; }
    [SerializeField] private EnemyHealthBar healthBar;

    [SerializeField] private Transform turret;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private LayerMask playerLayer;

    private const float rayCastDistance = 150f;
    
    public NavMeshAgent Agent {  get; private set; }

    private EnemyController enemyController;
    public Rigidbody Rb { get; private set; }

    public Transform GetFiringTransform() => fireTransform;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        enemyController.SetMovementTarget();
        RotateTurretTowardsPlayer();
        enemyController.ProcessAttack();
    }

    public bool TorretCanDirectHitPlayer()
    {
        Vector3 directionToPlayer = enemyController.GetPlayerPos() - fireTransform.position;
        bool hitPlayer = false;

        RaycastHit hit;
        if (Physics.Raycast(fireTransform.position, directionToPlayer, out hit, rayCastDistance, playerLayer))
        {
            if (hit.transform == enemyController.GetPlayerTransform())
            {
                Debug.Log("Player detected!");
                hitPlayer = true;
            }
        }

        // Desenhar o raycast no Editor da Unity para visualização
        Debug.DrawRay(transform.position, directionToPlayer.normalized * rayCastDistance, Color.red);
        return hitPlayer;
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void RotateTurretTowardsPlayer()
    {
        TurretLookAtTargetUsingQuaternion(enemyController.GetPlayerPos());
    }

    void TurretLookAtTargetUsingQuaternion(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - turret.transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        turret.transform.rotation = lookRotation;
    }

    public void IsBeingTarget(bool isBeingTarget)
    {
        targetMarker.SetActive(isBeingTarget);
    }

    public void UpdadeHealthBar(float healthPercentage)
    {
        healthBar.UpdateBar(healthPercentage);
    }

    public void TakeDamage(int damage, int piercing)
    {
        enemyController.TakeDamage(damage, piercing);
    }
}
