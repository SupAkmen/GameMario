using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    private PlayerController movement;

    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public AnimatedSprite run;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerController>();
    }
    private void OnEnable()
    {
        spriteRenderer.enabled = true;
        run.enabled = false;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }
    private void LateUpdate()
    {
        run.enabled = movement.running;

        if( movement.jumping )
        {
            spriteRenderer.sprite = jump;
        }else if(movement.sliding )
        {
            spriteRenderer.sprite = slide;
        }else if(!movement.running)
        {
            spriteRenderer.sprite = idle;
        }
        
    }
}
