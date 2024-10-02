using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI currentWaveText;
    [SerializeField] private TextMeshProUGUI maxWaveText;
    [SerializeField] private TextMeshProUGUI enemiesText;
    [SerializeField] private GameObject NextWaveText;
    [SerializeField] private TextMeshProUGUI NextWaveAmountText;
    [SerializeField] private GameObject endGamePopUp;
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateHealth(int currentHP)
    {
        healthText.text = currentHP.ToString();
    }

    public void UpdateWaveText(int currentWave, int maxWave)
    {
        currentWaveText.text = currentWave.ToString();
        maxWaveText.text = maxWave.ToString();
    }

    public void UpdateEnemiesText(int enemyCount)
    {
        enemiesText.text = enemyCount.ToString();
    }

    public void UpdateNextWaveText(bool isOn, int secondsToNextWave)
    {
        NextWaveText.SetActive(isOn);
        NextWaveAmountText.text = secondsToNextWave.ToString();
    }

    public void EndGamePopup(bool won)
    {
        Time.timeScale = 0;
        endGamePopUp.SetActive(true);
        endGameText.text = won ? "Victory!! :)" : "Defeat! :(";
    }
}
