using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentState;
    public int earnedStar = 0;
    public enum GameState
    {
        Playing,
        GameOver,
        LevelComplete
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ChangeState(GameState.Playing);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case GameState.Playing:
                Time.timeScale = 1f;
                break;
            case GameState.GameOver:
                Time.timeScale = 0f;
                break;
            case GameState.LevelComplete:
                Time.timeScale = 1f;
                break;
        }
    }

    public int CalculateStars(float maxWater, float remainingWater)
    {
        float percentage = (remainingWater / maxWater) * 100;
        if (percentage >= 80) earnedStar = 3;
        else if (percentage >= 50) earnedStar = 2;
        else if (percentage > 0) earnedStar = 1;
        else earnedStar = 0;
        Debug.Log("Oyun bitti" + earnedStar + "% " + percentage);

        int totalStars = PlayerPrefs.GetInt("TotalStars", 0);
        totalStars = totalStars + earnedStar;
        PlayerPrefs.SetInt("TotalStars", totalStars);
        PlayerPrefs.Save();
        Debug.Log("Total Stars: " + totalStars);
        return earnedStar;
    }
}
