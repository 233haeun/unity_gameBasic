using UnityEngine;
using UnityEngine.SceneManagement; // 씬 로드를 위해 필요

public class director : MonoBehaviour
{
    public GameObject hero; // 주인공 오브젝트
    public float gameOverYPosition = -15f; // 게임 오버를 유발하는 y 좌표


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("GameScene"); // "gameScene"을 로드
        }
        // 주인공의 y 좌표가 설정한 값보다 작으면 게임 오버
        if (hero.transform.position.y <= gameOverYPosition)
        {
            // 씬 전환 (게임 오버 화면으로)
            SceneManager.LoadScene("loseScene");
        }
    }
}
