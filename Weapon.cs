using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab; //공격할 때 생성되는 발사체 프리펩
    [SerializeField]
    public float attackRate = 0.1f; //공격 속도
    private AudioSource audioSource;
    private int attackLevel = 1;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }
    public void stopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            AttackByLevel();
            audioSource.Play();

            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }
    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch ( attackLevel)
        {
            case 1:
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(BulletPrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(BulletPrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3:
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                cloneProjectile = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));

                cloneProjectile = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;

        }
    }    
}
