using UnityEngine;

namespace GameDevJAM
{
    public class Pickup : MonoBehaviour
    {

        [SerializeField] private bool Bullets;
        [SerializeField] private bool Slow;
        [SerializeField] private int BulletToAdd = 10;
        [SerializeField] private int SlowDown = -1;
        [SerializeField] private AudioClip m_Sound;

        private GameManager m_GameManager;
        private void Start()
        {
            m_GameManager = FindObjectOfType<GameManager>();

        }

        public void Perform()
        {
            m_GameManager.PlayFX(m_Sound);
            if(m_GameManager.GetWorldSpeed() < m_GameManager.GetMinWorldSpeed())
            {
                Slow = false;
            }
            if (this.Bullets)
            {
                m_GameManager.BulletsUp(BulletToAdd);
            }
            if (this.Slow)
            {
                m_GameManager.SpeedDown(SlowDown);
                m_GameManager.IncreaseMinWorldSpeed();
            }
            this.gameObject.GetComponentInParent<Transform>().gameObject.SetActive(false);
        }
    }
}