using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder
{
    private LevelsList _levels;
    private int _levelNumber;

    public LevelBuilder(LevelsList levels, int levelNumber)
    {
        _levels = levels;
        _levelNumber = levelNumber;
        if (_levelNumber >= _levels.Count) _levelNumber = 0;
    }

    public void BuildLevel()
    {
        GameObject.Instantiate(_levels.GetLevel(_levelNumber));
    }
}