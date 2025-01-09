using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Text highscoreEasyText;
    public int highscoreEasy;
    public int highscoreMedium;
    public Text highscoreMediumText;
    public int highscoreHard;
    public Text highscoreHardText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // zeigt Highscore an
        highscoreEasy = PlayerPrefs.GetInt("HighscoreEasy", 0);
        highscoreEasyText.text = highscoreEasy.ToString();
        highscoreMedium = PlayerPrefs.GetInt("HighscoreMedium", 0);
        highscoreMediumText.text = highscoreMedium.ToString();
        highscoreHard = PlayerPrefs.GetInt("HighscoreHard", 0);
        highscoreHardText.text = highscoreHard.ToString();
        SetHighscore();
    }
    // vergleicht, ob neuer Punktestand höher ist als letzter Highscore und ersetzt ihn, wenn true
    public void SetHighscore()
    {
        int easyScore = PlayerPrefs.GetInt("ScoreEasy", 0);
        if (easyScore > highscoreEasy)
        {
            highscoreEasy = easyScore;
            PlayerPrefs.SetInt("HighscoreEasy", highscoreEasy);
            highscoreEasyText.text = highscoreEasy.ToString();
        }
        
        int mediumScore = PlayerPrefs.GetInt("ScoreMedium", 0);
        if (mediumScore > highscoreMedium)
        {
            highscoreMedium = mediumScore;
            PlayerPrefs.SetInt("HighscoreMedium", highscoreMedium);
            highscoreMediumText.text = highscoreMedium.ToString();
        }
        
        int hardScore = PlayerPrefs.GetInt("ScoreHard", 0);
        if (hardScore > highscoreHard)
        {
            highscoreHard = hardScore;
            PlayerPrefs.SetInt("HighscoreHard", highscoreHard);
            highscoreHardText.text = highscoreHard.ToString();
        }
    }
    // lädt Level Easy
    public void LoadMyScene(string sampleScene)
    {
        SceneManager.LoadScene(sampleScene);
    }
    // lädt Level Medium
    public void StartMediumGame(string levelMedium)
    {
        SceneManager.LoadScene(levelMedium);
    }
    // lädt Level Hard
    public void StartHardGame(string levelHard)
    {
        SceneManager.LoadScene(levelHard);
    }
    // Click Sound
    public void ClickButton()
    {
        AudioManager.Instance.PlayClickSound();
    }
    // Spiel beenden
    public void QuitGame()
    {
        Application.Quit();
    }
}