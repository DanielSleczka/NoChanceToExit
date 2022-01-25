using TMPro;
using UnityEngine;

namespace GameUI
{
    public class GameView : BaseView
    {
        [SerializeField] private TextMeshProUGUI pointsValue;
        [SerializeField] private TextMeshProUGUI timeValue;

        public void UpdatePoints(float points)
        {
            pointsValue.text = $"{points}";
        }

        public void UpdateTime(float seconds)
        {
            int tempSeconds = (int)seconds;
            int minutes = tempSeconds / 60;
            tempSeconds = tempSeconds % 60;

            timeValue.text = $"{minutes:00}:{tempSeconds:00}";
        }

    } 
}
