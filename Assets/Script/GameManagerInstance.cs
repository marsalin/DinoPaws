using UnityEngine;
// Container für Variablen, statische Variablen werden hier "gesetzt"
// Singleton
public class GameManagerInstance : MonoBehaviour
{
    public static GameManagerInstance Instance 
    {
        get
        {
            if (instance == null)
            {
                GameObject g = new GameObject("UberManager");
                DontDestroyOnLoad(g);
                GameManagerInstance script = g.AddComponent<GameManagerInstance>();
                instance = script;
            }
            return instance;
        }
        private set => instance = value;
    }
    private static GameManagerInstance instance; 
   
    public int charNum;
    public string level;
    public bool isPaused;
}
