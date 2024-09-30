using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private GameObject targetMarker;
    [field: SerializeField] public Transform CenterOfMass {  get; private set; }


    private EnemyController enemyController;

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void IsBeingTarget(bool isBeingTarget)
    {
        targetMarker.SetActive(isBeingTarget);
    }
}
