using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class LoadingView : BaseView
    {

        [SerializeField]
        private TextMeshProUGUI loadingText;

        [SerializeField]
        private Animator loadingAnimator;

        public override void ShowView() 
        {
            base.ShowView();
            StartCoroutine(AnimateText());
            loadingAnimator.SetTrigger("LoadingAnim");
        }

        private IEnumerator AnimateText()
        {
            while (true)
            {
                loadingText.text = "LOADING";
                yield return new WaitForSeconds(.5f);
                loadingText.text = "LOADING.";
                yield return new WaitForSeconds(.5f);
                loadingText.text = "LOADING..";
                yield return new WaitForSeconds(.5f);
                loadingText.text = "LOADING...";
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}

