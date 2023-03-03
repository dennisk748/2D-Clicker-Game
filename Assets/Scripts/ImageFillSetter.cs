using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFillSetter : MonoBehaviour
{
    public EnemyData enemyData;


    public float Min;


    public Image Image;

    private void Update()
    {
        Image.fillAmount = Mathf.Clamp01(
            Mathf.InverseLerp(Min, enemyData.m_StartingHP.Value, enemyData.m_HealthPoints.Value));
    }

    public void NextEnemy(EnemyData newEnemyData)
    {
        enemyData = newEnemyData;
    }
}
