using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{/*
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
    }*/
public Transform target; // Transform do personagem
public float smoothing = 5f; // Suavidade do movimento da câmera
public float minX = -10f; // Limite mínimo da coordenada x da câmera
public float maxX = 10f; // Limite máximo da coordenada x da câmera
public float minY = -10f; // Limite mínimo da coordenada y da câmera
public float maxY = 10f; // Limite máximo da coordenada y da câmera

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

    // Limitar a posição da câmera aos limites definidos
    targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
    targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

    // Interpolar suavemente entre a posição atual da câmera e a nova posição
    transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
}

 
}
