using UnityEngine;

public class DragonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public float moveDistance = 10f;      // �պ� �Ÿ�
    public float moveSpeed = 2f;          // �ӵ�

    private Vector3 startLocalPos;
    private int direction = 1;
    private Animator animator; 

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
        // �̵� ó��
        transform.localPosition += Vector3.right * direction * moveSpeed * Time.deltaTime;

        // �Ÿ� �ʰ� �� ���� ��ȯ
        if (Vector3.Distance(startLocalPos, transform.localPosition) >= moveDistance)
        {
            direction *= -1;
            startLocalPos = transform.localPosition;

            // ��������Ʈ �¿� ����
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

// �ϴ� �ִϸ��̼� ó�� �غ���
// �״°�, �������� ���ϴ°� �������� ������ ó��

/*public float moveDistance = 10f;      // �պ� �Ÿ�
public float moveSpeed = 10f;         // �ӵ�

private Vector3 startLocalPos;
private int direction = 1;
private Animator animator;

// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
    startLocalPos = transform.localPosition;    // ���� �������� ������
}

// Update is called once per frame
void Update()
{
    // �ڽ� ���� �������� �����̱�
    transform.localPosition += Vector3.right * direction * moveSpeed * Time.deltaTime;

    // �θ� ���� ��ġ �Ÿ� üũ
    if (Vector3.Distance(startLocalPos, transform.localPosition) >= moveDistance)
    {
        direction *= -1;
        startLocalPos = transform.localPosition;
    }
}*/