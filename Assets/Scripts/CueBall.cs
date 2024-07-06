using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{
    public GameObject line;
    public bool ativo;

    // Start is called before the first frame update
    void Start()
    {
        line = GameObject.Find("Line");
        ativo = true;
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
    }

}
