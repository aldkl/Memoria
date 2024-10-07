using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterControl : MonoBehaviour
{
	public enum CharacterState { V, N, VN, E};

	public CharacterState CState;
	public string curState;
	public bool IsLeft;
	public Rigidbody PlayerRigidbody;


	public float Movespeed;
	public float UpDownSpeed;
	public float JumpPorce;
	public float MoveE;
	public float MoveEStat;
	public LayerMask GroundLayer;
	public bool bIsGrounded;
    public int maxDistance;
	public bool bIsLadder;

	float CurHorizontal;

	BoxCollider PlayerBox;
	private float xVal;
	private Animator anim;
	private Vector3 boxSize = new Vector3(0.1f, 1f,1f);
	private Transform Playertransform;
	RaycastHit hit;
	RaycastHit hit2;
	public bool isHit;
	public bool isHit2;


	Vector3 AA = new Vector3(0, +1.5f, 0);
	Vector3 BB = new Vector3(0.7f, +1f, 0);
	void ChangeAnimationState(string newState)
    {
		if (curState == newState) return;

		anim.Play(newState);

		curState = newState;
	}

	private void Start()
	{
		Playertransform = GetComponent<Transform>();
		PlayerRigidbody = GetComponent<Rigidbody>();
		PlayerBox = GetComponent<BoxCollider>();
		bIsGrounded = false;
		CheckInteraction();

		anim = GetComponent<Animator>();
		CState = CharacterState.N;
	}

	void MoveOn()
    {

		if(CurHorizontal != 0)
        {
			if (MoveE < 1)
			{
				MoveE += Time.deltaTime * MoveEStat;
			}
			if (MoveE > 1)
			{
				MoveE = 1;
			}
			if(CurHorizontal == 1)
            {
				IsLeft = false;
			}
			else
            {
				IsLeft = true;
			}
		}
		else
		{
			MoveE = 0;
		}

		Playertransform.Translate(MoveE * Movespeed * CurHorizontal * Time.deltaTime, 0, 0);

	}

	void InputKeys()
	{

			if (Input.GetKeyDown(KeyCode.Z))//상호작용
				CheckInteraction();
			if (Input.GetKeyDown(KeyCode.Space))//점프
			{
				if (bIsGrounded && !bIsLadder)
				{
					PlayerRigidbody.AddForce(Vector3.up * JumpPorce, ForceMode.Impulse);
				}
			}
			if (bIsLadder)
			{
				if (Input.GetKey(KeyCode.UpArrow))
				{
					Playertransform.Translate(Vector3.up * UpDownSpeed * Time.deltaTime);

				}
				else if (Input.GetKey(KeyCode.DownArrow))
				{
					Playertransform.Translate(Vector3.down * UpDownSpeed * Time.deltaTime);

				}
				else
				{

				}
			}
	}
	void CStateUpdate()
	{

		if (Input.GetKeyDown(KeyCode.X))//현실세계On
		{
			if (GameManager.Instance.NEyesON)
			{
				GameManager.Instance.NEyesON = false;
			}
			else
			{
				GameManager.Instance.NEyesON = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.C))//가상세계On
		{
			if (GameManager.Instance.VEyesON)
			{
				GameManager.Instance.VEyesON = false;
			}
			else
			{
				GameManager.Instance.VEyesON = true;
			}
		}
		
		if (GameManager.Instance.VEyesON && GameManager.Instance.NEyesON)
		{
			if (CState != CharacterState.VN)
            {
				CState = CharacterState.VN;
            }
		}
		else if(!GameManager.Instance.VEyesON && GameManager.Instance.NEyesON)
        {
			if (CState != CharacterState.N)
			{
				CState = CharacterState.N;
			}
		}
		else if (GameManager.Instance.VEyesON && !GameManager.Instance.NEyesON)
		{
			if (CState != CharacterState.V)
			{
				CState = CharacterState.V;
			}
		}
		else if (!GameManager.Instance.VEyesON && !GameManager.Instance.NEyesON)
		{
			if (CState != CharacterState.E)
			{
				CState = CharacterState.E;
			}
		}
	}
	
	void AnimationChange(string ChangeAni)
    {
		switch (CState)
		{
			case CharacterState.V:
				ChangeAnimationState("V" + ChangeAni);
				break;

			case CharacterState.N:
				ChangeAnimationState("N" + ChangeAni);
				break;

			case CharacterState.VN:
				ChangeAnimationState("VN" + ChangeAni);
				break;
		}
	}
	private void AnimatorUpdate()
    {

		anim.SetFloat("fHor", CurHorizontal);
		if(bIsGrounded)
        {
			if (CurHorizontal == 1)
			{
				AnimationChange("_Move_R");
			}
			else if (CurHorizontal == -1)
			{
				AnimationChange("_Move_L");
			}
			else
			{
				if (IsLeft)
				{
					AnimationChange("_Idle_L");
				}
				else
				{
					AnimationChange("_Idle_R");
				}
			}
		}
		else
        {
			if(!bIsLadder)
			{
				if (IsLeft)
				{
					AnimationChange("_Jump_L");
				}
				else
				{
					AnimationChange("_Jump_R");
				}
			}
			else
            {
				AnimationChange("_Ladder_L");
			}
		}

	}

	private void CheckInteraction()
	{
		RaycastHit[] hits = Physics.BoxCastAll(transform.position, boxSize, Vector3.zero, Quaternion.identity);

		if (hits.Length > 0)
		{
			foreach (RaycastHit rc in hits)
			{
				if (rc.IsInteractable())
				{
                    rc.Interact();
					return;
				}
			}
		}
	}

	private void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position + AA, transform.localScale);
    }

    void isGrounded()
    {
		//Ray ray = new Ray(Playertransform.position + AA, Vector3.down);
		//Ray ray2 = new Ray(Playertransform.position + BB, Vector3.down);
		//Debug.DrawRay(ray.origin, ray.direction, Color.red);
		//Debug.DrawRay(ray2.origin, ray2.direction, Color.red);
		
		isHit = Physics.BoxCast(Playertransform.position + AA, Playertransform.localScale / 2f, Vector3.down, out hit, Quaternion.identity, maxDistance, GroundLayer);
		//isHit = Physics.Raycast(Playertransform.position + AA, Vector3.down, out hit, maxDistance, GroundLayer);
		//isHit2 = Physics.Raycast(Playertransform.position + BB, Vector3.down, out hit2, maxDistance, GroundLayer);
		if (isHit || isHit2)
		{
			bIsGrounded = true;

			if (hit.collider != null && hit.collider.CompareTag("MovePlatform"))// || (hit2.collider != null && hit2.collider.CompareTag("MovePlatform")))
			{
				if (isHit)
				{
					Playertransform.parent = hit.transform;
				}
				//else if (isHit2)
				//{
				//	Playertransform.parent = hit2.transform;
				//}
			}
		}
		else
        {
			bIsGrounded = false;
			Playertransform.parent = GameObject.Find("GameMng").transform;
		}
	}

	void Update()
	{
		CurHorizontal = Input.GetAxisRaw("Horizontal");
		isGrounded();
		if (!GameManager.Instance.IsChatObj.activeSelf)
        {
			CStateUpdate();
			if (CState != CharacterState.E)
			{
				MoveOn();
				InputKeys();
				AnimatorUpdate();
			}
		}
	}

}