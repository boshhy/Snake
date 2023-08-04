using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class VersusSnakeControllerPlayerOne : MonoBehaviour
{
    private Rigidbody2D rBody2D;
    private PlayerControls playerControls;
    private Vector2 snakeMovement = Vector2.down;
    private Vector2 lastDirection;
    private Vector2 startingLocation = new Vector2(-20, 0);
    private List<Transform> snakeBody = new List<Transform>();
    public Transform bodySegment;
    public static event Action onDeath;
    private int currentSnakeFrame = 0;
    public int snakeFrameSpeed = 10;
    public int snakeSpeedNormal = 10;
    public int snakeSpeedFast = 10;
    public int numberOfSegments = 3;

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
        if (currentSnakeFrame >= snakeFrameSpeed)
        {
            currentSnakeFrame = 0;
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
        else
        {
            currentSnakeFrame++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Versus Food")
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

        for (int i = 1; i < numberOfSegments; i++)
        {   
            Transform tempBodySegment = Instantiate(bodySegment);
            tempBodySegment.position = startingLocation;
            snakeBody.Add(tempBodySegment);
        }

        //snakeMovement = Vector2.down;
        currentSnakeFrame = snakeFrameSpeed;
        gameObject.transform.position = startingLocation;
    }

    // private void OtherSnakeDied()
    // {
    //     for (int i = 1; i < snakeBody.Count; i++)
    //     {
    //         Destroy(snakeBody[i].gameObject);
    //     }

    //     snakeBody.Clear();
    //     snakeBody.Add(gameObject.transform);

    //     for (int i = 1; i < numberOfSegments; i++)
    //     {   
    //         Transform tempBodySegment = Instantiate(bodySegment);
    //         tempBodySegment.position = startingLocation;
    //         snakeBody.Add(tempBodySegment);
    //     }

    //     //snakeMovement = Vector2.down;
    //     currentSnakeFrame = snakeFrameSpeed;
    //     gameObject.transform.position = startingLocation;
    // }
    
    private void SpeedUp(InputAction.CallbackContext cntx)
    {
        if (!PauseMenu.isPaused)
        {
            
            //bgm.pitch = 1.2f;
            //Time.timeScale = 3.0f;
            snakeFrameSpeed = snakeSpeedFast;
        }
    }

    private void BackToNormalSpeed(InputAction.CallbackContext cntx)
    {
        if (!PauseMenu.isPaused)
        {
            //bgm.pitch = 1.0f;
            //Time.timeScale = 1.0f;
            snakeFrameSpeed = snakeSpeedNormal;
        }
    }

    private void OnEnable()
    {
        playerControls.SnakePlayerOne.Enable();
        playerControls.SnakePlayerOne.Movement.performed += MoveSnake;
        playerControls.SnakePlayerOne.Faster.performed += SpeedUp;
        playerControls.SnakePlayerOne.Faster.canceled += BackToNormalSpeed;

        // SnakeControllerPlayerTwo.onDeath += OtherSnakeDied;
    }

    private void  OnDisable()
    {
        playerControls.SnakePlayerOne.Disable();
        playerControls.SnakePlayerOne.Movement.performed -= MoveSnake;
        playerControls.SnakePlayerOne.Faster.performed -= SpeedUp;
        playerControls.SnakePlayerOne.Faster.canceled -= BackToNormalSpeed;

        // SnakeControllerPlayerTwo.onDeath -= OtherSnakeDied;
    }

    public bool DoesItOverlap(Vector3 foodPosition)
    {
        //Debug.Log("Checking for overlappingon snake one");
        for (int i = 0; i <= snakeBody.Count - 1; i++)
        {
            
            if (snakeBody[i].position == foodPosition)
            {
                Debug.Log("OVERLAP OCCURED!!!!!!!!!!!!!!!!!!!!!!! Chaning food to new location");
                return true;
            } 
        }
        return false;
    }
}