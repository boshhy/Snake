using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeController : MonoBehaviour
{
    private Rigidbody2D rBody2D;
    private PlayerControls playerControls;
    private Vector2 snakeMovement = Vector2.down;
    private Vector2 lastDirection;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();

        playerControls.Snake.Enable();
        playerControls.Snake.Movement.performed += MoveSnake;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //playerControls.Snake.Movement.ReadValue<Vector2>();
    }

    void MoveSnake(InputAction.CallbackContext cntx)
    {
        Vector2 inputVector = cntx.ReadValue<Vector2>();

        if (inputVector == Vector2.up && lastDirection != Vector2.down)
        {
            snakeMovement = Vector2.up;
        }

        if (inputVector == Vector2.down && lastDirection != Vector2.up)
        {
            snakeMovement = Vector2.down;
        }

        if (inputVector == Vector2.left && lastDirection != Vector2.right)
        {
            snakeMovement = Vector2.left;
        }

        if (inputVector == Vector2.right && lastDirection != Vector2.left)
        {
            snakeMovement = Vector2.right;
        }
    }

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(
                    Mathf.Round(gameObject.transform.position.x + snakeMovement.x), 
                    Mathf.Round(gameObject.transform.position.y + snakeMovement.y)
        );
        lastDirection = snakeMovement;
        // Vector3 oldLocation = gameObject.transform.position;
        // oldLocation.x += 1;
        // this.transform.position = new Vector3(oldLocation.x, oldLocation.y, oldLocation.z);
    }
}
