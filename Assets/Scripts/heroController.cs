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

        // ���� �� Step ���·� ����
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

    //�¿� ������
    void HandleMovement()
    {
        int key = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) key = -2;
        if (Input.GetKeyDown(KeyCode.RightArrow)) key = 2;

        float speedX = Mathf.Abs(rigid2D.linearVelocity.x);

        // ���� ����
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 2, 2);
        }

        // �̵� & �ִϸ��̼� ó��
        if (key != 0 && speedX < maxRunSpeed)
        {
            rigid2D.AddForce(transform.right * key * runForce);

            animator.SetBool("isStep", false);
            animator.SetBool("isRun", true);


            if (runResetCoroutine != null)
                StopCoroutine(runResetCoroutine); // ���� �ν� �ȵǰ� ��� ������ ����

            runResetCoroutine = StartCoroutine(runReset(0.4f)); // ������ 0.4�� �� ����
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

        // ���� ���̰ų� ���� ���̸� Step���� ���ư��� ����
        if (!isJump && !isAttack)
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isStep", true);
        }

        runResetCoroutine = null;
    }

    //����
    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            animator.SetBool("isStep", false);
            animator.SetTrigger("isJump");
            rigid2D.AddForce(Vector2.up * jumpForce);
            isJump = true;

            StartCoroutine(jumpReset(0.4f)); // ������ 0.4�� �� ����
        }
    }
    IEnumerator jumpReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        isJump = false;
        animator.SetBool("isStep", true);
    }

    //����
    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isAttack)
        {
            isAttack = true;
            animator.SetTrigger("isAttack");

            StartCoroutine(ResetAttack(0.4f));  // ������ 0.4�� �� ����
        }
    }

    IEnumerator ResetAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAttack = false;
    }

    //�巡������ Į �ֵθ� �� �浹����
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
            Debug.Log("�巡��� �浹");
            HandleDie();
        }
    }

    void HandleDie()
    {
        animator.SetTrigger("isDead");

        // �Է� ��Ȱ��ȭ
        this.enabled = false;

        // �ִϸ��̼��� ���� �� ��� �̵�
        StartCoroutine(DieAndLoadScene());
    }
    IEnumerator DieAndLoadScene()
    {
        // �ִϸ��̼� ��� �� ���� �� �ְ�
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("loseScene");
    }
}