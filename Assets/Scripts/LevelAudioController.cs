using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAudioController : MonoBehaviour
{
    public int level;
    public AudioSource source1;
    public AudioSource source2;
    public AudioSource source3;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("LevelAudioController").Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNextLevel()
    {
        if(level != 7)
        {
            level++;
            SceneManager.LoadScene("Level " + level);
        }
        else
        {
            Quit();
        }
    }

    public void Quit()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void playMusic(AudioClip clip)
    {
        source1.clip = clip;
        source1.Play();
    }
    public void playSFXBall(AudioClip clip)
    {
        source2.clip = clip;
        source2.Play();
    }
    public void playSFXGame(AudioClip clip)
    {
        source3.clip = clip;
        source3.Play();
    }
}
