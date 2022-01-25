using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameUI
{
    public class FinalView : BaseView
    {
        [SerializeField] private CustomButton returnButton;

        public void InitializeView()
        {
            returnButton.onMouseEnter.AddListener(() => ScaleUp(returnButton));
            returnButton.onMouseExit.AddListener(() => ScaleDown(returnButton));
        }

        public void OnReturnButtonClicked_AddListener(UnityAction listener)
        {
            returnButton.onClick.AddListener(listener);
        }

        public void OnReturnButtonClicked_RemoveListener(UnityAction listener)
        {
            returnButton.onClick.RemoveListener(listener);
        }
    } 
}
