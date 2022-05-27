using UnityEngine;

namespace GameDevJAM
{
    public class DeSpawner : MonoBehaviour
    {

        [SerializeField] private Spawner m_Spawner;

        private void OnTriggerEnter(Collider other)
        {
            if (m_Spawner != null)
            {
                m_Spawner.SpawnNewTile();
            }
            other.gameObject.SetActive(false);
        }

    }
}