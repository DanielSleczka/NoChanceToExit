using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace GameUI
{
    public class CustomButton : Button
    {
        public UnityEvent onMouseEnter;
        public UnityEvent onMouseExit;


        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            onMouseEnter?.Invoke();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            onMouseExit?.Invoke();
        }

        public void RemoveAllListeners()
        {
            onMouseEnter.RemoveAllListeners();
            onMouseExit.RemoveAllListeners();
        }
    }
}

