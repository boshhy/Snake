using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class SnakeController : MonoBehaviour
{
    private Rigidbody2D rBody2D;
    private PlayerControls playerControls;
    private Vector2 snakeMovement = Vector2.down;
    private Vector2 lastDirection;
    private List<Transform> snakeBody = new List<Transform>();
    public Transform bodySegment;
    public static event Action onDeath;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {

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

    private void FixedUpdate()
    {
        Vector2 frontTransform = gameObject.transform.position;
        Vector2 tempTransform = gameObject.transform.position;

        gameObject.transform.position = new Vector2(
                    Mathf.Round(gameObject.transform.position.x + snakeMovement.x), 
                    Mathf.Round(gameObject.transform.position.y + snakeMovement.y)
        );

        for (int i = 1; i <= snakeBody.Count - 1; i++)
        {
            tempTransform = snakeBody[i].position;
            snakeBody[i].position = frontTransform;
            frontTransform = tempTransform;
        }

        lastDirection = snakeMovement;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }

        if (other.tag == "Wall" || other.tag == "Body")
        {
            ResetGame();
        }
    }

    private void Grow()
    {
        Transform newBodySegment = Instantiate(bodySegment);
        newBodySegment.position = snakeBody[snakeBody.Count - 1].position;

        snakeBody.Add(newBodySegment);

    }

    private void ResetGame()
    {
        if (onDeath != null)
        {
            onDeath();
        }
        
        for (int i = 1; i < snakeBody.Count; i++)
        {
            Destroy(snakeBody[i].gameObject);
        }

        snakeBody.Clear();
        snakeBody.Add(gameObject.transform);

        for (int i = 1; i < 3; i++)
        {
            snakeBody.Add(Instantiate(bodySegment));
        }

        gameObject.transform.position = Vector2.zero;
    }

    private void SpeedUp(InputAction.CallbackContext cntx)
    {
        Time.timeScale = 3.0f;
    }

    private void BackToNormalSpeed(InputAction.CallbackContext cntx)
    {
        Time.timeScale = 1.0f;
    }

    private void OnEnable()
    {
        playerControls.Snake.Enable();
        playerControls.Snake.Movement.performed += MoveSnake;
        playerControls.Snake.Faster.performed += SpeedUp;
        playerControls.Snake.Faster.canceled += BackToNormalSpeed;
    }

    private void  OnDisable()
    {
        playerControls.Snake.Disable();
        playerControls.Snake.Movement.performed -= MoveSnake;
        playerControls.Snake.Faster.performed -= SpeedUp;
        playerControls.Snake.Faster.canceled -= BackToNormalSpeed;
    }
}
