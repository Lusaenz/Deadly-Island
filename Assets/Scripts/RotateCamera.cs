using UnityEngine;

public class RotateCamera : MonoBehaviour
{
  public float rotationSpeed;

  void Update()
  {
    RotateCameraInput();
  }
  private void RotateCameraInput()
  {
    float horizontalInput = Input.GetAxis("Horizontal");
    transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
  }
}
