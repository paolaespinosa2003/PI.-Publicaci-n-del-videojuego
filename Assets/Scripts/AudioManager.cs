using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }
    public void PlaySFX(AudioClip clip){ if (sfxSource && clip) sfxSource.PlayOneShot(clip); }
    public void PlayMusic(AudioClip clip, bool loop = true){ if (musicSource && clip){ musicSource.clip = clip; musicSource.loop = loop; musicSource.Play(); } }
}