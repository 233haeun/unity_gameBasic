using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 300.0f;
    float walkForce = 10.0f;
    float maxWalkSpeed = 2.0f;
    Animator animator;
    private float targetFrameRate = 60f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.fixedDeltaTime = 1f / targetFrameRate;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //�¿��̵�
        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -2; //��
        if (Input.GetKey(KeyCode.RightArrow)) key = 2; //��

        float speedx = Mathf.Abs(this.rigid2D.linearVelocity.x);

        //speed ����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //�����̴� ���⿡ ���� ����
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 2, 2);
        }

        //�ִϸ��̼� �ӵ� �ٲٱ�
        this.animator.speed = speedx/2.0f;
    }
}
