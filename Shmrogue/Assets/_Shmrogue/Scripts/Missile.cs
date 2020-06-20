///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 20/06/2020 11:40
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.MaxmilienGalea.Shmrogue {
	public class Missile : MonoBehaviour {
		[SerializeField] float speed = 0;
		[SerializeField] float lifeTime = 0;

		private void Start () {
			Destroy(gameObject, lifeTime);
			transform.rotation = Quaternion.LookRotation(new Vector3(transform.forward.x, 0, transform.forward.z), Vector3.up);
		}
		
		private void Update () {
			transform.position += transform.forward * speed * Time.deltaTime;
			
		}
	}
}