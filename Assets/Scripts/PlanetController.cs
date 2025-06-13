using UnityEngine;

public class PlanetController : MonoBehaviour
{
    float rightMax = 17.0f;  // ���� �̵������� �ִ�
    float leftMax = -7.5f;  // ������ �̵� ������ �ִ�
    float currentPos;        // ����ġ ����
    float speed = 2.0f;      // �̵� �ӵ��� ����
    float startY;            // �ʱ� y�� ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPos = transform.position.x;
        startY = transform.position.y;  // Y�� �ʱ� ����
    }

    // Update is called once per frame
    void Update()
    {
        currentPos += Time.deltaTime * speed;
        if (currentPos >= rightMax)
        {
            speed *= -1;
            currentPos = rightMax;
        }
        else if (currentPos <= leftMax)
        {
            speed *= -1;
            currentPos = leftMax;
        }
        transform.position = new Vector3(currentPos, startY, 0);
    }
}
