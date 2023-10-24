using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "GameState", menuName = "ScriptableObjects")]
public class GameState : ScriptableObject
{
    public enum GameStateEnum
    {
        Playing,
        GameOver
    }
    public GameStateEnum CurrentGameState;

    private int _enemyCount;
    public int EnemyCount
    {
        get => _enemyCount;
        set => _enemyCount = value;
    }
}
