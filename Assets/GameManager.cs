using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("State")]
    public bool GameStarted = false;
    public bool IsPaused = false;

    [Header("UI")]
    public GameObject mainMenuPanel;
    public GameObject pauseMenuPanel;
    public GameObject gameOverPanel;
    public GameObject pauseButton;

    StickController playerStick;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 0f;

        mainMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseButton.SetActive(false);

        playerStick = FindFirstObjectByType<StickController>();
    }


    public void StartGame()
    {
        GameStarted = true;
        IsPaused = false;

        Time.timeScale = 1f;

        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseButton.SetActive(true);

        if (playerStick != null)
            playerStick.Unstick();
    }


    public void PauseGame()
    {
        if (!GameStarted || IsPaused) return;

        IsPaused = true;
        Time.timeScale = 0f;

        pauseMenuPanel.SetActive(true);
    }


    public void ResumeGame()
    {
        if (!IsPaused) return;

        IsPaused = false;
        Time.timeScale = 1f;

        pauseMenuPanel.SetActive(false);

        if (playerStick != null)
            playerStick.Unstick();
    }


    public void GameOver()
    {
        Time.timeScale = 0f;
        IsPaused = true;

        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }


    public void RetryGame()
    {
        Time.timeScale = 1f;

        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ResetScore();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 0f;

        GameStarted = false;
        IsPaused = false;

        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        pauseButton.SetActive(false);
    }
}
