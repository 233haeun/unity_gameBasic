using UnityEngine;

public class PlanetsController : MonoBehaviour
{
    float rightMax = 12.0f;  // 왼쪽 이동가능한 최댓값
    float leftMex = -12.0f;  // 오른쪽 이동 가능한 최댓값
    float currentPos;        // 현위치 저장
    float speed = 2.0f;      // 이동 속도와 방향

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
