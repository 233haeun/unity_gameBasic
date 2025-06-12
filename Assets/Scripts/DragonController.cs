using UnityEngine;

public class DragonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public float moveDistance = 10f;      // 왕복 거리
    public float moveSpeed = 2f;          // 속도

    private Vector3 startLocalPos;
    private int direction = 1;
    private Animator animator; 

    void Start()
    {
        startLocalPos = transform.localPosition;
        animator = GetComponent<Animator>();

        // 걷는 애니메이션 시작 (Animator에 walk가 기본 상태라면 필요 없음)
        if (animator != null)
        {
            animator.Play("DragonWalk");
        }
    }

    void Update()
    {
        // 이동 처리
        transform.localPosition += Vector3.right * direction * moveSpeed * Time.deltaTime;

        // 거리 초과 시 방향 전환
        if (Vector3.Distance(startLocalPos, transform.localPosition) >= moveDistance)
        {
            direction *= -1;
            startLocalPos = transform.localPosition;

            // 스프라이트 좌우 반전
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}

/*void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

=======*/

// 일단 애니메이션 처리 해보기
// 죽는거, 보석으로 변하는거 저리히고 프리펩 처리

/*public float moveDistance = 10f;      // 왕복 거리
public float moveSpeed = 10f;         // 속도

private Vector3 startLocalPos;
private int direction = 1;
private Animator animator;

// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
    startLocalPos = transform.localPosition;    // 로컬 기준으로 움직임
}

// Update is called once per frame
void Update()
{
    // 자식 내부 기준으로 움직이기
    transform.localPosition += Vector3.right * direction * moveSpeed * Time.deltaTime;

    // 부모 기준 위치 거리 체크
    if (Vector3.Distance(startLocalPos, transform.localPosition) >= moveDistance)
    {
        direction *= -1;
        startLocalPos = transform.localPosition;
    }
}*/