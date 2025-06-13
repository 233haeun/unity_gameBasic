using UnityEngine;

public class PlanetController : MonoBehaviour
{
    float rightMax = 17.0f;  // 왼쪽 이동가능한 최댓값
    float leftMax = -7.5f;  // 오른쪽 이동 가능한 최댓값
    float currentPos;        // 현위치 저장
    float speed = 2.0f;      // 이동 속도와 방향
    float startY;            // 초기 y값 저장

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPos = transform.position.x;
        startY = transform.position.y;  // Y값 초기 저장
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
