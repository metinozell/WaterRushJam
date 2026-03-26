using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject completePanel;
    public GameObject failPanel;
    public GameObject[] starIcons;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowCompletePanel(int starCount)
    {
        completePanel.SetActive(true);
        for (int i = 0; i <= 2; i++)
        {
            starIcons[i].SetActive(false);
        }

        for (int i = 0; i <= starCount; i++)
        {
            if (starCount == 2)
            {
                starIcons[i].SetActive(true);
            }
        }
    }

    public void ShowFailPanel()
    {
        failPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        GameManager.instance.ChangeState(GameManager.GameState.Playing);
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        Time.timeScale = 1f;
        GameManager.instance.ChangeState(GameManager.GameState.Playing);

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("CurrentLevel", nextSceneIndex);
            PlayerPrefs.Save();
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Oyun bitti, ana menüye dönülüyor...");
            SceneManager.LoadScene(0);
        }
    }
}
