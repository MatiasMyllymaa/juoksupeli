using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float positionX = 0;
    float lastPositionX = 0;
    float speedX = 12f;
    float jumpHeight = 2f;
    float jumpDestinationHeight;
    bool jumping = false;
    bool descending = false;
    bool grounded = true;
    bool invincible = false;
    float damageCooldown = 0.1f;
    int health = 2;
    bool dead = false;
    float jumpForce = 3f;
    float jumpSpeed = 15;
    Rigidbody playerRb;
    [SerializeField] LayerMask groundLayer;
    CapsuleCollider playerCollider;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        //x inputs
        if (positionX > -2 && Input.GetKeyDown(KeyCode.A))
        {
            lastPositionX = positionX;
            //go left
            positionX -= 2f;
        }

        if (positionX < 2 && Input.GetKeyDown(KeyCode.D))
        {
            lastPositionX = positionX;
            //go right
            positionX += 2f;
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);

            jumpDestinationHeight = transform.position.y + jumpHeight;
            jumping = true;
        }
        if (jumping && transform.position.y < jumpDestinationHeight - (0.5f))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, jumpDestinationHeight, transform.position.z), jumpSpeed * Time.deltaTime);
        }
        else
        {
            jumping = false;
        }

        if (!dead)
        {
            //movement x
            transform.position = Vector3.Lerp(transform.position, new Vector3(positionX, transform.position.y, transform.position.z), speedX * Time.deltaTime);
        }
        if (grounded)
        {
            // Check if "S" is pressed
            if (Input.GetKeyDown(KeyCode.S))
            {
                // Start coroutine to temporarily change collider height
                StartCoroutine(ShortenColliderForDuration(1.0f));
            }
        }

        //ground check
        RaycastHit groundHit;
        if (Physics.Raycast(transform.position, Vector3.down, out groundHit, 1f, groundLayer))
        {
            grounded = true;
            descending = false;
        }
        else
        {
            grounded = false;
            //go down
            if (!descending && Input.GetKeyDown(KeyCode.S))
            {
                jumping = false;
                descending = true;
                playerRb.velocity = new Vector3(playerRb.velocity.x, -15f, playerRb.velocity.z);
            }
            
            //fall faster
            if (!descending && playerRb.velocity.y < 0)
            {
                playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y -0.5f, playerRb.velocity.z);
            }
        }
    }
    IEnumerator ShortenColliderForDuration(float duration)
    {
        // Store the original collider height
        float originalHeight = playerCollider.height;

        // Set the new height (adjust this value according to your needs)
        playerCollider.height = 0.5f;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Restore the original collider height
        playerCollider.height = originalHeight;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!invincible && collision.transform.tag == "Obstacle")
        {
            health -= 1;
            Debug.Log(health);
            jumping = false;
            descending = false;

            if ((transform.position.x < 0 && transform.position.x > (-3f + 0.05f)) && lastPositionX == 0 && positionX == -3)
            {
                Debug.Log("middle to left");
                positionX = lastPositionX;
            }
            if ((transform.position.x > 0 && transform.position.x < (3f - 0.05f)) && lastPositionX == 0 && positionX == 3)
            {
                Debug.Log("middle to right");
                positionX = lastPositionX;
            }
            if ((transform.position.x < 3 && transform.position.x > (0f + 0.05f)) && lastPositionX == 3 && positionX == 0)
            {
                Debug.Log("right to middle");
                positionX = lastPositionX;
            }
            if ((transform.position.x > -3 && transform.position.x < (0f - 0.05f)) && lastPositionX == -3 && positionX == 0)
            {
                Debug.Log("left to middle");
                positionX = lastPositionX;
            }

            //StartCoroutine("DamageCooldown");
        }
    }

    IEnumerator DamageCooldown()
    {
        invincible = true;
        yield return new WaitForSecondsRealtime(damageCooldown); 
        invincible = false;
    }
}
