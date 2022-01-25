using GameUI;
using UnityEngine;

namespace GameCore
{
    public class InformationBoard : MonoBehaviour
    {
        [SerializeField] private InstructionView instructionView;

        public void OnTriggerEnter2D(Collider2D collider)
        {
            Time.timeScale = 0;
            instructionView.ShowView();
            this.GetComponent<BoxCollider2D>().enabled = false;
        }


    } 
}
