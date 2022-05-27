using UnityEngine;

namespace GameDevJAM
{

    //[CreateAssetMenu(fileName = "Score Keeper", menuName = "Custom/Score Keeper")]
    public class ScoreAndDificulty : ScriptableObject
    {
        [SerializeField] public int m_lives = 3;
        [SerializeField] public float m_WorldSpeed = 5;
        [SerializeField] public float m_MinWorldSpeed = 8;
        [SerializeField] public int bullets = 5;
        [SerializeField] public int m_Score = 0;
        [SerializeField] public int m_HighScore = 0;

        public void IncreaseSpeed()
        {
            m_WorldSpeed += 0.05f;
        }
        public void IncreaseSpeed(float amount)
        {
            m_WorldSpeed += amount;
        }

        public void AddScore()
        {
            m_Score++;
            if(m_Score >= m_HighScore)
            {
                m_HighScore = m_Score;
            }
        }
        public void AddScore(int amount)
        {
            m_Score += amount;
            if (m_Score >= m_HighScore)
            {
                m_HighScore = m_Score;
            }
        }
        public void ReduceScore()
        {
            m_Score--;
        }

        public void AddBullets(int amount) => bullets += amount;
        public void RemoveBullets() => bullets--;
        public void IncreaseMinWorldSpeed() => m_MinWorldSpeed++;

        public void DecreaseLives() => m_lives--;
    }
}