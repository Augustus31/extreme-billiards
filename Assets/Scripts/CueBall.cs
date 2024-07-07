using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{
    public GameObject line;
    public bool ativo;
    public int dashes;

    // Start is called before the first frame update
    void Start()
    {
        line = GameObject.Find("Line");
        ativo = true;
        dashes = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ativo)
        {
            Vector3 thisToMouse = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - transform.position;
            Vector2 norm = thisToMouse;
            norm = norm.normalized;

            line.transform.position = transform.position + new Vector3(norm.x, norm.y, 0) * 1.5f;
            line.transform.rotation = Quaternion.identity;
            line.transform.Rotate(0, 0, 90 + Mathf.Atan(norm.y / norm.x) * 180/Mathf.PI);
        }
        if (!ativo)
        {
            line.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.A) && dashes > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x);
            dashes -= 1;
        }

        if (Input.GetKeyDown(KeyCode.D) && dashes > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, -1* GetComponent<Rigidbody2D>().velocity.x);
            dashes -= 1;
        }

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

}
