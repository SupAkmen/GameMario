using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    public Transform player;
    public float height = 6.5f;
    public float undergroundHeight = -9.5f;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 camPos = transform.position;
        camPos.x = Mathf.Max(camPos.x, player.position.x);
        transform.position = camPos;
    }
    public void SetUnderGround(bool underground)
    {
        Vector3 cameraPos = transform.position;
        cameraPos.y = underground ? undergroundHeight : height;
        transform.position = cameraPos;
    }
}
