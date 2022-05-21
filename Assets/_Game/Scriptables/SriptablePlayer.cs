using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptables/Player")]
public class SriptablePlayer : ScriptableObject
{
    private SriptablePlayer instance;

    [SerializeField] private GameObject Prefab;
    [SerializeField] private float maxHealth = 100;
    private float currentHealth;
    [SerializeField] private int deaths = 0;

    private void OnEnable()
    {
        instance = this;
        currentHealth = maxHealth;
        if (PlayerPrefs.HasKey("health"))
        {
            LoadData();
        }
    }

    public void HealUp(int amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
        }
    }

    public void Damage(int amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth -= amount;
        }
        
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        deaths--;
        Debug.Log("You Died");
        SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("health", currentHealth);
        PlayerPrefs.SetInt("deaths", deaths);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        currentHealth = PlayerPrefs.GetInt("health");
        deaths = PlayerPrefs.GetInt("deaths");
    }

}
