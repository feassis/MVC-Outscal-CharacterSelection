using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveServices : MonoBehaviour 
{
    [SerializeField] private List<EnemySO> enemiesSOs;
    [SerializeField] private List<Transform> spawnPosistions = new List<Transform>();

    private TankController player;
    public List<EnemyController> enemyControllers {  get; private set; } = new List<EnemyController>();

    public void Init(TankController player)
    {
        this.player = player;
        var enemySO = GetEnemySOByType(EnemyType.Scout);
        EnemyModel enemyModel = new EnemyModel(enemySO);
        enemyControllers.Add(new EnemyController(enemyModel, enemySO.EnemyView, spawnPosistions[0], this.player, enemySO.BulletView, enemySO.MortarTarget));
    }

    

    private EnemySO GetEnemySOByType(EnemyType type)
    {
        return enemiesSOs.Find(s => s.Type == type);
    }
}
