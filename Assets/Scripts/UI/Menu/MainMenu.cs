using UnityEngine;

public class MainMenu : BaseMenu
{
    [Header("Panel")]
    [SerializeField] private GameObject _panel;

    [Header("Buttons")]
    [SerializeField] private ButtonUI _startGameButton;

    private UIController _uiController;


    private void Start()
    {
        _uiController = transform.parent.GetComponent<UIController>();

        _startGameButton.GetControl.onClick.AddListener(() => _uiController.ResumeGame());
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
}