using GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class GameController : BaseController
    {
        #region STATES
        private GameState gameState;
        private WinState winState;
        private LoseState loseState;
        #endregion

        #region SYSTEMS

        [SerializeField] private GameView gameView;
        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private InputSystem inputSystem;
        [SerializeField] private TimeSystem timeSystem;
        [SerializeField] private PlayerSwitcher playerSwitcher;
        [SerializeField] private PauseView pauseView;
        [SerializeField] private LoseView loseView;
        [SerializeField] private LoadingSystem loadingSystem;
        [SerializeField] private LoadingView loadingView;
        [SerializeField] private WinView winView;
        [SerializeField] private ExitBlock exitBlock;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private InstructionView instructionView;
        [SerializeField] private FinalView finalView;

        #endregion

        protected override void InjectReferences()
        {
            gameState = new GameState(gameView, saveSystem, inputSystem, timeSystem, playerSwitcher, pauseView, loadingSystem, 
                loadingView, exitBlock, scoreSystem, instructionView);
            winState = new WinState(winView, loadingSystem, loadingView, saveSystem, scoreSystem, finalView);
            loseState = new LoseState(loseView, loadingSystem, loadingView, saveSystem);
        }

        protected override void Start()
        {
            base.Start();
            saveSystem.LoadData();
            Time.timeScale = 1;
            ChangeState(gameState);
            timeSystem.OnCountEnded_AddListener(() => ChangeState(loseState));
            exitBlock.FinishedLevel(() => ChangeState(winState));
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
