using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody playerRb;
  private Animator playerAnimator;
  public float speed = 3.0f;
  private GameObject focalPoint;
  public bool hasPowerup;
  private float powerupStrength = 30.0f;
  public GameObject powerupIndicator;
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    playerAnimator = GetComponent<Animator>(); // Obtener el Animator
    focalPoint = GameObject.Find("Focal Point");

    playerRb.freezeRotation = true;
  }

  void Update()
  {
    PlayerMovement();
    powerupIndicator.transform.position = transform.position + new Vector3(0, 1, 0);

  }

  private void PlayerMovement()
  {
    float forwardInput = Input.GetAxis("Vertical");
    float horizontalInput = Input.GetAxis("Horizontal");

    // Verifica si el jugador se está moviendo
    bool isMoving = (forwardInput != 0 || horizontalInput != 0);
    playerAnimator.SetBool("isMoving", isMoving);

    if (isMoving)
    {
      // Dirección de movimiento
      Vector3 moveDirection = new Vector3(horizontalInput, 0, forwardInput).normalized;

      // Aplica el movimiento con velocity (para mayor control)
      playerRb.velocity = moveDirection * speed + new Vector3(0, playerRb.velocity.y, 0);

      // Rota el personaje hacia la dirección de movimiento
      transform.forward = moveDirection;
    }
    else
    {
      // Si no se mueve, frenar el movimiento para evitar deslizamiento
      playerRb.velocity = new Vector3(0, playerRb.velocity.y, 0);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Powerup"))
    {
      hasPowerup = true;
      powerupIndicator.gameObject.SetActive(true);
      Destroy(other.gameObject);
      StartCoroutine(PowerupCountdownRoutine());
    }
  }
  IEnumerator PowerupCountdownRoutine()
  {
    yield return new WaitForSeconds(7);
    hasPowerup = false;
    powerupIndicator.gameObject.SetActive(false);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
    {
      Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
      Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
      awayFromPlayer.Normalize();
      enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
    }
  }
}
