using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public  GameObject target;
	NavMeshAgent agent;
	Animator animator;


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// NavmeshAgent의 destination에 어떤 위치를 설정하면 해당 위치로 자동으로 이동된다.
		// 이번절에서는 사용자가 Inspector에서 게임 오브젝트를 지정하는데,
		// 지정한 게임 오브젝트의 위치인 target.transform.position을 NavMeshAgent의
		// destination에 설정하는 코드다.
		agent.destination = target.transform.position;
		animator.SetFloat ("Speed", agent.velocity.magnitude);
	
	}
}
