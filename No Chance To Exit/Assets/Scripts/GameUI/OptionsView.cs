using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameUI
{
    public class OptionsView : BaseView
    {
        [SerializeField] private CustomButton backButton;
        [SerializeField] private CustomButton saveSettingsButton;

        //[SerializeField] private Slider musicSlider;
        //[SerializeField] private Slider effectsSlider;

        //[SerializeField] private AudioMixer musicMixer;
        //[SerializeField] private AudioMixer effectsMixer;


        public void InitializeView()
        {
            backButton.onClick.AddListener(HideView);

            backButton.onMouseEnter.AddListener(() => ScaleUp(backButton));
            saveSettingsButton.onMouseEnter.AddListener(() => ScaleUp(saveSettingsButton));

            backButton.onMouseExit.AddListener(() => ScaleDown(backButton));
            saveSettingsButton.onMouseExit.AddListener(() => ScaleDown(saveSettingsButton));
        }


        public void OnSaveSettingsButtonClicked_AddListener(UnityAction listener)
        {
            saveSettingsButton.onClick.AddListener(listener);
        }
        public void OnSaveSettingsButtonClicked_RemoveListener(UnityAction listener)
        {
            saveSettingsButton.onClick.RemoveListener(listener);
        }
    }
}
