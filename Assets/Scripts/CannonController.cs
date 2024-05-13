using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public Transform firePoint;
    public float fireInterval = 3f;
    public float detectionRange = 5f; 

    private float timeSinceLastFire = 0f;
    private GameObject player; 

    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
    }

    void Update()
    {
        timeSinceLastFire += Time.deltaTime;

        
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange && timeSinceLastFire >= fireInterval)
        {
            FireCannon();
            timeSinceLastFire = 0f;
        }
    }

    void FireCannon()
    {
       
        GameObject cannonBall = Instantiate(cannonBallPrefab, firePoint.position, firePoint.rotation);

     
        CannonBall cannonBallController = cannonBall.GetComponent<CannonBall>();
        if (cannonBallController != null)
        {
            cannonBallController.StartAutoFire();
        }
    }

}
