using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class BaseView : MonoBehaviour
    {
        public virtual void ShowView()
        {
            gameObject.SetActive(true);
        }

        public virtual void HideView()
        {
            if (this != null)
                gameObject.SetActive(false);
        }

        //public void ScaleButtonUpAndDown(Button button)
        //{
        //    var scaleSequence = DOTween.Sequence();
        //    scaleSequence
        //        .Append(button.transform.DOScale(1.1f, .2f))
        //        .Append(button.transform.DOScale(1f, .2f));
        //}

        public void ScaleUp(Button button)
        {
            button.transform.DOScale(1.1f, .2f);
        }

        public void ScaleDown(Button button)
        {
            button.transform.DOScale(1f, .2f);
        }

    }
}


