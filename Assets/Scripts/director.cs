using UnityEngine;
using UnityEngine.SceneManagement; // �� �ε带 ���� �ʿ�

public class director : MonoBehaviour
{
    public GameObject hero; // ���ΰ� ������Ʈ
    public float gameOverYPosition = -15f; // ���� ������ �����ϴ� y ��ǥ


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("GameScene"); // "gameScene"�� �ε�
        }
        // ���ΰ��� y ��ǥ�� ������ ������ ������ ���� ����
        if (hero.transform.position.y <= gameOverYPosition)
        {
            // �� ��ȯ (���� ���� ȭ������)
            SceneManager.LoadScene("loseScene");
        }
    }
}
