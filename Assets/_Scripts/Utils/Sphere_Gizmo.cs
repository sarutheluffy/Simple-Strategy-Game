using UnityEngine;
using System.Collections;

public class Sphere_Gizmo : MonoBehaviour {

	[Tooltip ("Color of your Gizmo Sphere")]
	public Color color = new Color(0.2f, 0.3f, 1f, 1f);
	
	[SerializeField] private Turret turret;
	void OnDrawGizmos()
	{
		Gizmos.color = this.color;
		Gizmos.DrawSphere(transform.position, turret.DetectionRadius);

	}

	void OnDrawGizmosSelected() {
		Gizmos.color = this.color;
		Gizmos.DrawSphere(transform.position, turret.DetectionRadius);
	}
}
