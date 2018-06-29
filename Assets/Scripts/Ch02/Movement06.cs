using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement06 : MonoBehaviour {

    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Input.GetAxis("Horizontal")과 InputGetAxis("Vertical")로 각각 좌우 방향키와 상하 방향키를 눌렀는지 알 수 있다.
        //두 함수는 -1.0(왼쪽 아래)에서 1.0(오른쪽 위) 사이의 값을 반환하며 이 값은 각각 X와 Z의 이동량, 
        //즉 키의 입력 방향에 따라 달라진다.
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(direction.sqrMagnitude > 0.01f)
        {
            //direction.sqrMagnitude로 이동량을 가져온다.
            //캐릭터가 이미 이동하고 있을 때 Vector3.Slerp()로
            //현재 캐릭터의 방향과 키의 입력 방향을 사용해서 새로운 방향을 계산한다.
            //그리고 transform.LookAt()으로 게임 오브젝트의 방향을 바꾼다.
            Vector3 forward = Vector3.Slerp(
                transform.forward,
                direction,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward,direction)
                );
            transform.LookAt(transform.position + forward);
        }

        // Position 값을 직접 바꾸는 대신 CharacterController의 Move()를 이용한다. 이렇게 하면
        // 단순히 위치만 변경하는 것이 아니라 이동하는 것이므로 충돌 처리를 할 수 있으면 속도 값도 없을 수 있다.
        characterController.Move(direction * moveSpeed * Time.deltaTime);
    }
}
