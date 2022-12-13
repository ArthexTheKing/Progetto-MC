using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnTime;
    private float respawnTimeStart;
    private bool respawn;

    public void Update()
    {
        CheckRespawn();
    }

    public void Respawn()
    { 
        respawnTimeStart = Time.time;
        respawn = true;
    }

    public void CheckRespawn()
    {
        if(Time.time >= respawnTimeStart + respawnTime)
        {
            Instantiate(player, respawnPoint);
        }
    }

}
