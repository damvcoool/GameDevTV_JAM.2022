using System.Collections.Generic;
using UnityEngine;

namespace GameDevJAM
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField] private List<GameObject> m_Tiles = new List<GameObject>();
        public static Spawner SharedInstance;
        public List<GameObject> pooledObjects;
        public int amountToPoolPerType = 2;

        private GameObject objectToPool;

        void Awake()
        {
            SharedInstance = this;
        }

        void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for (int j = 0; j < m_Tiles.Count; j++)
            {
                objectToPool = m_Tiles[j];
                for (int i = 0; i < amountToPoolPerType; i++)
                {
                    tmp = Instantiate(objectToPool,this.transform);
                    tmp.SetActive(false);
                    pooledObjects.Add(tmp);
                }
            }
            
        }
        public GameObject GetPooledObject()
        {
            GameObject tmp;
                do
                {
                    tmp = pooledObjects[Random.Range(0, pooledObjects.Count)];
                    if (!tmp.activeInHierarchy)
                    {
                        return tmp;
                    }
                } while (tmp.activeInHierarchy);
            return null;
        }
        public void SpawnNewTile()
        {
            GameObject tile = GetPooledObject();
            if (tile != null)
            {
                tile.transform.parent = this.transform;
                tile.transform.position = this.transform.position;
                tile.transform.rotation = this.transform.rotation;
                tile.SetActive(true);
            }
        }
    }
}