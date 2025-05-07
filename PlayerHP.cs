using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    // Start is called before the first frame update

    private float maxHP = 10;
    private float currentHP;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;
    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;


    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Debug.Log("Player health : 0.....Die");
            playerController.OnDie();
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(1);
        Debug.Log("currentHP:" + currentHP);
    }
    void Start()
    {
        Debug.Log("Player currentHP : " + currentHP);
    }

    public IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
