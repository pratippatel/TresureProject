using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distAhead;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Vector3 minCamera, maxCamera;
    private float lookAhead;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead,
                                player.position.y + 2.6f,
                                transform.position.z);
        /*transform.position = new Vector3(player.position.x + lookAhead,
                                transform.position.y,
                                transform.position.z);*/

        lookAhead = Mathf.Lerp(lookAhead, distAhead * player.localScale.x,
                              Time.deltaTime * cameraSpeed);

        /*Vector3 cameraBound = new Vector3(Mathf.Clamp(transform.position.x, minCamera.x, maxCamera.x),
                                          Mathf.Clamp(transform.position.y, minCamera.y, maxCamera.y),
                                          Mathf.Clamp(transform.position.z, minCamera.z, maxCamera.z));*/
    }


}
