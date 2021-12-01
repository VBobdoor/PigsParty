using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody2D;

    private float speed = 150;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalDeltaDirection, float verticalDeltaDirection)
    {
        if (horizontalDeltaDirection != 0 || verticalDeltaDirection != 0)
            playerRigidbody2D.velocity = new Vector2(horizontalDeltaDirection, verticalDeltaDirection) * speed;
        else
            playerRigidbody2D.velocity = Vector2.zero;
    }
    

}
