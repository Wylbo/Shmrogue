///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 21/06/2020 22:09
///-----------------------------------------------------------------

using UnityEngine;
using Vuforia;

namespace Com.MaxmilienGalea.Shmrogue.Ennemy {
	
	public abstract class AEnemy : MonoBehaviour {
		[SerializeField] protected float m_hp = 0;

		protected virtual void Start () {
			
		}
		
		protected virtual void Update () {
			
		}

		protected virtual void Move() {

		}

		protected virtual void Shoot() {

		}

		protected virtual void Die() {
			Destroy(gameObject);
		}

		public virtual void TakeDamage(float damage) {
			m_hp -= damage;
			if (m_hp <= 0) {
				Die();
			}
		}
	}
}