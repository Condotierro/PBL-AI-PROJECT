using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private bool isCarryingCoin = false;
    private GameObject currentData;
    public Transform dropOffPoint;
    public Vector2 movementBoundsMin;
    public Vector2 movementBoundsMax;

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        movement.x = 0;
        movement.y = 0;

        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
        }
    }

    void Move()
    {
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, movementBoundsMin.x, movementBoundsMax.x);
        newPosition.y = Mathf.Clamp(newPosition.y, movementBoundsMin.y, movementBoundsMax.y);
        rb.MovePosition(newPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Data") && !isCarryingCoin)
        {
            isCarryingCoin = true;
            Destroy(collision.gameObject);
            GameManager.instance.PlaySound(GameManager.instance.collectSound);
        }
        else if (collision.CompareTag("DropOff") && isCarryingCoin)
        {
            DropData();
            GameManager.instance.PlaySound(GameManager.instance.depositSound);
        }
    }

    void DropData()
    {
        isCarryingCoin = false;
        GameManager.instance.CollectData();
        GameManager.instance.SpawnNewData();
    }
}
