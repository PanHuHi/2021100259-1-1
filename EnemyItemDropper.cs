using UnityEngine;

public class EnemyItemDropper : MonoBehaviour
{
    [Header("아이템 프리팹")]
    [SerializeField] private GameObject powerUpItemPrefab;
    [SerializeField] private GameObject boomItemPrefab;

    [Header("드랍 확률 (0~1)")]
    [Range(0f, 1f)] public float powerUpDropRate = 0.3f;
    [Range(0f, 1f)] public float boomDropRate = 0.3f;

    // ✅ 외부에서 호출 (예: Enemy가 죽을 때)
    public void DropItem(Vector3 dropPosition)
    {
        // 총 강화 아이템 드랍
        if (Random.value < powerUpDropRate)
        {
            Instantiate(powerUpItemPrefab, dropPosition, Quaternion.identity);
        }

        // 폭탄 아이템 드랍
        if (Random.value < boomDropRate)
        {
            Instantiate(boomItemPrefab, dropPosition, Quaternion.identity);
        }
    }
}
