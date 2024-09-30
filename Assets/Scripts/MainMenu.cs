using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private List<TankSelection> tankList;
    [SerializeField] private Button startButton;

    private Tank selectedTank;

    [Serializable]
    private class TankSelection
    {
        public Tank Tank;
        public Button SelectionButton;
        public GameObject TankDisplay;
    }

    private void Awake()
    {
        selectedTank = tankList[0].Tank;

        foreach( TankSelection tank in tankList )
        {
            tank.SelectionButton.onClick.AddListener(() => SelectTank(tank));
        }
        
        startButton.onClick.AddListener(StartGame);
    }

    private void SelectTank(TankSelection tankSelection)
    {
        foreach(TankSelection tank in tankList )
        {
            if(tank == tankSelection)
            {
                selectedTank = tank.Tank;
                tank.TankDisplay.SetActive(true);
            }
            else
            {
                tank.TankDisplay.SetActive(false);
            }
        }
    }

    private void StartGame()
    {
        GameManager.StartGame(selectedTank);
    }
}
