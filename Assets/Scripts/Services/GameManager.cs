using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static Tank selectedTank;
    [SerializeField] private TankSpawner spawner;
    [SerializeField] private WaveServices waveService;
    [SerializeField] private UIService uiService;

    private TankController player;

    public static void StartGame(Tank tank)
    {
        selectedTank = tank;
        SceneManager.LoadScene("Game");
    }

    private void Start()
    {
        player = spawner.CreateTank(selectedTank, waveService, uiService);
        waveService.Init(player);
    }
}
