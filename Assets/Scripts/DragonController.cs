using UnityEngine;
using System.Collections;

public class DragonController : MonoBehaviour
{
    private Vector3 startLocalPos;
    private Animator animator;
    public GameObject planetPrefab;

    private int direction = 1;
    private bool isDie = false;
    public float moveDistance = 2.5f;      // 왕복 거리
    public float moveSpeed = 0.7f;          // 속도


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
        if (isDie) return; // 죽었으면 이동 중지
        // 이동 처리
        transform.localPosition += Vector3.right * direction * moveSpeed * Time.deltaTime;

        // // 거리 초과 시 방향 전환
        if (Vector3.Distance(startLocalPos, transform.localPosition) >= moveDistance)
        {
            direction *= -1;
            startLocalPos = transform.localPosition;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDie) return;

        if (other.CompareTag("Attack"))
        {
            isDie = true;

            // 콜라이더 비활성화
            Collider2D myCollider = GetComponent<Collider2D>();
            if (myCollider != null)
            {
                myCollider.enabled = false;
            }

            // 애니메이션 트리거
            if (animator != null)
            {
                animator.SetTrigger("isDie");
            }

            // StartCoroutine(DieAfterDelay(1.0f));
        }
    }
}