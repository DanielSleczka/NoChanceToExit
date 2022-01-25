using DG.Tweening;
using UnityEngine;

namespace GameUI
{
    public class ExitPopup : BaseView
    {
        [SerializeField]
        private CustomButton yesButton;

        [SerializeField]
        private CustomButton noButton;


        public void InitializePopup()
        {
            yesButton.onClick.AddListener(Application.Quit);
            noButton.onClick.AddListener(HideView);

            yesButton.onMouseEnter.AddListener(() => ScaleUp(yesButton));
            noButton.onMouseEnter.AddListener(() => ScaleUp(noButton));

            yesButton.onMouseExit.AddListener(() => ScaleDown(yesButton));
            noButton.onMouseExit.AddListener(() => ScaleDown(noButton));
        }

        public override void ShowView()
        {
            base.ShowView();
            transform.localScale = new Vector3(0f, 0f, 1f);
            transform.DOScale(1f, .2f);
        }

        public override void HideView()
        {
            transform.DOScale(new Vector3(0f, 0f, 1f), .2f).OnComplete(base.HideView);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}


