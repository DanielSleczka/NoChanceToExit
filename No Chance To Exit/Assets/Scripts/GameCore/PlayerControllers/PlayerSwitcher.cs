using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class PlayerSwitcher : MonoBehaviour
    {
        [SerializeField] private Player[] players;

        private Player player;

        public void InitializePlayer()
        {
            SwitchPlayer(0);
        }

        private void SwitchPlayer(int newPlayer)
        {
            player?.DisablePlayer();
            player = players[newPlayer];
            player.EnablePlayer();
        }

        public void ChangePlayer()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchPlayer(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchPlayer(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwitchPlayer(2);
            }
        }

        public void UpdatePlayer(InputSystem inputSystem)
        {
            player.UpdatePlayerPosition(inputSystem);
            ChangePlayer();
        }
        
    }
}


