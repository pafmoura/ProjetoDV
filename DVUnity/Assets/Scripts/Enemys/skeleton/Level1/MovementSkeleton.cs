using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSkeleton : MonoBehaviour
{

 public float speed = 2f; // velocidade do personagem
public float distance = 5f; // distância que o personagem se move
private float startingX; // posição inicial do personagem
private float direction = 1f; // direção do movimento do personagem
private SpriteRenderer spriteRenderer; // componente SpriteRenderer do personagem

private bool isPlayerNeer;

void Start()
{
    startingX = transform.position.x; // define a posição inicial do personagem
    spriteRenderer = GetComponent<SpriteRenderer>(); // obtém o componente SpriteRenderer do personagem
    isPlayerNeer= false;
}

void Update()
{

    if(!isPlayerNeer){
        // move o personagem
        transform.Translate(new Vector2(speed * direction * Time.deltaTime, 0));

        // verifica se o personagem atingiu a distância máxima
        if (Mathf.Abs(transform.position.x - startingX) > distance)
        {
            // muda a direção do movimento
            direction *= -1f;

            // inverte a imagem horizontalmente ao mudar de direção
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}


    public void playerIsNeer(){
        isPlayerNeer= true;
    } 
    public void playerIsNotNeer(){
        isPlayerNeer= false;
    }


void OnTriggerEnter2D(Collider2D other)
{
    // verifica se o personagem colidiu com um objeto com a tag "ground"
    if (other.gameObject.CompareTag("Ground"))
    {
        // muda a direção do movimento
        direction *= -1f;

        // inverte a imagem horizontalmente ao mudar de direção
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
    
}
