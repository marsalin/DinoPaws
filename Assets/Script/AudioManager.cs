using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    public static AudioManager Instance;
    public AudioClip clickSound;
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // lade die gespeicherte Lautstärke
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 0.5f);
        AudioListener.volume = savedVolume;
        // Wenn der Slider existiert, initialisiere ihn mit dem gespeicherten Wert
        // und füge ein Event hinzu, das auf Lautstärkeänderungen reagiert
        if (volumeSlider != null) 
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    // Setzt die Lautstärke und speichert sie in den PlayerPrefs
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("GameVolume", volume);
    }

    // spielt einen ClickSound ab
    public void PlayClickSound()
    {
        GameObject clickSoundObject = new GameObject("ClickSound");
        AudioSource clickSource = clickSoundObject.AddComponent<AudioSource>();
        clickSource.clip = clickSound;
        clickSource.Play();
        Destroy(clickSoundObject, clickSound.length/clickSource.pitch);
        DontDestroyOnLoad(clickSoundObject);
    }
}