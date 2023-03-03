using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEnemyHP : MonoBehaviour
{
    public EnemyData enemyData;

    public bool ResetHP;

    public void Start()
    {
        if (ResetHP)
            enemyData.m_HealthPoints.SetValue(enemyData.m_StartingHP);
    }
    public void NextEnemy(EnemyData newEnemyData)
    {
        enemyData = newEnemyData;
    }
}
