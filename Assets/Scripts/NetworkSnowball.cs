using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkSnowball : MonoBehaviour
{
 
	public Transform Snowball;
	private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView  = GetComponent<PhotonView>();
		
		
		if (photonView.IsMine)
		{
				GameObject[] clones = GameObject.FindGameObjectsWithTag("snowball");
		GetClones(clones);
		 
		}
	
    }

    // Update is called once per frame
    void Update()
    {int i= 0;
		if (photonView.IsMine)
		{
			Snowball.gameObject.SetActive(true);
			//MapsnowballPosition(Snowball,XRNode.RightHand);
		 
		}
		 
		
        
    }
	void MapsnowballPosition(Transform target,XRNode node)
	{
		InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
		InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
		//target.position = target.position + new Vector3(0, 1, 0);
		//target.rotation = rotation;
	}
	
	void GetClones(GameObject[] clones)
    {
		int i = 0;
        foreach (GameObject child in clones)
        {
            child.transform.localPosition += new Vector3(0, i, 0);
			 i++;
        }
    }
}
