using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class AshleyController : MonoBehaviour
{
    public float jumpSpeed = 20f;


    protected Vector2 m_Movement;
    protected Vector2 m_Camera;
    protected bool m_Jump;
    protected bool m_Attack;
    protected bool m_Pause;
    protected bool m_ExternalInputBlocked;

    private bool _jumping = false;
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
        Debug.DrawRay(transform.position, new Vector3(m_Movement.x, 0, m_Movement.y) * 10, Color.white);
        m_Camera.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        m_Jump = Input.GetButton("Jump");


        _animator.SetFloat("Movement", m_Movement.magnitude);

        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("Attack");
        }


        Vector3 sol = transform.position - new Vector3(0, 1.54f);
        Vector3 pieds = transform.position - new Vector3(0, 1.05f);
        Vector3 genoux = transform.position - new Vector3(0, 0.4f);
        Vector3 tete = transform.position + new Vector3(0, 1.1f);
        Vector3 haut = transform.position + new Vector3(0, 1.3f);

        RaycastHit hitGround;
        RaycastHit hitSol;
        RaycastHit hitPieds;
        RaycastHit hitGenoux;
        RaycastHit hitCorps;
        RaycastHit hitTete;
        RaycastHit hitHaut;

        bool bGround = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hitGround, Mathf.Infinity);
        bool bSol = Physics.Raycast(sol, transform.TransformDirection(Vector3.forward), out hitSol, Mathf.Infinity);
        bool bPieds = Physics.Raycast(pieds, transform.TransformDirection(Vector3.forward), out hitPieds, Mathf.Infinity);
        bool bGenoux = Physics.Raycast(genoux, transform.TransformDirection(Vector3.forward), out hitGenoux, Mathf.Infinity);
        bool bCorps = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitCorps, Mathf.Infinity);
        bool bTete = Physics.Raycast(tete, transform.TransformDirection(Vector3.forward), out hitTete, Mathf.Infinity);
        bool bHaut = Physics.Raycast(haut, transform.TransformDirection(Vector3.forward), out hitHaut, Mathf.Infinity);


        if (bGround)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hitGround.distance, Color.black);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
        }

        if (bSol)
        {
            Debug.DrawRay(sol, transform.TransformDirection(Vector3.forward) * hitSol.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(sol, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

        if (bPieds)
        {
            Debug.DrawRay(pieds, transform.TransformDirection(Vector3.forward) * hitPieds.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(pieds, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

        if (bGenoux)
        {
            Debug.DrawRay(genoux, transform.TransformDirection(Vector3.forward) * hitGenoux.distance, Color.magenta);
        }
        else
        {
            Debug.DrawRay(genoux, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

        if (bCorps)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitCorps.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

        if (bTete)
        {
            Debug.DrawRay(tete, transform.TransformDirection(Vector3.forward) * hitTete.distance, Color.cyan);
        }
        else
        {
            Debug.DrawRay(tete, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

        if (bHaut)
        {
            Debug.DrawRay(haut, transform.TransformDirection(Vector3.forward) * hitHaut.distance, Color.blue);
        }
        else
        {
            Debug.DrawRay(haut, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

        //Debug.Log(hitGround.distance);

        Vector3 localMovementDirection = new Vector3(m_Movement.x, 0f, m_Movement.y).normalized;

        _animator.SetFloat("Ground Distance", hitGround.distance - 1.55f);
        if (hitGround.distance <= 1.56f)
        {
            _jumping = false;
            _animator.SetBool("Grounded", true);
        }
        else
        {
            // we apply gravity when we arn't grounded
            _rigidBody.AddForce(Vector3.down * Mathf.Pow(Physics.gravity.y * 0.5f, 2), ForceMode.Acceleration);
            _animator.SetBool("Grounded", false);
        }

        if (m_Jump && !_jumping)
        {
            _animator.SetTrigger("Jumping");
            _jumping = true;
            _rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            _rigidBody.AddForce(localMovementDirection * jumpSpeed * 2, ForceMode.Impulse);
        }


        int step = 0;
        if (bPieds && (!bGenoux || hitGenoux.distance > hitPieds.distance) && hitPieds.distance < 0.5f)
        {
            step = 4;
            m_Movement *= 1.5f;
            _animator.SetBool("Grounded", false);
            _animator.Play("Step Up");
        }

        if (bCorps && (!bTete || hitTete.distance > (hitCorps.distance + 1f)) && hitCorps.distance < 0.5f)
        {
            _animator.SetBool("Climbing", true);
            _animator.SetBool("Grounded", false);
            _animator.Play("Climb");

            _rigidBody.MoveRotation(Quaternion.LookRotation(-hitCorps.normal));
        }
        _animator.SetInteger("Step", step);



        if (_animator.GetBool("Climbing") == false)
        {
            _rigidBody.MovePosition(transform.position + new Vector3(m_Movement.x, step, m_Movement.y) * 6 * Time.fixedDeltaTime);
            if (m_Movement.x != 0 || m_Movement.y != 0)
            {
                _rigidBody.MoveRotation(Quaternion.LookRotation(localMovementDirection));
            }
        }
        else
        {
            if (transform.TransformDirection(Vector3.forward) == localMovementDirection)
            {
                _rigidBody.MovePosition(transform.position + new Vector3(m_Movement.x, 12, m_Movement.y) * 6 * Time.fixedDeltaTime);
                _animator.SetBool("Climbing", false);
            }

        }
    }
}
