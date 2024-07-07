using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portal2;
    public bool disabled;
    public AudioClip portalClip;
    // Start is called before the first frame update
    void Start()
    {
        disabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!disabled)
        {
            GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().playSFXGame(portalClip);
            StartCoroutine(timeout());
            collision.gameObject.transform.position = portal2.transform.position;
        }
    }

    IEnumerator timeout()
    {
        portal2.GetComponent<Portal>().disabled = true;
        yield return new WaitForSeconds(2);
        portal2.GetComponent<Portal>().disabled = false;

    }
}
