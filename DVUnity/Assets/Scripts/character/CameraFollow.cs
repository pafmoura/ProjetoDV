using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform target; // Transform do personagem
    public float smoothing = 5f; // Suavidade do movimento da câmera

    private Vector3 offset; // Distância entre a câmera e o personagem no início do jogo

    private void Start()
    {
        // Calcular a distância entre a câmera e o personagem no início do jogo
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        // Calcular a nova posição da câmera
        Vector3 targetPosition = target.position + offset;

        // Interpolar suavemente entre a posição atual da câmera e a nova posição
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
