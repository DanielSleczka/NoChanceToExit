using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace GameUI
{
    public class LoseView : BaseView
    {
        [SerializeField]
        private CustomButton resetButton;

        [SerializeField]
        private CustomButton exitButton;

        public void InitializeView()
        {
            resetButton.onMouseEnter.AddListener(() => ScaleUp(resetButton));
            exitButton.onMouseEnter.AddListener(() => ScaleUp(exitButton));

            resetButton.onMouseExit.AddListener(() => ScaleDown(resetButton));
            exitButton.onMouseExit.AddListener(() => ScaleDown(exitButton));
        }

        public override void ShowView()
        {
            transform.localScale = new Vector3(0f, 0f, 1f);
            base.ShowView();
            transform.DOScale(1f, .2f);
        }

        public override void HideView()
        {
            transform.DOScale(new Vector3(0f, 0f, 1f), .2f).OnComplete(base.HideView);
            transform.localScale = new Vector3(1f, 1f, 1f);
            Time.timeScale = 1;
        }

        public void OnResetButtonClicked_AddListener(UnityAction listener)
        {
            resetButton.onClick.AddListener(listener);
        }

        public void OnResetButtonClicked_RemoveListener(UnityAction listener)
        {
            resetButton.onClick.RemoveListener(listener);
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