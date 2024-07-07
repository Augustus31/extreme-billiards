using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject selectedBall;
    public float velocity;
    public AudioClip cueBallClip;

    private CueBall cb;
    // Start is called before the first frame update
    void Start()
    {
        selectedBall = GameObject.Find("CueBall");
        cb = GameObject.Find("CueBall").GetComponent<CueBall>();
        velocity = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnMouseDown()
    {
        if (cb.ativo)
        {
            cb.ativo = false;
            GameObject.Find("LevelAudioController").GetComponent<LevelAudioController>().playSFXGame(cueBallClip);
            Vector3 thisToMouse = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - GameObject.Find("CueBall").transform.position;
            Vector2 norm = thisToMouse;
            norm = norm.normalized;
            GameObject.Find("CueBall").GetComponent<Rigidbody2D>().velocity = norm * velocity;
        }
    }
}
