using UnityEngine;

public class PlanetsController : MonoBehaviour
{
    float rightMax = 12.0f;  // ���� �̵������� �ִ�
    float leftMex = -12.0f;  // ������ �̵� ������ �ִ�
    float currentPos;        // ����ġ ����
    float speed = 2.0f;      // �̵� �ӵ��� ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos += Time.deltaTime * speed;
        if( currentPos >= rightMax )
        {
            speed *= -1;
            currentPos = rightMax;
        }
        else if ( currentPos <= leftMex )
        {
            speed *= -1;
            currentPos = leftMex;
        }
        transform.position = new Vector3(currentPos, 1, 0);
    }
}
