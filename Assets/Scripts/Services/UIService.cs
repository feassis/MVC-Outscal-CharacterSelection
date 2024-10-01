using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIService : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    public void UpdateHealth(int currentHP)
    {
        healthText.text = currentHP.ToString();
    }
}
