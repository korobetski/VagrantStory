using UnityEngine;
using System.Collections;


namespace VagrantStory.Component
{


    [RequireComponent(typeof(MeshCollider))]
    public class WeaponBehav : MonoBehaviour
    {
        GameObject Target;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter(Collision collision)
        {
            ContactPoint contact = collision.contacts[0];
            if (collision.collider.gameObject == GameObject.FindWithTag("NPC"))
            {
                Target = GameObject.FindWithTag("NPC");
                Debug.Log(Target);
            }
        }
    }

}
