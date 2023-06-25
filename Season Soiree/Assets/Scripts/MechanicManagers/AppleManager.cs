using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    public ChaserEnemy enemyScript;
    public BoxCollider2D territory;
    public CircleCollider2D appleCollider;
    
    [SerializeField] Vector2 enemyHolePosition;

    void Update()
    {
        if (appleCollider.bounds.Intersects(territory.bounds))
        {
            enemyScript.SetTarget(appleCollider.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyScript.enabled = false;
            enemyScript.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            enemyScript.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            enemyScript.gameObject.transform.localPosition = enemyHolePosition;
            appleCollider.gameObject.SetActive(false);
        }
    }
}
