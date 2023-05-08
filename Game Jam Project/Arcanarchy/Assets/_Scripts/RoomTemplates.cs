using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedEnd = false;
    private bool spawnedMid = false;
    public GameObject end;
    public GameObject mid;

    void update()
    {
        if(waitTime <= 0 && !spawnedEnd)
        {
            for(int i = 0;i < rooms.Count;i++)
            {
                if(i == Mathf.Round(rooms.Count/2) && !spawnedMid)
                {
                    Instantiate(mid, rooms[i].transform.position, Quaternion.identity);
                    spawnedMid = true;
                }
                if (i == rooms.Count-1)
                {
                    Instantiate(mid, rooms[i].transform.position, Quaternion.identity);
                    spawnedEnd = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
