using UnityEngine;
public class Character : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject currentCharacter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeCharacter();
    }
    
    public void RightButton()
    {
        // Erhöht den Index für den ausgewählten Charakter (charNum) zyklisch,
        // sodass er innerhalb der Array Grenzen bleibt
       GameManagerInstance.Instance.charNum = (GameManagerInstance.Instance.charNum + 1) % characterPrefabs.Length;
       ChangeCharacter();
    }

    public void LeftButton()
    {
        // Verringert den Index für den ausgewählten Charakter (charNum) zyklisch,
        // sodass er bei 0 auf das letzte Element im Array springt
        GameManagerInstance.Instance.charNum = GameManagerInstance.Instance.charNum -1 < 0 ? characterPrefabs.Length - 1 : GameManagerInstance.Instance.charNum -1;
        ChangeCharacter();
    }

    // zertört Charakter, falls vorhanden
    // spawnt neuen
    public void ChangeCharacter()
    {
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        } 
        currentCharacter = Instantiate(characterPrefabs[GameManagerInstance.Instance.charNum], Vector3.zero, Quaternion.identity);
    }
}