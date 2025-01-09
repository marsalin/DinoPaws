using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;


public class CactusSpawner : MonoBehaviour
{
    [FormerlySerializedAs("CactusPrefab")] public GameObject cactusPrefab;
    public float timeBetweenSpawns = 3.8f;
    // Bereich der zufälligen Höhe
    public float maxHeight = 2f;
    public float minHeight = -1f;
    public float x;
    public float randomY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Loop());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnCactus()
    {
        x = UnityEngine.Camera.main.transform.position.x + 18;
        // spawnt den Kaktus im "easy" Level, auf einer zufälligen Höhe
            GameObject cactus = Instantiate(cactusPrefab);
            cactus.transform.position = new Vector3(x, Random.Range(minHeight, maxHeight), 0);
            Destroy(cactus, 25);
    }
    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator Loop()
    {
        // Dauerschleife um unendlich Kakteen zu spawnen, allerdings mit Wartezeit dazwischen
        while (true)
        {
            SpawnCactus();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}