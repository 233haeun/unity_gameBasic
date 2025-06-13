using UnityEngine;
using UnityEngine.SceneManagement;

public class director : MonoBehaviour
{
    public GameObject hero; // 주인공 오브젝트 불러오기
    public float gameOverYPosition = -15f; // 주인공 떨어질 때 게임 오버 시킬 y 좌표


    void Update()
    {

        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("s키 눌림");
            SceneManager.LoadScene("GameScene"); // "gameScene"을 로드
        }
        // 주인공 떨어지면 게임오버
        else if (hero.transform.position.y <= gameOverYPosition)
        {
            SceneManager.LoadScene("loseScene");
        }
    }
}
