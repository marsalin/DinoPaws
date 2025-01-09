using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DeathScreen : MonoBehaviour
{
    public Text finalscore;
    public Text level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetTextScore();
    }
    
    // gibt erreichte Punktzahl aus
    public void SetTextScore()
    {
        int easyscore = PlayerPrefs.GetInt("ScoreEasy", 0);
        int mediumScore = PlayerPrefs.GetInt("ScoreMedium", 0);
        int hardScore = PlayerPrefs.GetInt("ScoreHard", 0);
        if (GameManagerInstance.Instance.level == "easy")
        {
            finalscore.text = "SCORE: " + easyscore.ToString();
            level.text = "LEVEL EASY";
        }
        else if (GameManagerInstance.Instance.level == "medium")
        {
            finalscore.text = "SCORE: " + mediumScore.ToString();
            level.text = "LEVEL MEDIUM";
        }
        else if (GameManagerInstance.Instance.level == "hard")
        {
            finalscore.text = "SCORE: " + hardScore.ToString();
            level.text = "LEVEL HARD";
        }
    }
    
    // zurück zum Hauptmenü
    public void LoadMyScene(string menu)
    {
        SceneManager.LoadScene(menu);
    }
    // Click Sound
    public void ClickButton()
    {
        AudioManager.Instance.PlayClickSound();
    }
}