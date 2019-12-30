using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Animator animator;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 5f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        Vector3 sol = transform.position - new Vector3(0, 1.63f);
        Vector3 pieds = transform.position - new Vector3(0, 1.4f);
        Vector3 genoux = transform.position - new Vector3(0, 0.6f);
        Vector3 tete = transform.position + new Vector3(0, 1f);
        Vector3 haut = transform.position + new Vector3(0, 1.5f);

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

        if (hitGenoux.distance > 0.5f || !bGenoux)
        {
            animator.SetBool("Suspendu", false);
        }

        if (hitGround.distance < 1.7f)
        {
            animator.SetBool("Suspendu", false);
            animator.SetBool("Grounded", true);
        }
        else
        {
            animator.SetBool("Grounded", false);
            moveDirection.y -= gravity * Time.deltaTime;
        }


        float step = 0f;
        if (bPieds && (!bGenoux || hitGenoux.distance > hitPieds.distance) && hitPieds.distance < 0.5f)
        {
            step = 0.4f;
            moveDirection.y = 2f;
        }
        animator.SetFloat("Step", step);

        if (bCorps && (!bTete || hitTete.distance > (hitCorps.distance + 1f)) && hitCorps.distance < 0.5f)
        {
            animator.SetBool("Suspendu", true);
            animator.SetBool("Grounded", false);
        }



        if (animator.GetBool("Suspendu"))
        {
            if (hitCorps.distance > 0.5f)
            {
                animator.Play("Grimpe");
                moveDirection += transform.TransformDirection(Vector3.forward);
                if (hitSol.distance < 0.5f)
                {
                    moveDirection.y += 4f;
                }
            }
            else
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection *= speed;
                if (transform.TransformDirection(Vector3.forward) == moveDirection.normalized)
                {
                    animator.Play("Grimpe");
                    moveDirection += transform.TransformDirection(Vector3.forward);
                    if (hitSol.distance < 0.5f)
                    {
                        moveDirection.y += 10f;
                    }
                }
            }
        }


        if (animator.GetBool("Grounded"))
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed * 10 * Time.deltaTime;
                animator.SetBool("Grounded", false);
            }

            float movement = Mathf.Sqrt(Mathf.Pow(moveDirection.x, 2f) + Mathf.Pow(moveDirection.z, 2f));
            animator.SetFloat("Movement", movement);


            if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 225, 0);
            }
            else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 135, 0);
            }
            else if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 315, 0);
            }
            else if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 45, 0);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 270, 0);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 90, 0);
            }
        }

        transform.position = transform.position + (moveDirection * Time.deltaTime);



        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("Block");
        }
    }
}