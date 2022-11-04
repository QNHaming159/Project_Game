using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    Animator animator_enemy;

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
        ScoreScript.scoreValue = -10;
        animator_enemy = GetComponent<Animator>();
    }

    public void Defeated(){
        animator_enemy.SetTrigger("Defeated");
        ScoreScript.scoreValue += 10;
    }

    /*public void RemoveEnemy() {
        GameObject.Find(gameObject.name + ("spawn point")).GetComponent<Enemyrespawn>().Death = true;
        Destroy(gameObject);
        
    }*/
   
}
