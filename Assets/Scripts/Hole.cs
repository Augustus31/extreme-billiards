using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    public AudioClip successClip;
    public AudioClip failClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            if(collision.gameObject.GetComponent<Ball>().num == 8)
            {
                GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().playSFXGame(successClip);
                GameObject.Destroy(collision.gameObject);
                GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().loadNextLevel();
            }
            else
            {
                GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().playSFXGame(failClip);
                GameObject.Destroy(collision.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (collision.gameObject.tag == "cueball")
        {
            GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().playSFXGame(failClip);
            GameObject.Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
