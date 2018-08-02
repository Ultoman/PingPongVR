using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour {
    
    private SteamVR_TrackedController controller;
    public GameObject ballPrefab;
    public Transform ballSpawnLocation;


	// Use this for initialization
	void Start () {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += spawnBall;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnBall(object sender, ClickedEventArgs e)
    {
        GameObject.Instantiate(ballPrefab, ballSpawnLocation);
    }
}
