using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    GameObject player;
    private Vector3 offset;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
