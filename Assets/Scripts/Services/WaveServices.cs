using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveServices : MonoBehaviour 
{
    [SerializeField] private EnemyView enemyPrefab;
    [SerializeField] private List<Transform> spawnPosistions = new List<Transform>();
    public List<EnemyController> enemyControllers {  get; private set; } = new List<EnemyController>();

    private void Start()
    {
        EnemyModel enemyModel = new EnemyModel();
        enemyControllers.Add(new EnemyController(enemyModel, enemyPrefab, spawnPosistions[0]));
    }
}
