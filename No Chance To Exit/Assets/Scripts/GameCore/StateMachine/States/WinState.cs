using GameUI;
using System.Collections;
using UnityEngine;

namespace GameCore
{
    public class WinState : BaseState
    {
        private WinView winView;
        private LoadingSystem loadingSystem;
        private LoadingView loadingView;
        private SaveSystem saveSystem;
        private ScoreSystem scoreSystem;
        private FinalView finalView;

        public WinState(WinView winView, LoadingSystem loadingSystem, LoadingView loadingView, SaveSystem saveSystem, ScoreSystem scoreSystem, FinalView finalView)
        {
            this.winView = winView;
            this.loadingSystem = loadingSystem;
            this.loadingView = loadingView;
            this.saveSystem = saveSystem;
            this.scoreSystem = scoreSystem;
            this.finalView = finalView;
        }

        public override void InitializeState()
        {
            base.InitializeState();
            winView.ShowView();
            winView.OnNextLevelButtonClicked_AddListener(NextLevel);
            winView.OnExitButtonClicked_AddListener(ReturnToMainMenu);
            scoreSystem.CountPoints();
            finalView?.InitializeView();
            finalView?.OnReturnButtonClicked_AddListener(ReturnToMainMenu);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            scoreSystem.GetCurrentPoints();
        }

        public override void DestroyState()
        {
            base.DestroyState();
        }


        private void NextLevel()
        {
            

            if (loadingSystem.SceneCounting() == saveSystem.GetSave().levelIndex)
            {   
                // FINAL VIEW ACTIVATOR
                finalView.ShowView();
            }
            else if (loadingSystem.SceneCounting() != saveSystem.GetSave().levelIndex)
            {
                // INCREASE LEVEL INDEX 
                saveSystem.IncreaseLevelIndex();
                var levelIndex = saveSystem.GetSave().levelIndex;
                loadingView.ShowView();
                loadingSystem.StartLoadingScene(levelIndex);
                saveSystem.GetSave().levelIndex = levelIndex;

                // GET CURRENT POINTS
                var points = scoreSystem.GetCurrentPoints();
                saveSystem.GetSave().points = points;

                // SAVE ALL DATA
                saveSystem.SaveData();
            }
        }
        private void ReturnToMainMenu()
        {
            loadingView.ShowView();
            loadingSystem.StartLoadingScene(0);
        }
    }
}
