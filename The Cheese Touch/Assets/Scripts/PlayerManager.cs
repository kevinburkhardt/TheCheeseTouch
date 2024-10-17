using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;
    public float jumpPower;

    private Vector3 moveDirection;
    private SpriteRenderer mySpriteRenderer;

    private float topYValue = -0.25f;
    private float botYValue = -6.9f;


    // Update is called once per frame
    void Update()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        HandleMovement();
    }

    public void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, moveY, 0).normalized;

        transform.position += moveDirection * (speed * 2) * Time.deltaTime;

        float clampedY = Mathf.Clamp(transform.position.y, botYValue, topYValue);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        if (moveX < 0)
        {
            mySpriteRenderer.flipX = true;
        } else if (moveX > 0)
        {
            mySpriteRenderer.flipX = false;
        }
    }

    public Vector3 GetPlayerLocation()
    {
        return transform.position;
    }
}
