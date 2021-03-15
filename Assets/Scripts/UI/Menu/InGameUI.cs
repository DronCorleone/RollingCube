using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : BaseMenu
{
    [Header("Panel")]
    [SerializeField] private GameObject _panel;

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
