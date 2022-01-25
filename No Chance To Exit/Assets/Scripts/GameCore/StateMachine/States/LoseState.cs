using UnityEngine;
using GameUI;

namespace GameCore
{
    public class LoseState : BaseState
    {
        private LoseView loseView;
        private LoadingSystem loadingSystem;
        private LoadingView loadingView;
        private SaveSystem saveSystem;

        public LoseState(LoseView loseView, LoadingSystem loadingSystem, LoadingView loadingView, SaveSystem saveSystem)
        {
            this.loseView = loseView;
            this.loadingSystem = loadingSystem;
            this.loadingView = loadingView;
            this.saveSystem = saveSystem;
        }


        public override void InitializeState()
        {
            base.InitializeState();
            loseView.ShowView();
            loseView.OnResetButtonClicked_AddListener(ResetLevel);
            loseView.OnExitButtonClicked_AddListener(ReturnToMainMenu);
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void DestroyState()
        {
            base.DestroyState();
        }

        private void ResetLevel()
        {
            var levelIndex = saveSystem.GetSave().levelIndex;
            loadingView.ShowView();
            loadingSystem.StartLoadingScene(levelIndex);
        }
        private void ReturnToMainMenu()
        {
            loadingView.ShowView();
            loadingSystem.StartLoadingScene(0);
        }

    }
}

