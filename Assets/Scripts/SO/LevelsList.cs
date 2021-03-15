using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level list", menuName = "Scriptable objects/Level list", order = 1)]
public class LevelsList : ScriptableObject
{
    [SerializeField] private List<LevelPreset> _levels;


    public int Count
    {
        get => _levels.Count;
    }

    public LevelPreset GetLevel(int levelNumber)
    {
        if (levelNumber > _levels.Count)
        {
            return _levels[0];
        }
        else
        {
            return _levels[levelNumber];
        }
    }
}
