using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{

    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Animator playerAnimator;

        public void UpdatePlayerPosition(InputSystem inputSystem)
        {
            playerMovement.UpdateMovement(inputSystem);
        }

        public void EnablePlayer()
        {
            playerMovement.enabled = true;
            playerAnimator.SetTrigger("Active");
        }

        public void DisablePlayer()
        {
            playerMovement.enabled = false;
            playerAnimator.SetTrigger("NotActive");
        }

    }
}
