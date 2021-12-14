using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Controls;

    public GameObject WinMenu;
    public GameObject LoseMenu;

    public enum State
    {
        Play,
        Win,
        Lose,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDie()
    {
        if (CurrentState != State.Play) return;

        CurrentState = State.Lose;
        Controls.enabled = false;
        LoseMenu.SetActive(true);
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Play) return;

        CurrentState = State.Win;
        Controls.enabled = false;
        LevelIndex++;
        WinMenu.SetActive(true);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";
}
