using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
	public Transform head;
	public Transform leftHand;
	public Transform rightHand;
	private PhotonView photonView;
	private GameObject spawnedSnowballPilePrefab;
	public GameObject snowballPrefab;  // Drag your snowball prefab here
    public int numberOfSnowballs = 50; // Number of snowballs in the pile
    public float areaRadius = 2f;      // Radius of the pile

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
		spawnedSnowballPilePrefab = PhotonNetwork.Instantiate("SnowballPile",transform.position,transform.rotation);
	Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
       
    
        for (int i = 0; i < numberOfSnowballs; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-areaRadius, areaRadius),
                Random.Range(0, areaRadius),
                Random.Range(-areaRadius, areaRadius)
            );

            GameObject aSnowball = Instantiate(snowballPrefab, randomPosition + transform.position, Quaternion.identity);
			aSnowball.name = "snowball" + i;

		 Renderer rend = aSnowball.GetComponent<Renderer>();
        // Change the material color to red
		 rend.material.color = randomColor;
			aSnowball.transform.SetParent(spawnedSnowballPilePrefab.transform);
        }
			
    }

    // Update is called once per frame
    void Update()
    {
		if (photonView.IsMine)
		{
			rightHand.gameObject.SetActive(false);
			leftHand.gameObject.SetActive(false);
			head.gameObject.SetActive(false);
			MapPosition(head, XRNode.Head);
			MapPosition(leftHand,XRNode.LeftHand);
			MapPosition(rightHand,XRNode.RightHand);
			GameObject NetworkPlayer = photonView.gameObject;
			NetworkPlayer.name = "NetworkPlayer" + photonView.ViewID;
			spawnedSnowballPilePrefab.name ="SnowBallPile" + photonView.ViewID;
			spawnedSnowballPilePrefab.transform.SetParent(NetworkPlayer.transform);
    
		}
        
    }
	void MapPosition(Transform target,XRNode node)
	{
		InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
		InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
		target.position = position;
		target.rotation = rotation;
	}
}
