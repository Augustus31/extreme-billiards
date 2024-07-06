using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject selectedBall;
    public float velocity;

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
        
    }

    void OnMouseDown()
    {
        cb.ativo = false;
        Vector3 thisToMouse = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - GameObject.Find("CueBall").transform.position;
        Vector2 norm = thisToMouse;
        norm = norm.normalized;
        GameObject.Find("CueBall").GetComponent<Rigidbody2D>().velocity = norm * velocity;
    }
}
