using UnityEngine;

public class Background : MonoBehaviour
{
    public float backgroundWidth = 10f;
    
    // Update is called once per frame
    void Update()
    {
        // teleportiert den Hintergrund
        if (UnityEngine.Camera.main.transform.position.x - transform.position.x > backgroundWidth)
        {
            transform.position += new Vector3(backgroundWidth * 6, 0, 0);
        }
    }
}