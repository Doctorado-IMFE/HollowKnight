using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float smoothSpeed = 0.125f; // Velocidad suave de movimiento de la cámara
    public Vector3 offset; // Offset para la posición de la cámara respecto al jugador

    private Vector3 desiredPosition; // Posición deseada para la cámara

    void LateUpdate()
    {
        // Calcular la posición deseada para la cámara
        desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
