using UnityEngine;
using UnityEngine.InputSystem;

namespace GameDevJAM
{
    public class PlayerControlletInputs : MonoBehaviour
    {
        private float Move;
        private bool Pause;
        private bool Shoot;

        // Getters
        public float GetMove() => Move;
        public bool GetPause() => Pause;
        public bool GetShoot() => Shoot;

        // On Going Methods
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<float>());
        }
        public void OnPause(InputValue value)
        {
            PauseInput(value.isPressed);
        }
        public void OnShoot(InputValue value)
        {
            ShootInput(value.isPressed);
        }

        // Input Methods
        public void MoveInput(float newMoveDirection)
        {
            Move = newMoveDirection;
        }
        public void PauseInput(bool newPauseState)
        {
            Pause = newPauseState;
        }
        public void ShootInput(bool newShootState)
        {
            Shoot = newShootState;
        }

    }
}