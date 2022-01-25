using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace GameUI
{
    public class InstructionView : BaseView
    {

        [SerializeField] private CustomButton skipButton;
        [SerializeField] private CustomButton returnButton;

        [SerializeField] private InstructionView[] gameInstructions;

        public void InitializeView()
        {
            skipButton?.onClick.AddListener(SkipButton);
            returnButton.onClick.AddListener(ReturnButton);

            skipButton?.onMouseEnter.AddListener(() => ScaleUp(skipButton));
            returnButton.onMouseEnter.AddListener(() => ScaleUp(returnButton));

            skipButton?.onMouseExit.AddListener(() => ScaleDown(skipButton));
            returnButton.onMouseExit.AddListener(() => ScaleDown(returnButton));
        }

        public override void ShowView()
        {
            transform.localScale = new Vector3(0f, 0f, 1f);
            base.ShowView();
            transform.DOScale(1f, .2f).SetUpdate(true);
        }

        public override void HideView()
        {
            transform.DOScale(new Vector3(0f, 0f, 1f), .2f).OnComplete(base.HideView).SetUpdate(true);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public void SkipButton()
        {
            gameInstructions[0].HideView();
            gameInstructions[1].ShowView();
        }

        public void ReturnButton()
        {
            gameInstructions[0].HideView();
            if (gameInstructions.Length > 1)
                gameInstructions[1].HideView();
            Time.timeScale = 1;
        }
    }
}


