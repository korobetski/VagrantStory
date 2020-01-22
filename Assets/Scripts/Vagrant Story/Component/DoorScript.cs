using UnityEngine;



namespace VagrantStory.Component
{

    public class DoorScript : MonoBehaviour
    {
        public bool openned = false;
        public bool inverse = false;
        public bool locked = false;
        public byte lockId = 0;


        // Start is called before the first frame update
        void Start()
        {
            if (openned)
            {
                if (inverse)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                }
                else
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnValidate()
        {

            if (openned)
            {
                if (inverse)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                }
                else
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
    }

}