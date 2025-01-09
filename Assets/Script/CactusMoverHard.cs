using UnityEngine;
public class CactusMoverHard : MonoBehaviour
{
    public float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CactusMover();
    }

    // Update is called once per frame
    void Update()
    {
        // Kaktus "fällt" nach einer zufälligen Zeit runter
        float timerBetweenEvents = Random.Range(7f, 15f);
        if (timer >= timerBetweenEvents)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
        timer += Time.deltaTime;
    }

    // Kaktus erscheint rotiert
    public void CactusMover()
    {
        float randomTilt = Random.Range(-10, 10);
        transform.rotation = Quaternion.Euler(0, 0, randomTilt);
    }
}
