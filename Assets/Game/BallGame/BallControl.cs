using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 5f;
    int x = 0;
    int y = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        /*Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;
        Vector3 direction = (mouseWorldPosition - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;*/
    }

    public void SetVisual()
    {
        Vector3 v = new Vector3();
        v.z = 0;
        v.x = x + 0.5f;
        v.y = y + 0.5f;
        transform.position = v;
    }

    public void MoveLeft()
    {
        x--;
        SetVisual();
    }

    public void MoveRight()
    {
        x++;
        SetVisual();
    }

    public void MoveUp()
    {
        y++;
        SetVisual();
    }

    public void MoveDown()
    {
        y--;
        SetVisual();
    }
}
