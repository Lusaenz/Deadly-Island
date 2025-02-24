using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class GameManager : MonoBehaviour
{
  [SerializeField] bool isPaused, didLose;
  public static GameManager Instance { get; private set; }
  public GameObject player;
  private float fallLimit = -5.0f; // Límite de caída

  void Update()
  {
    if (SceneManager.GetActiveScene().name != "Menu") // Evita ejecutar en el menú
    {
      CheckPlayerFall();
    }
  }
  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(this.gameObject); //no se destruye al cambiar de escena.

    }
    else
    {
      Destroy(this.gameObject);
    }
  }

  private void CheckPlayerFall()

  {
    if (player == null) return;
    if (player.transform.position.y < fallLimit)
    {
      Debug.Log("El jugador ha caído. Fin del juego.");
      GameOver();
    }
  }
  // Metodo para pausar el juego 
  public void PauseGame()
  {
    isPaused = !isPaused;
    if (isPaused)
    {
      Time.timeScale = 0;
    }
    else
    {
      Time.timeScale = 1;
    }
  }

  private void GameOver()
  {
    // Cambia a la escena del menú 
    Debug.Log("Cargando menú...");
    player = null; // Evita que siga intentando acceder a un objeto destruido
    SceneManager.LoadScene("Menu");
  }
  public void LoadGameScene()
  {
    SceneManager.LoadScene("Deadly Island");
  }
}
