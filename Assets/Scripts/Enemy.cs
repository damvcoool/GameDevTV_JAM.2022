using UnityEngine;

namespace GameDevJAM
{
    public class Enemy : MonoBehaviour
    {
        // Exposed variables
        [SerializeField] private float m_Health = 2;
        [SerializeField] private int m_Value = 10;
        [SerializeField] private AudioClip m_Sound;

        private GameManager m_Manager;

        private void Start()
        {
            m_Manager = FindObjectOfType<GameManager>();
       }

        public void DoDamage()
        {
            if (m_Health <= 0)
            {
                m_Manager.ScoreUp(m_Value);
                gameObject.SetActive(false);
            }

            m_Health--;
            m_Manager.ScoreUp();
        }

        public void Crashed(int Multiplier)
        {
            m_Manager.PlayFX(m_Sound);
            m_Manager.ScoreUp(m_Value * -Multiplier);
            m_Manager.DecreaseLive();
            gameObject.GetComponentInParent<Transform>().gameObject.SetActive(false);
        }
    }
}