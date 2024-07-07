using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWall : MonoBehaviour
{
    public AudioClip electroClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 7)
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity *= 2;
           //GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().playSFXBall(electroClip);
        }
        //HAVE SOME COOL EFFECT HERE
    }
}
