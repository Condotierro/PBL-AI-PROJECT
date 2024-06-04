using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGame : MonoBehaviour
{
    public GameObject snakeHeadPrefab;
    public GameObject blockPrefab;
    public Transform dropOffArea;
    public float moveSpeed = 3.0f; // Speed of the snake's movement
    public Vector2 playAreaMin = new Vector2(-9, -5); // Minimum boundary of the play area
    public Vector2 playAreaMax = new Vector2(9, 5);   // Maximum boundary of the play area

    private Transform snakeHead;
    private Vector2 direction = Vector2.right;
    private Vector2 nextDirection;
    private GameObject currentBlock;
    private bool hasBlock = false;

    void Start()
    {
        snakeHead = Instantiate(snakeHeadPrefab, Vector2.zero, Quaternion.identity).transform;
        if (snakeHead.GetComponent<Collider2D>() == null)
        {
            snakeHead.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        }
        if (dropOffArea.GetComponent<Collider2D>() == null)
        {
            dropOffArea.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        }
        SpawnBlock();
        StartCoroutine(MoveSnake());
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down)
        {
            nextDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up)
        {
            nextDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right)
        {
            nextDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left)
        {
            nextDirection = Vector2.right;
        }
    }

    IEnumerator MoveSnake()
    {
        while (true)
        {
            direction = nextDirection;

            Vector2 position = snakeHead.position;
            position += direction * moveSpeed * Time.deltaTime;

            if (CheckCollision(position))
            {
                Debug.Log("Game Over");
                // Restart the game or end the game
                yield break;
            }

            snakeHead.position = position;

            yield return null;
        }
    }

    void PickUpBlock()
    {
        hasBlock = true;
        Debug.Log("Picked up block");
        Destroy(currentBlock);
    }

    void DropOffBlock()
    {
        hasBlock = false;
        Debug.Log("Dropped off block");
        SpawnBlock();
    }

    void SpawnBlock()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(playAreaMin.x, playAreaMax.x), Random.Range(playAreaMin.y, playAreaMax.y));
        currentBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
        currentBlock.tag = "Block"; // Ensure the block has the "Block" tag
        if (currentBlock.GetComponent<Collider2D>() == null)
        {
            currentBlock.AddComponent<BoxCollider2D>().isTrigger = true; // Ensure the block has a collider
        }
    }

    bool CheckCollision(Vector2 position)
    {
        // Check if the position is outside the play area boundaries
        if (position.x < playAreaMin.x || position.x > playAreaMax.x || position.y < playAreaMin.y || position.y > playAreaMax.y)
        {
            return true;
        }

        return false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block") && !hasBlock)
        {
            PickUpBlock();
        }
        else if (collision.gameObject.CompareTag("DropOffArea") && hasBlock)
        {
            DropOffBlock();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(playAreaMin.x, playAreaMin.y, 0), new Vector3(playAreaMax.x, playAreaMin.y, 0));
        Gizmos.DrawLine(new Vector3(playAreaMax.x, playAreaMin.y, 0), new Vector3(playAreaMax.x, playAreaMax.y, 0));
        Gizmos.DrawLine(new Vector3(playAreaMax.x, playAreaMax.y, 0), new Vector3(playAreaMin.x, playAreaMax.y, 0));
        Gizmos.DrawLine(new Vector3(playAreaMin.x, playAreaMax.y, 0), new Vector3(playAreaMin.x, playAreaMin.y, 0));
    }
}
