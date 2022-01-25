using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GameUI
{
    public class WinView : BaseView
    {
        [SerializeField] private CustomButton nextLevelButton;
        [SerializeField] private CustomButton exitButton;
        [SerializeField] private TextMeshProUGUI scoreValue;
        [SerializeField] private AudioSource winAudio;

        public void InitializeView()
        {
            nextLevelButton.onMouseEnter.AddListener(() => ScaleUp(nextLevelButton));
            exitButton.onMouseEnter.AddListener(() => ScaleUp(exitButton));

            nextLevelButton.onMouseExit.AddListener(() => ScaleDown(nextLevelButton));
            exitButton.onMouseExit.AddListener(() => ScaleDown(exitButton));
        }

        public void UpdateWinScore(int score)
        {
            scoreValue.text = $"{score}";
        }

        public override void ShowView()
        {
            base.ShowView();
            transform.localScale = new Vector3(0f, 0f, 1f);
            transform.DOScale(1f, .2f).SetUpdate(true);
            winAudio.Play();
        }

        public override void HideView()
        {
            transform.DOScale(new Vector3(0f, 0f, 1f), .2f).OnComplete(base.HideView).SetUpdate(true);
            transform.localScale = new Vector3(1f, 1f, 1f);
            Time.timeScale = 1;
        }


        public void OnNextLevelButtonClicked_AddListener(UnityAction listener)
        {
            nextLevelButton.onClick.AddListener(listener);
        }

        public void OnNextLevelButtonClicked_RemoveListener(UnityAction listener)
        {
            nextLevelButton.onClick.RemoveListener(listener);
        }

        public void OnExitButtonClicked_AddListener(UnityAction listener)
        {
            exitButton.onClick.AddListener(listener);
        }

        public void OnExitButtonClicked_RemoveListener(UnityAction listener)
        {
            exitButton.onClick.RemoveListener(listener);
        }

    }
}