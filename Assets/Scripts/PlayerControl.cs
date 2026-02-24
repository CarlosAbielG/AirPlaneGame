using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float movSpeed = 8f;

    float speedX, speedY;
    Rigidbody2D rb;

    [SerializeField] private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (sprite == null) sprite = GetComponent<SpriteRenderer>();
        if (sprite == null) sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) input.x = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) input.x = 1;

            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) input.y = 1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) input.y = -1;
        }

        if (sprite != null)
        {
            if (input.x < 0) sprite.flipX = true;
            else if (input.x > 0) sprite.flipX = false;
        }

        speedX = input.x * movSpeed;
        speedY = input.y * movSpeed;

        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}