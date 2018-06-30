using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scene0301 리지드바디를 이용한 캐릭터 점프
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Movement07 : MonoBehaviour {

    public float speed = 10f;
    private Rigidbody rb;
    private Vector3 moveDir;
    private float turnSpeed = 80f;
    private float jumpPower = 3f;
    

    private float h, v;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //tr = GetComponent<Transform>();
    }

   
    private void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Run();
        Turn();
        Jump();
    }

    private void Run()
    {
        // 캐릭터 이동
        moveDir.Set(h, 0, v);
        moveDir = moveDir.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + moveDir);
    }
    private void Turn()
    {
        // 좌,우 입력이 없으면 리턴
        if (h == 0 && v == 0)
        {
            return;
        }
        // 캐릭터 회전
        Quaternion turnDir = Quaternion.LookRotation(moveDir);
        rb.rotation = Quaternion.Slerp(rb.rotation, turnDir, turnSpeed * Time.deltaTime);
    }
    private void Jump()
    {
        // 이중점프를 피하기 위해 현재 위치를 구해 y가 1.6이하 일 경우만 점프한다. 
        Vector3 jumpCheck = gameObject.transform.position;     
        if (Input.GetButtonDown("Jump") && jumpCheck.y  < 1.6f)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
     
    }

    
}
