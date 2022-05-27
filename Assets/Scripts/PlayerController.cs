using UnityEngine;
using UnityEngine.InputSystem;

namespace GameDevJAM
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject m_Prefab;
        [SerializeField] private InputActionAsset m_Actions;
        [SerializeField] private float m_MovementSpeed;
        [SerializeField] private float m_JumpForce;
        [SerializeField] private GameObject m_BulletPrefab;
        [SerializeField] private Transform m_BulletSpawnPoint;
        [SerializeField] private AudioClip m_BulletSound;

        private AudioSource m_AudioSource;


        // Dynamic Adds
        private PlayerInput m_PlayerInput;
        private CharacterController m_CharacterController;
        private PlayerControlletInputs m_Input;
        private GameManager m_GameManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Pickup>(out Pickup pickup))
            {
                pickup.Perform();
            }
            if (other.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                obstacle.Crashed();
            }
            if(other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Crashed(2);
            }

        }

        private void Awake()
        {
            if (GetComponent<PlayerInput>() == null)
            {
                this.gameObject.AddComponent<PlayerInput>();
                GetComponent<PlayerInput>().actions = m_Actions;
                GetComponent<PlayerInput>().ActivateInput();
            }
            if (GetComponent<CharacterController>() == null)
            {
                this.gameObject.AddComponent<CharacterController>();
                GetComponent<CharacterController>().height = 1.8f;
            }
            if (GetComponent<PlayerControlletInputs>() == null)
            {
                this.gameObject.AddComponent<PlayerControlletInputs>();
            }

        }
        private void Start()
        {
            gameObject.AddComponent<AudioSource>();
            m_AudioSource = gameObject.GetComponent<AudioSource>();
            m_Input = GetComponent<PlayerControlletInputs>();
            m_CharacterController = GetComponent<CharacterController>();
            m_PlayerInput = GetComponent<PlayerInput>();
            m_GameManager = FindObjectOfType<GameManager>();
        }

        private void Move()
        {
            float targetspeed;

            targetspeed = m_MovementSpeed;
            if (m_Input.GetMove() == 0) targetspeed = 0;

            if (m_Input.GetMove() != 0)
            {
                m_CharacterController.SimpleMove(new Vector3(m_Input.GetMove(), 0, 0) * m_MovementSpeed);
            }


        }

        private void Shoot()
        {
            if (m_Input.GetShoot() && m_GameManager.GetBullets() > 0)
            {
                Instantiate(m_BulletPrefab, m_BulletSpawnPoint.position, m_BulletSpawnPoint.rotation);
                m_AudioSource.clip = m_BulletSound;
                m_AudioSource.Play();
                m_GameManager.BulletsDown();
            }
            m_Input.ShootInput(false);
        }

        private void Pause()
        {
            if (m_Input.GetPause())
            {
                m_GameManager.TogglePauaseGame();
                Debug.Log(m_GameManager.isGamePaused());
            }
            m_Input.PauseInput(false);
        }

        private void Update()
        {
            if (!m_GameManager.isGamePaused())
            {
                Move();
                Shoot();
            }
            Pause(); 
        }
    }
}