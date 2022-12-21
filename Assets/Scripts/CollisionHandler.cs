using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] AudioClip landingSound, crashSound;
    [SerializeField] ParticleSystem successParticles, crashParticles;
    AudioSource audioSource;
    public bool isUsed = false;
    public bool collisionDisabled = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isUsed == true || collisionDisabled) return;


        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly object!");
                break;
            case "Fuel":
                Debug.Log("Adding fuel...");
                break;
            case "Finish":
                Debug.Log("Finishing level...");
                StartLoadingNextLevel();
                break;
            default:
                Debug.Log("Destroying Rocket!");
                CrashSequence();
                break;
        }

    
    }


    public void CrashSequence()
    {
        isUsed = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("reloadScene", delay);
    }
    
    public void levelFinished(){
        int finishedLevel = SceneManager.GetActiveScene().buildIndex;
        int avaliableLevelToGo = finishedLevel +1;
        PlayerPrefs.SetInt("reachedLevel",avaliableLevelToGo);
        Debug.Log(PlayerPrefs.GetInt("reachedLevel"));
    }
    public void StartLoadingNextLevel()
    {
        isUsed = true;
        audioSource.Stop();
        audioSource.PlayOneShot(landingSound);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        levelFinished();
        Invoke("loadNextScene", delay);
    }
    public void reloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
            SceneManager.LoadScene(nextSceneIndex);
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
