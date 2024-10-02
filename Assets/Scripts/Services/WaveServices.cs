using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveServices : MonoBehaviour 
{
    [SerializeField] private List<EnemySO> enemiesSOs;
    [SerializeField] private List<Transform> spawnPosistions = new List<Transform>();
    [SerializeField] private WavesConfigSO wavesConfigSO;
    [SerializeField] private int timeBeetweenWaves = 5;
    [SerializeField] private AudioSource audioSource;

    private TankController player;
    public List<EnemyController> enemyControllers {  get; private set; } = new List<EnemyController>();

    private int enemyIndex = 0;
    private int waveIndex = 0;

    private UIService uiService;

    public void Init(TankController player, UIService uiService)
    {
        this.uiService = uiService;
        this.player = player;
        StartWave();
    }

    private void StartWave()
    {
        StartCoroutine(SpawnWaveEnemies());
    }

    private IEnumerator SpawnWaveEnemies()
    {
        yield return WaveInitialization();

        uiService.UpdateWaveText(waveIndex + 1, wavesConfigSO.waves.Count);

        while (enemyIndex < wavesConfigSO.waves[waveIndex].enemies.Count)
        {
            var enemySO = GetEnemySOByType(wavesConfigSO.waves[waveIndex].enemies[enemyIndex]);
            enemyIndex++;

            EnemyModel enemyModel = new EnemyModel(enemySO);
            var enemyControler = new EnemyController(enemyModel, enemySO.EnemyView, GetRandomSpawnPos(), this.player, enemySO.BulletView, enemySO.MortarTarget);
            enemyControler.OnDeath += OnEnemyControlerDeath;
            enemyControllers.Add(enemyControler);
            uiService.UpdateEnemiesText(enemyControllers.Count);
            
            yield return new WaitForSeconds(wavesConfigSO.waves[waveIndex].timeBetweenSpawns);
        }

        while (enemyControllers.Count > 0)
        {
            yield return null;
        }

        waveIndex++;

        if(waveIndex < wavesConfigSO.waves.Count)
        {
            StartWave();
        }
        else
        {
            uiService.EndGamePopup(true);
        }
    }

    private IEnumerator WaveInitialization()
    {
        audioSource.Play();  

        for(int i = 0; i < timeBeetweenWaves; i++)
        {
            uiService.UpdateNextWaveText(true, timeBeetweenWaves - i);
            yield return new WaitForSeconds(1f);
        }
        uiService.UpdateNextWaveText(false, 0);
    }

    private void OnEnemyControlerDeath(EnemyController controller)
    {
        enemyControllers.Remove(controller);
        uiService.UpdateEnemiesText(enemyControllers.Count);
    }

    private EnemySO GetEnemySOByType(EnemyType type)
    {
        return enemiesSOs.Find(s => s.Type == type);
    }

    private Transform GetRandomSpawnPos()
    {
        int sortedIndex = Random.Range(0, spawnPosistions.Count);

        return spawnPosistions[sortedIndex];
    }
}
