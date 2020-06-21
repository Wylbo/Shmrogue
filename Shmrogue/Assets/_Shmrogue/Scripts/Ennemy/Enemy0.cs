///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 21/06/2020 22:11
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.MaxmilienGalea.Shmrogue.Ennemy {
	public class Enemy0 : AEnemy {

		[SerializeField] float m_speed = 0;

		protected override void Start () {
			base.Start();
		}
		
		protected override void Update () {
			base.Update();
			Move();
		}

		protected override void Move() {
			base.Move();
			transform.position += transform.forward * m_speed * Time.deltaTime;
		}
	}
}