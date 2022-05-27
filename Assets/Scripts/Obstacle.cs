using UnityEngine;

namespace GameDevJAM
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private AudioClip m_Sound;
        private GameManager m_Manager;

        private void Start()
        {
            m_Manager = FindObjectOfType<GameManager>();
        }
        public void Crashed()
        {
            m_Manager.PlayFX(m_Sound);
            m_Manager.ScoreDown();
            m_Manager.DecreaseLive();
            this.gameObject.GetComponentInParent<Transform>().gameObject.SetActive(false);
        }
    }
}