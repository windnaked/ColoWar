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
    private float biasLimitHeight = 0.25f;

    void Start()
    {
        cam = Camera.main;
        Vector2 position = new Vector2(this.transform.position.x, this.transform.position.y);
        height = cam.orthographicSize + cam.orthographicSize;
        width = (height * cam.aspect);
    }

    void Update()
    {
        // X axis
        if (transform.position.x < biasLimitWidth)
        {
            transform.position = new Vector2(biasLimitWidth, transform.position.y);
        }
        else if (transform.position.x > (width - biasLimitWidth))
        {
            transform.position = new Vector2(width - biasLimitWidth, transform.position.y);
        }

        // Y axis
        //Ver o que fazer aqui, talvez usar colliders, ou arranjar uma maneira de sacar o tamanho do sprite
        //Isto esta a funcionar mas na heigth consegue-se ver o reset da posicao
        if (transform.position.y < biasLimitHeight)
        {
            transform.position = new Vector2(transform.position.x, biasLimitHeight);
        }
        else if (transform.position.y > (height - biasLimitHeight))
        {
            transform.position = new Vector2(transform.position.x, height - biasLimitHeight);
        }
        else
        {
            var moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 0) * moveSpeed;
            transform.position += moveVec * moveSpeed * Time.deltaTime;
        }
    }


}