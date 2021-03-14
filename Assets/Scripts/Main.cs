using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private LevelsList _levels;

    private SaveDataRepo _saveData;
    private LevelBuilder _levelBuilder;
    private int _levelNumber;


    private void Awake()
    {
        _saveData = new SaveDataRepo();
        _levelNumber = _saveData.LoadInt(SaveKeyManager.LevelNumber);

        _levelBuilder = new LevelBuilder(_levels, _levelNumber);
        _levelBuilder.BuildLevel();
    }
}