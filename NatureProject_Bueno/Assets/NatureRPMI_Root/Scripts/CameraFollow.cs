using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;           // Referencia al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el movimiento de la c�mara

    // L�mites para el movimiento de la c�mara en el eje X
    public float minX = -10f;  // L�mite m�nimo en X
    public float maxX = 10f;   // L�mite m�ximo en X

    void LateUpdate()
    {
        // La posici�n deseada de la c�mara ser� la posici�n del jugador en los ejes X y Z
        Vector3 desiredPosition = player.position;

        // Mantener la posici�n de la c�mara en Y constante (no moverla hacia arriba o abajo)
        desiredPosition.y = transform.position.y;

        // Asegurarse de que la posici�n Z se mantenga constante, para evitar que se aleje del jugador
        desiredPosition.z = -10f; // Este es un valor com�n para juegos 2D

        // Restringir la posici�n en X dentro de los l�mites
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

        // Suavizar el movimiento de la c�mara para que siga al jugador sin saltos
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Aplicar la nueva posici�n a la c�mara
        transform.position = smoothedPosition;
    }
}
