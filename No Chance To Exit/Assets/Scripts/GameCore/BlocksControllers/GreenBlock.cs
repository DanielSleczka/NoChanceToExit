using UnityEngine;

namespace GameCore
{
    public class GreenBlock : MonoBehaviour
    {
        [SerializeField] private AudioSource destroyBlock;
        [SerializeField] private int pointsValue;
        [SerializeField] private ScoreSystem scoreSystem;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "Player2")
            {
                destroyBlock.Play();
                scoreSystem.AddPoints(pointsValue);
                gameObject.SetActive(false);
            }

        }
    }
}