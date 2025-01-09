using UnityEngine;

public class CactusMoverMedium : MonoBehaviour
{
    public float height = 1.2f;
    public float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        // Kaktus bewegt sich entlang der Y-Achse hin und her
        float newY = Mathf.Sin(Time.time + transform.position.x * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z) ;
    }
}
