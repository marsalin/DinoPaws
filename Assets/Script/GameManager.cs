using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string currentLevel;
    public GameObject[] character;
    public GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameManagerInstance.Instance.level = currentLevel;
        LoadCharacter();
        pauseMenu.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ruft PauseGame() auf, wenn die Ecape Taste gedrückt wird
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManagerInstance.Instance.isPaused = !GameManagerInstance.Instance.isPaused;
            PauseGame();
        }
        // startet Spiel, wenn Leertaste gedrückt wird
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
        }
    }

    // spawnt den im Menü ausgewählten Charakter
    public void LoadCharacter()
    {
        int characterNumber = GameManagerInstance.Instance.charNum;
        Instantiate(character[characterNumber]);
    }

    // Spiel stoppen und kleines Menü öffnen, bzw schließen und fortetzen
    public void PauseGame()
    {
        if (GameManagerInstance.Instance.isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    // Spiel fortsetzen
    public void ContinueGame()
    {
        GameManagerInstance.Instance.isPaused = !GameManagerInstance.Instance.isPaused;
        PauseGame();
    }

    // zurück zum Menü
    public void BackToMainMenu(string menu)
    {
        SceneManager.LoadScene(menu);
    }
    // Spiel beenden
    public void QuitGame()
    {
        Application.Quit();
    }
    // Click Sound
    public void ClickButton()
    {
        AudioManager.Instance.PlayClickSound();
    }
}