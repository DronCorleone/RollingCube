using UnityEngine;

public class EndGameMenu : BaseMenu
{
    [Header("Panel")]
    [SerializeField] private GameObject _panel;

    [Header("Buttons")]
    [SerializeField] private ButtonUI _restartButton;
    [SerializeField] private ButtonUI _nextLevelButton;
    [SerializeField] private ButtonUI _exitButton;

    private UIController _uiController;


    private void Start()
    {
        _uiController = transform.parent.GetComponent<UIController>();

        _restartButton.GetControl.onClick.AddListener(() => _uiController.RestartLevel());
        _nextLevelButton.GetControl.onClick.AddListener(() => _uiController.NextLevel());
        _exitButton.GetControl.onClick.AddListener(() => _uiController.ExitGame());
    }

    public override void Hide()
    {
        if (!IsShow) return;
        _panel.gameObject.SetActive(false);
        IsShow = false;
    }

    public override void Show()
    {
        if (IsShow) return;
        _panel.gameObject.SetActive(true);
        IsShow = true;
    }

    public void ActivateState(EndGameUIState state)
    {
        switch (state)
        {
            case EndGameUIState.Win:
                _nextLevelButton.gameObject.SetActive(true);
                break;
            case EndGameUIState.Lose:
                _nextLevelButton.gameObject.SetActive(false);
                break;
        }
    }
}