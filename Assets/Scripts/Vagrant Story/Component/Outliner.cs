using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VagrantStory.Component
{

    public class Outliner : MonoBehaviour
    {
        private Outline _outline;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseOver()
        {
            if (_outline == null)
            {
                Renderer rend = GetComponentInChildren<Renderer>();
                _outline = rend.gameObject.AddComponent<Outline>();
                GameObject player = GameObject.FindWithTag("Player");
                AshleyController controller = player.GetComponent<AshleyController>();
                controller.target = rend.gameObject;
            }
        }

        void OnMouseExit()
        {

            if (_outline != null)
            {
                GameObject player = GameObject.FindWithTag("Player");
                AshleyController controller = player.GetComponent<AshleyController>();
                controller.target = null;

                Destroy(_outline);
                _outline = null;
            }
        }
    }

}