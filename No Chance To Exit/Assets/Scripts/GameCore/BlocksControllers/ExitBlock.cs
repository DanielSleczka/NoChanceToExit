using GameCore;
using UnityEngine;
using UnityEngine.Events;

public class ExitBlock : MonoBehaviour
{
    private UnityAction finishedLevel;
    [SerializeField] private int pointsValue;
    [SerializeField] private ScoreSystem scoreSystem;

    private int playerCounter = 0;

    private bool levelIsDone = false;
    public bool LevelIsDone()
    {
        return levelIsDone;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCounter++;

            other.gameObject.SetActive(false);

            if (playerCounter == 3)
            {
                gameObject.SetActive(false);
                levelIsDone = true;
                if (levelIsDone == true)
                {
                    finishedLevel?.Invoke();
                    scoreSystem.AddPoints(pointsValue);
                }
            }
        }
    }

    public void FinishedLevel(UnityAction callback)
    {
        finishedLevel += callback;
    }

}
