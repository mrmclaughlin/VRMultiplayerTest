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
		
	
	 
	 
   }
   
    public override void OnLeftRoom(){
	base.OnLeftRoom();
	PhotonNetwork.Destroy(spawnedPlayerPrefab);
	
	
		 
		PhotonNetwork.Destroy(spawnedSnowballPrefab);
		 
	}
	
	
	
	
	
   }
   

