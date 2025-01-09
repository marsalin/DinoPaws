using UnityEngine;

public class CameraSkript : MonoBehaviour

{
    private Transform player;
    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
            transform.position = new Vector3(player.position.x, 0, -10);
    }

    // Position des Spielers finden 
    public void FindPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
}