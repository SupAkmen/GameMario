using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;
    float startingY;
    int dir = 1;
    void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if (transform.position.y < startingY || transform.position.y > (startingY + range))
        {
            dir *= -1;
        }


    }
}
