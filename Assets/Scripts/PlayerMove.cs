using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 2.0f;
    Vector2 position;

    void Start()
    {
        Vector2 position = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    void Update()
    {
        var moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 0) * moveSpeed;
        transform.position += moveVec * moveSpeed * Time.deltaTime;
    }


}