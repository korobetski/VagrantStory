using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position = player.transform.position;
        // Zoom
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * 4f;
        fov = Mathf.Clamp(fov, 20, 55);
        Camera.main.fieldOfView = fov;



        if (Input.GetButtonDown("Rotate"))
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 15, 0);
        }
    }
}
