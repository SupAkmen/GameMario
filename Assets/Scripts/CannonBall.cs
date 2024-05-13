using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float timeBtwFire = 3f;
    public float destroyDelay = 3f;
    public float horizontalForce = -20f;
    private bool autoFiring = false;

    private void Start()
    {
        
    }
    void AutoFire()
    {
      

         Rigidbody2D rb = GetComponent<Rigidbody2D>();
         rb.AddForce( new Vector2(horizontalForce,0) , ForceMode2D.Impulse);

        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    public void StartAutoFire()
    {
        autoFiring = true;
        StartCoroutine(AutoFireRoutine());
    }

    IEnumerator AutoFireRoutine()
    {
        while (autoFiring)
        {
            AutoFire();
            yield return new WaitForSeconds(timeBtwFire);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

           if(player != null)
            {
                player.Hit();
            }
        }
    }
}
