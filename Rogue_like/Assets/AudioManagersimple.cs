using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagersimple : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Clips de Audio")]
    public AudioClip menuClip;
    public AudioClip level1Clip;
    public AudioClip level2Clip;
    public AudioClip level3Clip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.loop = true;
        audioSource.playOnAwake = false;

        // Cambiar música según la escena actual
        ChangeAudio(SceneManager.GetActiveScene().buildIndex);

        // Suscribirse al evento de cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeAudio(scene.buildIndex);
    }

    private void ChangeAudio(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 0: // Escena de menú
                audioSource.clip = menuClip;
                break;
            case 1: // Nivel 1
                audioSource.clip = menuClip;
                break;
            case 2: // Nivel 2
                audioSource.clip = level1Clip;
                break;
            case 3: // Nivel 2
                audioSource.clip = level2Clip;
                break;
            case 4: // Nivel 2
                audioSource.clip = level3Clip;
                break;
            default:
                Debug.LogWarning("No se ha asignado un clip para esta escena.");
                return;
        }

        audioSource.Play();
    }
}
