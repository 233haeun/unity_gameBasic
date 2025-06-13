using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class heroController : MonoBehaviour
{
    Coroutine runResetCoroutine;

    public GameObject attackCollider;

    private Animator animator;
    private Rigidbody2D rigid2D;

    public float runForce = 30f;
    public float maxRunSpeed = 60f;
    public float jumpForce = 680f;

    private bool isRun = false;
    private bool isJump = false;
    private bool isAttack = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();

        // 시작 시 Step 상태로 진입
        animator.SetBool("isStep", true);

        GameObject attackColliderObject = transform.Find("attackCollider").gameObject;
        attackCollider.SetActive(false);
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleAttack();
    }

    //좌우 움직임
    void HandleMovement()
    {
        int key = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) key = -2;
        if (Input.GetKeyDown(KeyCode.RightArrow)) key = 2;

        float speedX = Mathf.Abs(rigid2D.linearVelocity.x);

        // 방향 반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 2, 2);
        }

        // 이동 & 애니메이션 처리
        if (key != 0 && speedX < maxRunSpeed)
        {
            rigid2D.AddForce(transform.right * key * runForce);

            animator.SetBool("isStep", false);
            animator.SetBool("isRun", true);


            if (runResetCoroutine != null)
                StopCoroutine(runResetCoroutine); // 리셋 인식 안되고 계속 움직임 방지

            runResetCoroutine = StartCoroutine(runReset(0.4f)); // 무조건 0.4초 후 리셋
        }
        else if (isRun)
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isStep", true);
        }
    }
    IEnumerator runReset(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 공격 중이거나 점프 중이면 Step으로 돌아가지 않음
        if (!isJump && !isAttack)
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isStep", true);
        }

        runResetCoroutine = null;
    }

    //점프
    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            animator.SetBool("isStep", false);
            animator.SetTrigger("isJump");
            rigid2D.AddForce(Vector2.up * jumpForce);
            isJump = true;

            StartCoroutine(jumpReset(0.4f)); // 무조건 0.4초 후 리셋
        }
    }
    IEnumerator jumpReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        isJump = false;
        animator.SetBool("isStep", true);
    }

    //공격
    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isAttack)
        {
            isAttack = true;
            animator.SetTrigger("isAttack");

            StartCoroutine(ResetAttack(0.4f));  // 무조건 0.4초 후 리셋
        }
    }

    IEnumerator ResetAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAttack = false;
    }

    //드래곤한테 칼 휘두를 때 충돌감지
    public void EnableAttackCollider()
    {
        attackCollider.SetActive(true);
    }

    public void DisableAttackCollider()
    {
        attackCollider.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("dragon"))
        {
            Debug.Log("드래곤과 충돌");
            HandleDie();
        }
    }

    void HandleDie()
    {
        animator.SetTrigger("isDead");

        // 입력 비활성화
        this.enabled = false;

        // 애니메이션이 끝난 후 장면 이동
        StartCoroutine(DieAndLoadScene());
    }
    IEnumerator DieAndLoadScene()
    {
        // 애니메이션 재생 후 죽을 수 있게
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("loseScene");
    }
}