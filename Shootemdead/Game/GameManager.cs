using Game;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum GameState
    {
        MainMenu,
        Credits,
        GameOverScreen,
        WinScreen,
        Level
    }

    public class GameManager
    {


        public SingleScreen GameOverScreen = new SingleScreen("Textures/Screens/GameOver.png");
        public SingleScreen WinScreen = new SingleScreen("Textures/Screens/Win.png");
        public SingleScreen Credits = new SingleScreen("Textures/Screens/Credits.png");
        public SingleScreen MainMenuScreen = new SingleScreen("Textures/Screens/MainMenu.png");
        public SingleScreen Level = new SingleScreen("Textures/Screens/Level.png");

        private static GameManager instance;

        public LevelController LevelController { get; private set; }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

        public GameState CurrentState { get; private set; }

        public void Update()
        {
            switch (CurrentState)
            {

                case GameState.MainMenu:
                    MainMenuScreen.Update();
                    break;
                case GameState.Credits:
                    Credits.Update();
                    break;
                case GameState.GameOverScreen:
                    GameOverScreen.Update();
                    break;
                case GameState.WinScreen:
                    WinScreen.Update();
                    break;
                case GameState.Level:
                    LevelController.Update();
                    break;
                default:
                    break;
            }

        }

        public void Initilization()
        {
           
            ChangeGameState(GameState.MainMenu);
            LevelController = new LevelController();
            LevelController.Initialization();
        }

        public void Render()
{
            Engine.Clear();
            switch (CurrentState)
            {

                case GameState.MainMenu:
                    MainMenuScreen.Render();
                    break;
                case GameState.Credits:
                    Credits.Render();
                    break;
                case GameState.GameOverScreen:
                    GameOverScreen.Render();
                    break;
                case GameState.WinScreen:
                    WinScreen.Render();
                    break;
                case GameState.Level:
                    LevelController.Render();
                    break;
                default:
                    break;
            }
            Engine.Show();
}

    public void ChangeGameState(GameState newState)
    {
        CurrentState = newState;
    }

    }
}