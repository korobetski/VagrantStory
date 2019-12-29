using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class AshleyController : MonoBehaviour
{
    public float gravity = 20f;
    public float jumpSpeed = 20f;


    protected Vector2 m_Movement;
    protected Vector2 m_Camera;
    protected bool m_Jump;
    protected bool m_Attack;
    protected bool m_Pause;
    protected bool m_ExternalInputBlocked;

    private bool _jumping = false;
    private float _verticalForce = 0;
    private Animator _animator;
    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        m_Movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Debug.DrawRay(transform.position, new Vector3(m_Movement.x, 0, m_Movement.y)*10, Color.white);
        m_Camera.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        m_Jump = Input.GetButton("Jump");


        _animator.SetFloat("Movement", m_Movement.magnitude);

        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("Attack");
        }

        RaycastHit hitGround;
        bool bGround = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hitGround, Mathf.Infinity);
        
        if (hitGround.distance < 1.55f)
        {
            _jumping = false;
            _verticalForce = 0;
            _animator.SetBool("Grounded", true);
            _animator.SetBool("Jumping", false);
        } else
        {
            // we apply gravity when we arn't grounded
            _verticalForce = -gravity/8;
            _animator.SetBool("Grounded", false);
        }
        
        if (m_Jump && !_jumping)
        {
            _animator.SetBool("Jumping", true);
            _jumping = true;
            _verticalForce = jumpSpeed;
        }


        //Debug.Log(hitGround.distance);
        _rigidBody.MovePosition(transform.position + new Vector3(m_Movement.x, _verticalForce, m_Movement.y)* 18 * Time.deltaTime);



        Vector3 localMovementDirection = new Vector3(m_Movement.x, 0f, m_Movement.y).normalized;
        if (m_Movement.x != 0 || m_Movement.y != 0) {
            //transform.rotation = Quaternion.LookRotation(localMovementDirection);
            _rigidBody.MoveRotation(Quaternion.LookRotation(localMovementDirection));
        }
    }
}
