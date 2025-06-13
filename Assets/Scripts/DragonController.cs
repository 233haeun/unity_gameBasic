using UnityEngine;
using System.Collections;

public class DragonController : MonoBehaviour
{
    private Vector3 startLocalPos;
    private Animator animator;
    public GameObject planetPrefab;

    private int direction = 1;
    private bool isDie = false;
    public float moveDistance = 2.5f;      // �պ� �Ÿ�
    public float moveSpeed = 0.7f;          // �ӵ�


    void Start()
    {
        startLocalPos = transform.localPosition;
        animator = GetComponent<Animator>();

        // �ȴ� �ִϸ��̼� ���� (Animator�� walk�� �⺻ ���¶�� �ʿ� ����)
        if (animator != null)
        {
            animator.Play("DragonWalk");
        }
    }

    void Update()
    {
        if (isDie) return; // �׾����� �̵� ����
        // �̵� ó��
        transform.localPosition += Vector3.right * direction * moveSpeed * Time.deltaTime;

        // // �Ÿ� �ʰ� �� ���� ��ȯ
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

            // �ݶ��̴� ��Ȱ��ȭ
            Collider2D myCollider = GetComponent<Collider2D>();
            if (myCollider != null)
            {
                myCollider.enabled = false;
            }

            // �ִϸ��̼� Ʈ����
            if (animator != null)
            {
                animator.SetTrigger("isDie");
            }

            // StartCoroutine(DieAfterDelay(1.0f));
        }
    }
}