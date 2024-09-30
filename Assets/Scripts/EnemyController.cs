using UnityEngine;

public class EnemyController
{
    private EnemyModel enemyModel;
    public EnemyView EnemyView {  get; private set; }

    public EnemyController(EnemyModel enemyModel, EnemyView enemyView, Transform spawnPos)
    {
        this.enemyModel = enemyModel;
        this.enemyModel.SetEnemyController(this);

        this.EnemyView = GameObject.Instantiate<EnemyView>(enemyView, spawnPos.position, Quaternion.identity);
        this.EnemyView.SetEnemyController(this);
    }
}
