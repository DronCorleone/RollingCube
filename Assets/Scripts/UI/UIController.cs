using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private MainMenu _mainMenu;
    private InGameUI _inGameUI;
    private PauseMenu _pauseMenu;
    private EndGameMenu _endGameMenu;

    private Main _main;

    private void Start()
    {
        _main = FindObjectOfType<Main>();

        _mainMenu = GetComponentInChildren<MainMenu>();
        _inGameUI = GetComponentInChildren<InGameUI>();
        _pauseMenu = GetComponentInChildren<PauseMenu>();
        _endGameMenu = GetComponentInChildren<EndGameMenu>();

        SwitchUI(UIState.MainMenu);
        _main.PauseGame();
    }

    private void SwitchUI(UIState state)
    {
        switch (state)
        {
            case UIState.MainMenu:
                _mainMenu.Show();
                _inGameUI.Hide();
                _pauseMenu.Hide();
                _endGameMenu.Hide();
                break;
            case UIState.InGame:
                _mainMenu.Hide();
                _inGameUI.Show();
                _pauseMenu.Hide();
                _endGameMenu.Hide();
                break;
            case UIState.Pause:
                _mainMenu.Hide();
                _inGameUI.Hide();
                _pauseMenu.Show();
                _endGameMenu.Hide();
                break;
            case UIState.EndGame:
                _mainMenu.Hide();
                _inGameUI.Hide();
                _pauseMenu.Hide();
                _endGameMenu.Show();
                break;
        }
    }

    public void PauseGame()
    {
        _main.PauseGame();
        SwitchUI(UIState.Pause);
    }

    public void ResumeGame()
    {
        _main.ResumeGame();
        SwitchUI(UIState.InGame);
    }

    public void RestartLevel()
    {
        _main.RestartLevel();
    }

    public void NextLevel()
    {
        _main.NextLevel();
    }

    public void EndLevel(EndGameUIState state)
    {
        SwitchUI(UIState.EndGame);
        _endGameMenu.ActivateState(state);
    }

    public void ExitGame()
    {
        _main.ExitGame();
    }
}