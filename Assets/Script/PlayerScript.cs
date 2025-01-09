using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D player;
    public float velocity = 3.0f;
    public int score = 0;
    public Text counter;
    public Text counterMedium;
    public Text counterHard;
    public float speed;
    public float timeRemaining = 3f;
    public float timer = 0;
    private int lastScore = -1;
    private bool jump;
    public int randomEffect;
    public GameObject randomEffectObject;
    public Text randomEffectText;
    public AudioSource jumpSound;
    public AudioSource effectSound;
    public AudioSource scoreSound;
    public AudioSource gameOverSound;
    
    void Start()
    {
        // GameObjectss finden um später darauf zuzugreifen
        player = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0, 0, 0);
        if (GameManagerInstance.Instance.level == "medium" || GameManagerInstance.Instance.level == "hard")
        {
            randomEffectObject = GameObject.Find("RandomEffect");
            randomEffectText = randomEffectObject.GetComponentInChildren<Text>();
            randomEffectObject.SetActive(false);
        }
    }
    
    void Update()
    {
        // Spieler geht automatisch nach vorne
        if (GameManagerInstance.Instance.level == "easy" )
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }
        // und bei "medium" & "hard" bekommt er Spieler alle 5 Punkte einen zufälligen Effekt
        else if (GameManagerInstance.Instance.level == "medium" || GameManagerInstance.Instance.level == "hard")
        {
            transform.Translate(Vector2.right * (Time.deltaTime * speed));
            if ((score % 5 == 0 && score > 0) && score != lastScore)
            {
                effectSound.Play();
                RandomEffect();
                lastScore = score;
            }
            if (timer >= timeRemaining)
            {
                velocity = 3.5f;
                speed = 1.5f;
                timer = 0;
                randomEffectObject.SetActive(false);
            }
            timer += Time.deltaTime;
        }
        // Bool jump wird bei Leertaste auf true gesetzt
        if (Input.GetKeyDown(KeyCode.Space))
        {
           jump = true;
           jumpSound.Play();
        }
    }

    // wenn jump = true, springt der Spieler
    void FixedUpdate()
    {
        if (jump)
        {
            player.linearVelocity = Vector2.up * velocity;
            //springt schneller, wenn man schneller drückt
            //player.AddForce(Vector2.up * velocity, ForceMode2D.Impulse);
            jump = false;
        }
    }
    
    // setzt score +1, wenn Spieler durch CactusCheck Collider fliegt
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CactusCheck"))
        {
            scoreSound.Play();
            score++;
            if (GameManagerInstance.Instance.level == "easy")
            {
                counter = GameObject.Find("counter").GetComponent<Text>();
                counter.text = score.ToString();
            }
            else if (GameManagerInstance.Instance.level == "medium")
            {
                counterMedium = GameObject.Find("counterMedium").GetComponent<Text>();
                counterMedium.text = score.ToString();
            }
            else if (GameManagerInstance.Instance.level == "hard")
            {
                counterHard = GameObject.Find("counterHard").GetComponent<Text>();
                counterHard.text = score.ToString();
            }
            Destroy(other.gameObject);
        }
    }
    
    // Score in PlayerPrefs speichern, wenn Spieler gegen Kaktus oder Boden fliegt, lädt dann DeathScreen
    void OnCollisionEnter2D(Collision2D hitObstacle)
    {
        if (hitObstacle.collider.CompareTag("Cactus") || hitObstacle.collider.CompareTag("Ground"))
        {
            if (GameManagerInstance.Instance.level == "medium")
            {
                PlayerPrefs.SetInt("ScoreMedium", score);
            }
            else if (GameManagerInstance.Instance.level == "easy")
            {
                PlayerPrefs.SetInt("ScoreEasy", score);
            }
            else if (GameManagerInstance.Instance.level == "hard")
            {
                PlayerPrefs.SetInt("ScoreHard", score);
            }
            gameOverSound.Play();
            SceneManager.LoadScene("Death");
        }
        else if (hitObstacle.collider.CompareTag("Wall"))
        {
            gameOverSound.Play();
        }
    }

    // zufälliger Effekt wird ausgewählt und angewendet
    public void RandomEffect()
    {
        randomEffect = Random.Range(1, 5);
        if (randomEffect == 1)
        {
            velocity = 5f;
            randomEffectObject.SetActive(true);
            randomEffectText.text = "Jump Boost!";
        }
        else if (randomEffect == 2)
        {
            speed = 2.0f;
            randomEffectObject.SetActive(true);
            randomEffectText.text = "Speed Boost!";
        }
        else if (randomEffect == 3)
        {
            velocity = 1.5f;
            randomEffectObject.SetActive(true);
            randomEffectText.text = "Low Jump!";
        }
        else if (randomEffect == 4)
        {
            score += 5;
            randomEffectObject.SetActive(true);
            randomEffectText.text = "Extra Points!";
            if (GameManagerInstance.Instance.level == "easy")
            {
                counter.text = score.ToString();
            }
            else if (GameManagerInstance.Instance.level == "medium")
            {
                counterMedium.text = score.ToString();
            }
            else if (GameManagerInstance.Instance.level == "hard")
            {
                counterHard.text = score.ToString();
            }
        }
    }
}