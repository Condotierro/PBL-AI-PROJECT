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
        if (Input.GetKeyDown(KeyCode.W) && y < 2)
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S) && y > -3)
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.A) && x > -3)
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) && x < 2)
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
        Debug.Log(x + ":" + y);
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
