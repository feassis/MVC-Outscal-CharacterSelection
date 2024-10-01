using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Image ReactionFillImage;
    [SerializeField] private float barUpdateSpeed = 0.5f;

    private float barTarget;

    private void Start()
    {
        barTarget = 1;
        fillImage.fillAmount = 1;
        ReactionFillImage.fillAmount = 1;
    }

    public void UpdateBar(float healthPercentage)
    {
        fillImage.fillAmount = healthPercentage;
        barTarget = healthPercentage;

    }

    private void Update()
    {
        ReactionFillImage.fillAmount = Mathf.Lerp(barTarget, ReactionFillImage.fillAmount, barUpdateSpeed* Time.deltaTime);
    }
}
