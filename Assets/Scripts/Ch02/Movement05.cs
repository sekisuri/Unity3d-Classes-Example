using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 리지드바디를 이용한 캐릭터 회전
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Movement05 : MonoBehaviour {

    public float speed = 10f;
    private Rigidbody rb;
    private Vector3 moveDir;
    private float turnSpeed = 80;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //tr = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 캐릭터 이동
        moveDir.Set(h, 0, v);
        moveDir = moveDir.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + moveDir);

        if(h == 0 && v == 0)
        {
            return;
        }
        // 캐릭터 회전
        Quaternion turnDir = Quaternion.LookRotation(moveDir);
        rb.rotation = Quaternion.Slerp(rb.rotation, turnDir, turnSpeed * Time.deltaTime);
      //  rb.MoveRotation(turnDir);

    }
}
