using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {   
        // Set camera offset position immediately when the game start

        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        // Set camera position every frame

        transform.position = player.transform.position + offset;
    }
}
