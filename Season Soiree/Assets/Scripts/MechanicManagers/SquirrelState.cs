using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelState : MonoBehaviour
{
    public ChaserEnemy enemyScript;
    [SerializeField] Vector2 enemyHolePosition;


    public void EnableSquirrel(bool enabled)
    {
        enemyScript.enabled = enabled;
        enemyScript.gameObject.GetComponent<CircleCollider2D>().enabled = enabled;
        enemyScript.gameObject.GetComponent<Rigidbody2D>().isKinematic = !enabled;
        if (enabled)
        {
            enemyScript.gameObject.transform.position = enemyScript.GetHomePosition();
        }
        else
        {
            enemyScript.gameObject.transform.localPosition = enemyHolePosition;
        }
    }
}
