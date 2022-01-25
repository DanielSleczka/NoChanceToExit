using GameUI;


namespace GameCore
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private SaveSystem saveSystem;
        private InputSystem inputSystem;
        private TimeSystem timeSystem;
        private PlayerSwitcher playerSwitcher;
        private PauseView pauseView;
        private LoadingSystem loadingSystem;
        private LoadingView loadingView;
        private ExitBlock exitBlock;
        private ScoreSystem scoreSystem;
        private InstructionView instructionView;


        public GameState(GameView gameView, SaveSystem saveSystem, InputSystem inputSystem,
            TimeSystem timeSystem, PlayerSwitcher playerSwitcher, PauseView pauseView, LoadingSystem loadingSystem, 
            LoadingView loadingView, ExitBlock exitBlock, ScoreSystem scoreSystem, InstructionView instructionView)
        {
            this.gameView = gameView;
            this.saveSystem = saveSystem;
            this.inputSystem = inputSystem;
            this.timeSystem = timeSystem;
            this.playerSwitcher = playerSwitcher;
            this.pauseView = pauseView;
            this.loadingSystem = loadingSystem;
            this.loadingView = loadingView;
            this.exitBlock = exitBlock;
            this.scoreSystem = scoreSystem;
            this.instructionView = instructionView;
        }

        public override void InitializeState()
        {
            base.InitializeState();
            inputSystem.EnableInput();
            playerSwitcher.InitializePlayer();
            timeSystem.Initialize();
            pauseView.InitializeView();
            instructionView?.InitializeView();

            var points = saveSystem.GetSave().points;
            gameView.UpdatePoints(points);

            gameView.ShowView();

            pauseView.OnContinueButtonClicked_AddListener(pauseView.HideView);
            pauseView.OnResetButtonClicked_AddListener(ResetLevel);
            pauseView.OnExitButtonClicked_AddListener(ReturnToMainMenu);


        }

        public override void UpdateState()
        {
            base.UpdateState();
            inputSystem.UpdateInput();
            timeSystem.UpdateCounting();
            gameView.UpdateTime(timeSystem.GetCurrentTimeInSecondsReversed());
            gameView.UpdatePoints(scoreSystem.GetCurrentPoints());

            playerSwitcher.UpdatePlayer(inputSystem);

            if (timeSystem.IsCountEnded())
                exitBlock.LevelIsDone();
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
