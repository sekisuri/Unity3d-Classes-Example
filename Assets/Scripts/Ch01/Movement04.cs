using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 리지드바디를 이용한 캐릭터 이동
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Movement04 : MonoBehaviour
{

    public float speed = 10f;
    private Rigidbody rb;
    private Vector3 moveDir;
    // private Transform tr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //tr = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDir.Set(h, 0, v);
        moveDir = moveDir.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + moveDir);

    }
}

   