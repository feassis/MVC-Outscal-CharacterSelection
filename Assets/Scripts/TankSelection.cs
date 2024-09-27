using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawner tankSpawner;

    public void SelectGreenTank()
    {
        Debug.Log("Green Tank");
        
        tankSpawner.CreateTank(TankTypes.GreenTank);
        gameObject.SetActive(false);
    }

    public void SelectBlueTank()
    {
        Debug.Log("Blue Tank");
        gameObject.SetActive(false);
        tankSpawner.CreateTank(TankTypes.BlueTank);
    }

    public void SelectRedTank()
    {
        Debug.Log("Red Tank");
        gameObject.SetActive(false);
        tankSpawner.CreateTank(TankTypes.RedTank);
    }
}
