using GameUI;
using UnityEngine;


namespace GameCore
{
    public class MenuState : BaseState
    {
        private MenuView menuView;
        private ExitPopup exitPopup;
        private LoadingView loadingView;
        private LoadingSystem loadingSystem;
        private SaveSystem saveSystem;
        private OptionsView optionsView;
        private InDevelopment inDevelopment;

        private int firstLevel = 1;
        private int startPoints = 0;

        public MenuState(MenuView menuView, ExitPopup exitPopup, LoadingView loadingView, LoadingSystem loadingSystem, SaveSystem saveSystem,
            OptionsView optionsView, InDevelopment inDevelopment)
        {
            this.menuView = menuView;
            this.exitPopup = exitPopup;
            this.loadingView = loadingView;
            this.loadingSystem = loadingSystem;
            this.saveSystem = saveSystem;
            this.optionsView = optionsView;
            this.inDevelopment = inDevelopment;
        }

        public override void InitializeState()
        {
            base.InitializeState();
            menuView.InitializeView();
            exitPopup.InitializePopup();
            optionsView.InitializeView();
            inDevelopment.InitializeInDevelopmentScreen();

            menuView.ShowView();

            menuView.OnContinueGameButtonClicked_AddListener(ContinueGame);
            menuView.OnNewGameButtonClicked_AddListener(CreateNewGame);
            menuView.OnOptionsMenuButtonClicked_AddListener(optionsView.ShowView);
            menuView.OnCreditsMenuButtonClicked_AddListener(inDevelopment.ShowView); // TODO: credits
            menuView.OnExitButtonClicked_AddListener(Application.Quit); // (exitPopup.ShowView) - something don't work

            Debug.Log($"Scene count: {loadingSystem.SceneCounting()}");
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void DestroyState()
        {
            base.DestroyState();
        }

        private void ContinueGame()
        {
            var levelIndex = saveSystem.GetSave().levelIndex;
            loadingView.ShowView();
            loadingSystem.StartLoadingScene(levelIndex);
            GameObject.FindGameObjectWithTag("GameMusic")?.GetComponent<AudioSource>().Play();
            Debug.Log(GameObject.FindGameObjectWithTag("GameMusic"));
        }

        private void CreateNewGame()
        { 
            saveSystem.GetSave().levelIndex = firstLevel;
            saveSystem.GetSave().points = startPoints;
            saveSystem.GetSave().wasPlayed = true;
            saveSystem.SaveData();
            loadingView.ShowView();
            loadingSystem.StartLoadingScene(firstLevel);
            GameObject.FindGameObjectWithTag("GameMusic")?.GetComponent<AudioSource>().Play();

        }

    }
}

