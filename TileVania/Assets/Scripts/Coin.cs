using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointstoadd = 1;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore(pointstoadd);
        Destroy(gameObject);
        
    }

}
