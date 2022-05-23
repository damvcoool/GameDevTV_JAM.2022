using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject m_Enemy;
    [SerializeField] private GameObject m_PatrolList;

    private void Start()
    {
        GameObject instance = Instantiate(m_Enemy, this.transform); 


        Enemy enemy = instance.GetComponent<Enemy>();

        enemy.Inspect(instance, 20, m_PatrolList);
    }

}
