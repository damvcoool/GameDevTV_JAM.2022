using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    
    [SerializeField] private List<RoamPoint> m_RoamPoints = new List<RoamPoint>();
    [SerializeField] private Image m_HealthUI;
    [SerializeField] private float m_MaxHealth = 100;
    [SerializeField] private float m_Speed = 5;


    private float m_Health;
    private GameObject p_Target;
    private float p_Radius;


    private void Start()
    {
        m_RoamPoints.Clear();
        m_Health = m_MaxHealth;

    }
    private void Update()
    {
        m_HealthUI.fillAmount = m_Health / m_MaxHealth;
    }



    private void OnDie()
    {
        Destroy(this.gameObject);
    }

    private void RoamAround()
    {
        
    }

    public void Inspect(GameObject instance, float radius, GameObject PatrolPointList)
    {
        RoamPoint[] gameObjects = PatrolPointList.GetComponentsInChildren<RoamPoint>();
        foreach (RoamPoint roamPoint in gameObjects)
        {
            m_RoamPoints.Add(roamPoint);
        }
    }

    public void TakeDamage(float damage)
    {
        m_Health -= damage;
        if(m_Health <= 0)
        {
            this.OnDie();
        }
    }

    

}
