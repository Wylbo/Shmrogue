///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 20/06/2020 11:40
///-----------------------------------------------------------------

using Com.MaxmilienGalea.Shmrogue.Ennemy;
using UnityEngine;

namespace Com.MaxmilienGalea.Shmrogue {
	public class Missile : MonoBehaviour {
		[SerializeField] protected float m_speed = 0;
		[SerializeField] protected float m_lifeTime = 0;
		[SerializeField] protected float m_damage = 0;
		[SerializeField] protected ParticleSystem m_onDieParticle = null;

		private void Start () {
			Destroy(gameObject, m_lifeTime);
			transform.rotation = Quaternion.LookRotation(new Vector3(transform.forward.x, 0, transform.forward.z), Vector3.up);
		}
		
		private void Update () {
			transform.position += transform.forward * m_speed * Time.deltaTime;	
		}

		private void OnCollisionEnter(Collision collision) {
			Debug.Log("[Missile] hit!!!");

			if (collision.collider.GetComponent<AEnemy>()) {
				Die();
				collision.collider.GetComponent<AEnemy>().TakeDamage(m_damage);
			}
		}

		private void Die() {
			Instantiate(m_onDieParticle, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}