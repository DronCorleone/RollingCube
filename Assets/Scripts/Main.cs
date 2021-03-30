using UnityEngine;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour
{
    [SerializeField] private LevelsList _levels;

    private SaveDataRepo _saveData;
    private LevelBuilder _levelBuilder;
    private int _levelNumber;

    private PlayerMoveController _player;
    private UIController _uiController;


    private void Awake()
    {
        _saveData = new SaveDataRepo();
        _levelNumber = _saveData.LoadInt(SaveKeyManager.LevelNumber);

        _levelBuilder = new LevelBuilder(_levels, _levelNumber);
        _levelBuilder.BuildLevel();

        _uiController = FindObjectOfType<UIController>();
        _player = FindObjectOfType<PlayerMoveController>();
    }

    private void Update()
    {
        PlayerTracking();
    }

    private void PlayerTracking()
    {
        switch(_player.State)
        {
            case PlayerState.Win:
                Invoke("Win", 1f);
                break;
            case PlayerState.Lose:
                EndLevel(false);
                break;
            case PlayerState.Death:
                _player.gameObject.SetActive(false);
                Invoke("PlayerDeath", 1f);
                break;
            default:
                break;
        }
    }

    private void SaveGame()
    {
        _saveData.SaveData(_levelNumber, SaveKeyManager.LevelNumber);
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        _levelNumber++;
        if (_levelNumber >= _levels.Count) _levelNumber = 0;
        SaveGame();
        RestartLevel();
    }

    public void EndLevel(bool isWin)
    {
        if (isWin == true)
        {
            _uiController.EndLevel(EndGameUIState.Win);
        }
        else
        {
            _uiController.EndLevel(EndGameUIState.Lose);
        }
    }

    private void Win()
    {
        EndLevel(true);
    }

    private void PlayerDeath()
    {
        EndLevel(false);
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}