using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    Vector2 mouseVector;
    Vector2 lastMouseVector;
    float xClampled = 0;
    float yClampled = 0;
    void Update()
    {
        mouseVector = Input.mousePosition;
        if (Input.GetMouseButton(1) == true)
        {
            // Se crea un vector dirección, que es la diferencia entre la posición original del ratón y la actual
            Vector2 directionVector = (mouseVector - lastMouseVector);
            // Luego se crea el vector de rotación, que será el vector dirección multiplicado por la velocidad
            Vector2 movementDeltaMouse = new Vector2(directionVector.y, -directionVector.x) * speed * Time.deltaTime;
            transform.Rotate(movementDeltaMouse);
            // Clampeo de los valores de X
            if (transform.eulerAngles.x <= 1 || transform.eulerAngles.x >= 359) {
                xClampled = transform.eulerAngles.x;
            }
            else if (transform.eulerAngles.x >= 1 && transform.eulerAngles.x < 2)
            {
                xClampled = 1;
            }
            else if (transform.eulerAngles.x < 359)
            {
                xClampled = -1;
            }
            // Clampeo de los valores de Y
            if (transform.eulerAngles.y <= 1 || transform.eulerAngles.y >= 359)
            {
                yClampled = transform.eulerAngles.y;
            }
            else if (transform.eulerAngles.y >= 1 && transform.eulerAngles.y < 2)
            {
                yClampled = 1;
            }
            else if (transform.eulerAngles.y < 359)
            {
                yClampled = -1;
            }
        }
        transform.rotation = Quaternion.Euler(xClampled, yClampled, 0);
        lastMouseVector = mouseVector;
    }
}
