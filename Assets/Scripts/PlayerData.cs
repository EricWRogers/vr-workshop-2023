using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float time = 10;
    public float hydration = 11;
    public float energy = 12;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);


    }

    public void LoadPlayer()
    {
        SaveData data = SaveSystem.LoadPlayer();

        hydration = data.hydration;
        energy = data.energy;
        time = data.time;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;




    }
}
