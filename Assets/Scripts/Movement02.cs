using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement02 : MonoBehaviour {

    private float h = 0.0f;
    private float v = 0.0f;

    // 접근해야 하는 컴포넌트는 반드시 변수에 할당한 후 사용
    private Transform tr;
    //이동 속도 변수(public으로 선언되어 Inspector에 노출됨
    public float moveSpeed = 10.0f;
    /// <summary>
    /// Input.GetAxis("Horizontal")함수는 InputManager의 "Horizontal"에 미리
    /// 설정한 값으로 키보드의 A,D 또는 화살표키 Left,Right를 눌렀을 때 -1.0f부터 +1.0f까지의
    /// 값을 반환하며 Input.GetAxis("Vertical")함수 역시 키보드의 W,D,Up,Down을 눌렀을 때 
    /// -1.0부터 +1.0f 까지의 값을 반환한다. 또한 해당 키보드를 누르지 않을 때는 0.0f값이 반환된다.
    /// </summary>


    private void Start()
    {
        //스크립트가 실행된 후 처음 수행되는 Start 함수에서 Transform 컴포넌트를 할당.
        tr = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        //Translate(이동 방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
    }
}
