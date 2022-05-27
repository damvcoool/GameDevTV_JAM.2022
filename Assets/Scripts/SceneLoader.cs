using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace GameDevJAM
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_HighScoreValue;
        [SerializeField] private ScoreAndDificulty score;
        [SerializeField] private AudioClip audioClip;
        private AudioSource audioSource;

        public void SceneLoad(int SceneIndex)
        {
            SceneManager.LoadScene(SceneIndex);
        }

        public void QuitGame() => Application.Quit();
        

        private void Start()
        {
            gameObject.AddComponent<AudioSource>();
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.loop = false;
            audioSource.clip = audioClip;

            score.m_WorldSpeed = 6;
            score.m_MinWorldSpeed = 10;
            score.m_lives = 3;
            score.bullets = 5;
            score.m_Score = 0;
            audioSource.PlayDelayed(2);
            m_HighScoreValue.text = score.m_HighScore.ToString();
        }
        public void RefreshUI()
        {
            m_HighScoreValue.text = score.m_HighScore.ToString();
        }
    }
}