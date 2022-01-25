using GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameCore
{
    public class MenuController : BaseController
    {
        #region STATES

        private MenuState menuState;

        #endregion

        #region SYSTEMS

        [SerializeField] private MenuView menuView;
        [SerializeField] private ExitPopup exitPopup;
        [SerializeField] private LoadingView loadingView;
        [SerializeField] private LoadingSystem loadingSystem;
        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private OptionsView optionsView;
        [SerializeField] private InDevelopment inDevelopment;

        #endregion

        protected override void InjectReferences()
        {
            menuState = new MenuState(menuView, exitPopup, loadingView, loadingSystem, saveSystem, optionsView, inDevelopment);
        }

        protected override void Start()
        {
            base.Start();
            saveSystem.LoadData();
            if (saveSystem.GetSave().wasPlayed)
            {
                menuView.continueGameButton.interactable = true;
            }
            ChangeState(menuState);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}



