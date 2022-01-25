using GameUI;
using System.Collections;
using UnityEngine;

namespace GameCore
{

    public class ScoreSystem : MonoBehaviour
    {
        private int currentPoints;

        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private WinView winView;


        public void AddPoints(int value)
        {
            saveSystem.GetSave().points += value;
        }

        public int GetCurrentPoints()
        {
            currentPoints = saveSystem.GetSave().points;
            return currentPoints;

        }

        public void CountPoints()
        {
            StartCoroutine(CountPointsWithDelay(0.001f));
        }

        private IEnumerator CountPointsWithDelay(float delay)
        {
            for (int i = 0; i <= saveSystem.GetSave().points; i++)
            {
                yield return new WaitForSeconds(delay);
                winView.UpdateWinScore(i);
            }

        }
    }

}