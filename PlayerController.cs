using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode KeyCodeAttack = KeyCode.Space;
    private Movement2D movement2D;
    private Weapon    weapon;
    [SerializeField]
    private string nextSceneName;


    public void OnDie()
    {
        SceneManager.LoadScene(nextSceneName);

        PlayerPrefs.SetInt("Score", score);
    }
    



    private int score;
    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        //방향키를 눌러 이동방향 설정
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        if (Input.GetKeyDown(KeyCodeAttack) )
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(KeyCodeAttack) )
        {
            weapon.stopFiring();
        }
    
    }

    private void LateUpdate()
    {
        //플레이어 캐릭터가 화면 밖으로 나가게 못하게
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                        Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

}
