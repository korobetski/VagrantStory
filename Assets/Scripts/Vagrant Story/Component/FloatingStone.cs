using UnityEngine;

namespace VagrantStory.Component
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class FloatingStone : MonoBehaviour
    {
        public Vector3 startingPosition;
        public Vector3 destination;
        public float speed = 0.01f;
        public float delay = 10f;

        public bool moving = false;
        private bool fromStart = true;

        private BoxCollider _collider;
        GameObject onGo;

        // Start is called before the first frame update
        void Start()
        {
            _collider = GetComponent<BoxCollider>();
            startingPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (onGo != null)
            {
                onGo.GetComponent<Rigidbody>().AddForce(Vector3.down * 10, ForceMode.Acceleration);
            }

            if (!moving)
            {
                if (delay < 0f)
                {
                    moving = true;
                    delay = 10f;
                }
                else
                {
                    delay -= 0.1f;
                }
            }
            else
            {
                if (fromStart)
                {
                    transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
                    if (onGo != null)
                    {
                        onGo.transform.position = Vector3.Lerp(onGo.transform.position, destination + new Vector3(0, 1.45f, 0), speed * Time.deltaTime);
                        onGo.GetComponent<Rigidbody>().AddForce(Vector3.down, ForceMode.Acceleration);
                    }

                    if (Vector3.Distance(transform.position, destination) < 0.1f)
                    {
                        moving = false;
                        fromStart = false;
                    }
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, startingPosition, speed * Time.deltaTime);
                    if (onGo != null)
                    {
                        onGo.transform.position = Vector3.Lerp(onGo.transform.position, startingPosition + new Vector3(0, 1.45f, 0), speed * Time.deltaTime);
                        onGo.GetComponent<Rigidbody>().AddForce(Vector3.down, ForceMode.Acceleration);
                    }

                    if (Vector3.Distance(transform.position, startingPosition) < 0.1f)
                    {
                        moving = false;
                        fromStart = true;
                    }
                }
            }
        }

        void OnCollisionStay(Collision collision)
        {
            ContactPoint contact = collision.contacts[0];
            if (collision.collider.gameObject == GameObject.FindWithTag("Player"))
            {
                onGo = GameObject.FindWithTag("Player");
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            ContactPoint contact = collision.contacts[0];
            if (collision.collider.gameObject == GameObject.FindWithTag("Player"))
            {
                onGo = GameObject.FindWithTag("Player");
            }
        }
        void OnCollisionExit(Collision collision)
        {
            if (collision.collider.gameObject == onGo)
            {
                onGo = null;
            }
        }
    }

}
