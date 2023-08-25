using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Prepare,
    Start,
    InGame,
    GameEnding
}

public class GameController : MonoBehaviour
{
    // Singleton instance
    public static GameController Instance;

    //Current game state
    [SerializeField] public GameState state;

    // In game timer
    public float playingTime;

    public delegate void Game();
    public static Game OnStart;
    public static Game InGame;
    public static Game GameEnding;
    private void Awake()
    {
        Instance = this;

        // Initial game state
        state = GameState.Start;
    }

    public void FixedUpdate()
    {
        // State Process
        switch (state)
        {
            case GameState.Start:
                OnStart?.Invoke();
                state = GameState.InGame;
                break;
            case GameState.InGame:
                InGame?.Invoke();
                break;
            case GameState.GameEnding:
                GameEnding?.Invoke();
                break;
        }
    }

    private void OnEnable()
    {
        OnStart += ResetTimer;
        InGame += CountingTime;
    }
    private void OnDisable()
    {
        OnStart -= ResetTimer;
        InGame -= CountingTime;
    }
    void ResetTimer()
    {
        playingTime = 0;
    }
    void CountingTime()
    {
        playingTime += Time.deltaTime;
    }


}
