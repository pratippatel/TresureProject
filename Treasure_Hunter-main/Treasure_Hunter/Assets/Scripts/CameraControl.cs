using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distAhead;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead,
                                transform.position.y,
                                transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, distAhead * player.localScale.x,
                              Time.deltaTime * cameraSpeed);
    }


}
