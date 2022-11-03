using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{

    [SerializeField] private Transform player_0;
    private void Start(){
        SpawnCharacter(true);
        SpawnCharacter(false);
        
    }
    private void SpawnCharacter(bool isPlayerTeam){
        Vector3 position;
        if (isPlayerTeam){
            position = new Vector3(-50,0);
        } else{
            position = new Vector3(+50,0);
        }
        Instantiate(player_0, position, Quaternion.identity);
    }
}
