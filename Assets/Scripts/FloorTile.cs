using System.Collections.Generic;
using UnityEngine;

namespace GameDevJAM
{
    public class FloorTile : MonoBehaviour
    {
        [SerializeField] private List<GameObject> m_EnemiesAndPickups = new List<GameObject>();
        private GameManager m_GameManager;

        private void Awake()
        {
            m_GameManager = FindObjectOfType<GameManager>();
        }

        private void OnEnable()
        {
            int num = (int)Random.Range(0, m_EnemiesAndPickups.Count);
            foreach (GameObject item in m_EnemiesAndPickups)
            {
                item.SetActive(false);
            }
            m_EnemiesAndPickups[num].SetActive(true);
            foreach (Transform item in m_EnemiesAndPickups[num].transform.GetComponentInChildren<Transform>(true))
            {
                item.gameObject.SetActive(true);
            }
        }

        private void OnDisable()
        {
                m_GameManager.SpeedUp();
        }

        private void Update()
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * m_GameManager.GetWorldSpeed());
        }
    }
}