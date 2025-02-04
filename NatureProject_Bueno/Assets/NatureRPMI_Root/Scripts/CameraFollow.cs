using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;           // Referencia al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el movimiento de la cámara

    // Límites para el movimiento de la cámara en el eje X
    public float minX = -10f;  // Límite mínimo en X
    public float maxX = 10f;   // Límite máximo en X

    void LateUpdate()
    {
        // La posición deseada de la cámara será la posición del jugador en los ejes X y Z
        Vector3 desiredPosition = player.position;

        // Mantener la posición de la cámara en Y constante (no moverla hacia arriba o abajo)
        desiredPosition.y = transform.position.y;

        // Asegurarse de que la posición Z se mantenga constante, para evitar que se aleje del jugador
        desiredPosition.z = -10f; // Este es un valor común para juegos 2D

        // Restringir la posición en X dentro de los límites
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

        // Suavizar el movimiento de la cámara para que siga al jugador sin saltos
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Aplicar la nueva posición a la cámara
        transform.position = smoothedPosition;
    }
}
