using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int time;
    public float hydration;
    public float energy;
    public float[] position;

    //public GameObject player; Might use this idk

    public SaveData(PlayerData player/* Insert save data*/)
    {
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        hydration = player.hydration;
        energy = player.energy;
        time = player.time;
    }
}
