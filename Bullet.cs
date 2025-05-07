using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private int damage = 1;
    void Start()
    {
        Invoke("DestroySelf", 2.0f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            //Destroy(collision.gameObject);

            Destroy(gameObject);
        }

    }
}
