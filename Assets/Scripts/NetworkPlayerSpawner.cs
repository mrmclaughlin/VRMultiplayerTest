using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
 
public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
	private GameObject spawnedPlayerPrefab;
	private GameObject spawnedSnowballPrefab;
	 
	GameObject[] mySnowBalls;
   public override void OnJoinedRoom(){
	base.OnJoinedRoom();
	spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player",transform.position,transform.rotation);
	for (int i=0;i<10;i++)
	{
		spawnedSnowballPrefab = PhotonNetwork.Instantiate("Snowball",transform.position,transform.rotation);
		//mySnowBalls[i] = spawnedSnowballPrefab;
	}
	 
	 
   }
   
    public override void OnLeftRoom(){
	base.OnLeftRoom();
	PhotonNetwork.Destroy(spawnedPlayerPrefab);
	
	for (int i=0;i<10;i++)
	{
		 
		PhotonNetwork.Destroy(spawnedPlayerPrefab);
		//PhotonNetwork.Destroy(mySnowBalls[i]);  
	}
	
	
	
	
	
   }
   
}
