using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static Tank selectedTank;
    [SerializeField] private TankSpawner spawner;

    public static void StartGame(Tank tank)
    {
        selectedTank = tank;
        SceneManager.LoadScene("Game");
    }

    private void Start()
    {
        spawner.CreateTank(selectedTank);
    }
}
