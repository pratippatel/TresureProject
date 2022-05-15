using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distAhead;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float minCameraY, maxCameraY;
    private float lookAhead;
    private float offset;

    void Start()
    {
        offset = transform.position.y - player.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 vel = Vector3.zero;
        if (player.position.y < -9.5)
        {
            SceneManager.LoadScene(1);
        }
        if (player.position.y < -3.7)
        {
            transform.position = new Vector3(player.position.x + lookAhead,
                                minCameraY,
                                transform.position.z);
            /*transform.position = Vector3.SmoothDamp(transform.position, new Vector3(
                                  player.position.x + lookAhead, minCameraY,
                                  transform.position.z), ref vel,
                                  cameraSpeed * Time.deltaTime);*/
        }
        else
        {
            transform.position = new Vector3(player.position.x + lookAhead,
                                maxCameraY,
                                transform.position.z);
            /*transform.position = Vector3.SmoothDamp(transform.position, new Vector3(
                                  player.position.x + lookAhead, maxCameraY,
                                  transform.position.z), ref vel,
                                  cameraSpeed * Time.deltaTime);*/
        }

        lookAhead = Mathf.Lerp(lookAhead, distAhead * player.localScale.x,
                              Time.deltaTime * cameraSpeed);

        /*Vector3 cameraBound = new Vector3(Mathf.Clamp(transform.position.x, minCamera.x, maxCamera.x),
                                          Mathf.Clamp(transform.position.y, minCamera.y, maxCamera.y),
                                          Mathf.Clamp(transform.position.z, minCamera.z, maxCamera.z));*/
    }

}
