using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 1.0f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float forwardInput = Input.GetAxis("Vertical");
				playerRb.AddForce(Vector3.forward * speed * forwardInput);
    }

}
