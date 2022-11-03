using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    Animator animator;

    public float Health {
        set {
            health = value;

            if(health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 1;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
        ScoreScript.scoreValue += 10;
    }

    public void RemoveEnemy() {
        GameObject.Find(gameObject.name + ("spawn point")).GetComponent<Enemyrespawn>().Death = true;
        Destroy(gameObject);
        
    }
   
}
