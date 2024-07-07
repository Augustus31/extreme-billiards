using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int num;
    public AudioClip ballClip;
    public AudioClip cueballClip;
    public AudioClip wallClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Convert the object's position from world space to viewport space
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // Check if the object is off-screen
        if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
            viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            // Destroy the game object if it is off-screen
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().playSFXGame(ballClip);
        }
        else if(collision.gameObject.tag == "cueball")
        {
            GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().playSFXGame(cueballClip);
        }
        else
        {
            GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().playSFXGame(wallClip);
        }
    }
}
