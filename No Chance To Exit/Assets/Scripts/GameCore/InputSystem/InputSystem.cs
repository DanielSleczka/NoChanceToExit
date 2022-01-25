using GameUI;
using UnityEngine;

namespace GameCore
{
    public class InputSystem : MonoBehaviour
    {
        [SerializeField]
        private PauseView pauseView;

        private bool isActive = false;
        private bool isEnabled = false;
        private float horizontalValue = 0f;
        private float verticalValue = 0f;

        public float GetHorizontalInput()
        {
            return horizontalValue;
        }

        public float GetVerticalInput()
        {
            return verticalValue;
        }

        public void EnableInput()
        {
            isEnabled = true;
        }

        public void DisableInput()
        {
            isEnabled = false;
            horizontalValue = 0f;
            verticalValue = 0f;
        }

        public void UpdateInput()
        {
            if (!isEnabled)
            {
                return;
            }

            horizontalValue = Input.GetAxis("Horizontal");
            verticalValue = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isActive)
                {
                    pauseView.ShowView();
                    isActive = true;
                    Time.timeScale = 0; 
                }
                else if (isActive)
                {
                    pauseView.HideView();
                    isActive = false; 
                }
            }

        }

    }
}
