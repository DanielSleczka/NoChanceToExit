using UnityEngine;
using UnityEngine.Events;

namespace GameUI
{
    public class MenuView : BaseView
    {
        [SerializeField] public CustomButton continueGameButton;
        [SerializeField] private CustomButton newGameButton;
        [SerializeField] private CustomButton optionsMenuButton;
        [SerializeField] private CustomButton creditsMenuButton;
        [SerializeField] private CustomButton exitGameButton;



        public void InitializeView()
        {
            continueGameButton.onMouseEnter.AddListener(() => ScaleUp(continueGameButton));
            newGameButton.onMouseEnter.AddListener(() => ScaleUp(newGameButton));
            optionsMenuButton.onMouseEnter.AddListener(() => ScaleUp(optionsMenuButton));
            creditsMenuButton.onMouseEnter.AddListener(() => ScaleUp(creditsMenuButton));
            exitGameButton.onMouseEnter.AddListener(() => ScaleUp(exitGameButton));

            continueGameButton.onMouseExit.AddListener(() => ScaleDown(continueGameButton));
            newGameButton.onMouseExit.AddListener(() => ScaleDown(newGameButton));
            optionsMenuButton.onMouseExit.AddListener(() => ScaleDown(optionsMenuButton));
            creditsMenuButton.onMouseExit.AddListener(() => ScaleDown(creditsMenuButton));
            exitGameButton.onMouseExit.AddListener(() => ScaleDown(exitGameButton));

            continueGameButton.onClick.AddListener(continueGameButton.RemoveAllListeners);
        }


        public void OnContinueGameButtonClicked_AddListener(UnityAction listener)
        {
            continueGameButton.onClick.AddListener(listener);
        }

        public void OnContinueGameButtonClicked_RemoveListener(UnityAction listener)
        {
            continueGameButton.onClick.RemoveListener(listener);
        }

        public void OnNewGameButtonClicked_AddListener(UnityAction listener)
        {
            newGameButton.onClick.AddListener(listener);
        }

        public void OnNewGameButtonClicked_RemoveListener(UnityAction listener)
        {
            newGameButton.onClick.RemoveListener(listener);
        }
        public void OnOptionsMenuButtonClicked_AddListener(UnityAction listener)
        {
            optionsMenuButton.onClick.AddListener(listener);
        }

        public void OnOptionsMenuButtonClicked_RemoveListener(UnityAction listener)
        {
            optionsMenuButton.onClick.RemoveListener(listener);
        }

        public void OnCreditsMenuButtonClicked_AddListener(UnityAction listener)
        {
            creditsMenuButton.onClick.AddListener(listener);
        }

        public void OnCreditsMenuButtonClicked_RemoveListener(UnityAction listener)
        {
            creditsMenuButton.onClick.RemoveListener(listener);
        }

        public void OnExitButtonClicked_AddListener(UnityAction listener)
        {
            exitGameButton.onClick.AddListener(listener);
        }

        public void OnExitButtonClicked_RemoveListener(UnityAction listener)
        {
            exitGameButton.onClick.RemoveListener(listener);
        }

    }
}

