using UnityEngine;

namespace GameCore
{
    public class YellowBlock : MonoBehaviour
    {
        [SerializeField] private AudioSource destroyBlock;
        [SerializeField] private int pointsValue;
        [SerializeField] private ScoreSystem scoreSystem;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "Player3")
            {
                destroyBlock.Play();
                scoreSystem.AddPoints(pointsValue);
                gameObject.SetActive(false);
            }

        }
    }
}