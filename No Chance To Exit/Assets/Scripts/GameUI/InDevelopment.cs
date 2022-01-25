using System.Collections;
using TMPro;
using UnityEngine;

namespace GameUI
{
    public class InDevelopment : BaseView
    {
        [SerializeField] private TextMeshProUGUI developmentText;
        [SerializeField] private Animator loadingAnimator;
        [SerializeField] private CustomButton backButton;



        public override void ShowView()
        {
            base.ShowView();
            StartCoroutine(AnimateText());
            loadingAnimator.SetTrigger("LoadingAnim");
        }

        public void InitializeInDevelopmentScreen()
        {
            backButton.onClick.AddListener(HideView);
            backButton.onMouseEnter.AddListener(() => ScaleUp(backButton));
            backButton.onMouseExit.AddListener(() => ScaleDown(backButton));
        }

        private IEnumerator AnimateText()
        {
            while (true)
            {
                developmentText.text = "In Development";
                yield return new WaitForSeconds(.5f);
                developmentText.text = "In Development.";
                yield return new WaitForSeconds(.5f);
                developmentText.text = "In Development..";
                yield return new WaitForSeconds(.5f);
                developmentText.text = "In Development...";
                yield return new WaitForSeconds(.5f);
            }
        }
    } 
}
