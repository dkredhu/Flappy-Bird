using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public float spawnRate = 4f;
    public int columnPoolSize = 5;
    public float columnYMin = -2f;
    public float columnYMax = 2f;

    public float timeSinceLastSpawn;
    private float spawnXpos = 10f;
    private int currentColumn = 0;

    public GameObject columnsPrefab;

    private GameObject[] columns;

    private Vector2 objectPoolPostion = new Vector2(-15, -25f);
	// Use this for initialization
	void Start () {

        columns = new GameObject[columnPoolSize];
        for (int i=0; i < columnPoolSize;i++)
        {
            columns[i] = (GameObject)Instantiate(columnsPrefab, objectPoolPostion, Quaternion.identity);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;
        if(!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate){
            timeSinceLastSpawn = 0;

            float spawnYpos = Random.Range(columnYMin, columnYMax);
            columns[currentColumn].transform.position = new Vector2(spawnXpos, spawnYpos);
            currentColumn++;
            if(currentColumn >= columnPoolSize){
                currentColumn = 0;

            }

        }
	}
}
