using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float speed = 3f;
  private Rigidbody enemyRb;
  private GameObject player;
  void Start()
  {
    enemyRb = GetComponent<Rigidbody>();
    player = GameObject.Find("Player");
  }

  void Update()
  {
    EnemyMovement();
  }

  private void EnemyMovement()
  {
    Vector3 direction = (player.transform.position - transform.position).normalized;
    enemyRb.AddForce(direction * speed);

    if (transform.position.y < -5)
    {
      Destroy(gameObject);
    }
  }
}
