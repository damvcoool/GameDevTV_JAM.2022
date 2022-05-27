using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace GameDevJAM
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private ScoreAndDificulty m_Score;
        [SerializeField] private TextMeshProUGUI m_CurrentScoreUI;
        [SerializeField] private TextMeshProUGUI m_CurrentBulletsUI;
        [SerializeField] private TextMeshProUGUI m_CurrentLivesUI;
        [SerializeField] private GameObject PauseUI;
        [SerializeField] private SceneLoader loader;

        private AudioSource m_AudioSource;
        
        private bool m_Pause = false;
        public bool isGamePaused() => m_Pause;
        public void ScoreUp() => m_Score.AddScore();
        public void ScoreUp(int amount) => m_Score.AddScore(amount);
        public void ScoreDown() => m_Score.ReduceScore();
        public void SpeedUp() => m_Score.IncreaseSpeed();
        public void SpeedDown(float amount) => m_Score.IncreaseSpeed(amount);
        public void BulletsUp(int amount) => m_Score.AddBullets(amount);
        public void BulletsDown() => m_Score.RemoveBullets();
        public int GetBullets() => m_Score.bullets;
        public int GetScore() => m_Score.m_Score;
        public int GetLives() => m_Score.m_lives;
        public float GetWorldSpeed() => m_Score.m_WorldSpeed;
        public float GetMinWorldSpeed() => m_Score.m_MinWorldSpeed;
        public void IncreaseMinWorldSpeed() => m_Score.IncreaseMinWorldSpeed();
        public void DecreaseLive() => m_Score.DecreaseLives();

        private void Start()
        {
            m_AudioSource = gameObject.AddComponent<AudioSource>();
            m_AudioSource.loop = false;
            m_AudioSource.playOnAwake = false;
        }
        private void FixedUpdate()
        {
            m_CurrentBulletsUI.text = this.GetBullets().ToString();
            m_CurrentScoreUI.text = this.GetScore().ToString();
            m_CurrentLivesUI.text = this.GetLives().ToString();
            if(GetLives() <= 0)
            {
                loader.SceneLoad(2);
            }
            Camera.main.backgroundColor += new Color(0.0002f, 0.0002f, 0.0002f, 0.1f);
           // Camera.main.backgroundColor += new Color(0.01f, 0.01f, 0.01f);
            Debug.Log(Camera.main.backgroundColor);

            if (Camera.main.backgroundColor.a >= 700f)
            {
                loader.SceneLoad(3);
            }
        }
        public void TogglePauaseGame()
        {
            int time = 1;
            if (m_Pause)
            {
                m_Pause = false;
                time = 1;
            } else if (!m_Pause)
            {
                m_Pause = true;
                time = 0;
            }

            PauseUI.SetActive(m_Pause);
            Time.timeScale = time;
            loader.RefreshUI();
        }

        public void PlayFX(AudioClip audioClip)
        {
            m_AudioSource.clip = audioClip;
            m_AudioSource.Play();
        }
    }
}