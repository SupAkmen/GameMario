using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch(type)
        {
            case Type.Coin:
                GameManager.Instance.AddCoin();
                break;
            case Type.ExtraLife:
                GameManager.Instance.AddLife();

                break;
            case Type.MagicMushroom:
                GameManager.Instance.AddMushroom();
                player.GetComponent<Player>().Grow();
                break;
            case Type.Starpower:
                GameManager.Instance.AddStar();
                player.GetComponent<Player>().Starpower();
                break;
        }

        Destroy(gameObject);
    }
}
