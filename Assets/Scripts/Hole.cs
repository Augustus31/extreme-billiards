using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
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
                //REPLACE THIS
                GameObject.Destroy(collision.gameObject);
                print("next level reached");
            }
            else
            {
                //REPLACE THIS
                GameObject.Destroy(collision.gameObject);
                print("reset level");
            }
        }
        if (collision.gameObject.tag == "cueball")
        {
            //REPLACE THIS
            GameObject.Destroy(collision.gameObject);
            print("reset level");
        }
    }
}
