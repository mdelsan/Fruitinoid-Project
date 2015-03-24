using UnityEngine;
using System.Collections;

public class DestroyShots : MonoBehaviour
{
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}