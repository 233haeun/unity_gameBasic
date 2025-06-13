using UnityEngine;
using UnityEngine.SceneManagement;

public class director : MonoBehaviour
{
    public GameObject hero; // ���ΰ� ������Ʈ �ҷ�����
    public float gameOverYPosition = -15f; // ���ΰ� ������ �� ���� ���� ��ų y ��ǥ


    void Update()
    {

        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("sŰ ����");
            SceneManager.LoadScene("GameScene"); // "gameScene"�� �ε�
        }
        // ���ΰ� �������� ���ӿ���
        else if (hero.transform.position.y <= gameOverYPosition)
        {
            SceneManager.LoadScene("loseScene");
        }
    }
}
