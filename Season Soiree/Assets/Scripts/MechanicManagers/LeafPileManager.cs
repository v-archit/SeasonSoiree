using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPileManager : MonoBehaviour
{
    public GameObject leafPile;
    public ParticleSystem particleSystem;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter Collider");
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        particleSystem.Play();
        yield return new WaitForSeconds(0.5f);
        leafPile.SetActive(false);

    }
}
