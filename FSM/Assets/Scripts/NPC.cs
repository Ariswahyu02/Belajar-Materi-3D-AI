using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float speed; 
   private enum EnemyState{
        Idle,
        Chasing
   }

   private Rigidbody2D rb;
   private EnemyState enemyState;
   private GameObject player;
   private SpriteRenderer spriteRenderer;

   private void Awake() {
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void Start() {
    
   }
   private void FixedUpdate() {
      switch(enemyState)
        {
            case EnemyState.Idle:
                rb.velocity = Vector2.zero;
                spriteRenderer.color = Color.white;
                break;
            case EnemyState.Chasing:
                spriteRenderer.color = Color.green;
                rb.velocity = (player.transform.position - this.transform.position).normalized * speed;
                break;
        }
   }

   private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.GetComponent<Player>())
    {
        
        enemyState = EnemyState.Chasing;
        player = other.gameObject;
    }
   }

   private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.GetComponent<Player>())
        {
            enemyState = EnemyState.Idle;
        }
   }

   

}

