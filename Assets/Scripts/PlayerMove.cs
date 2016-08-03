using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 2.0f;
    Vector2 position;
    private float width;
    private float height;
    private Camera cam;
    private float biasLimitWidth = 0.3f;
    private float biasLimitHeight = 0.3f;
    private Vector2 camSize;
    public float health = 500;

    void Start()
    {
        cam = Camera.main;
        camSize = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight));
    }

    void Update()
    {
        // X axis
        if (transform.position.x < biasLimitWidth)
        {
            transform.position = new Vector2(biasLimitWidth, transform.position.y);
        }
        else if (transform.position.x > (camSize.x - biasLimitWidth))
        {
            transform.position = new Vector2(camSize.x - biasLimitWidth, transform.position.y);
        }

        // Y axis
        if (transform.position.y < biasLimitHeight)
        {
            transform.position = new Vector2(transform.position.x, biasLimitHeight);
        }
        else if (transform.position.y >= (camSize.y - biasLimitHeight))
        {
            transform.position = new Vector2(transform.position.x, camSize.y - biasLimitHeight);
        }
        else
        {
            var moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 0) * moveSpeed;
            transform.position += moveVec * moveSpeed * Time.deltaTime;
        }
    }


}