///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 20/06/2020 11:21
///-----------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace Com.MaxmilienGalea.SummerTime.Player {
    public class Player : MonoBehaviour {
        [SerializeField] float maxSpeed = 0;
        [SerializeField] float maxTilt = 0;
        [SerializeField] float fireRate = 0;
        [SerializeField] GameObject missilePrefab = null;
        [SerializeField] Transform gfx = null;
        [SerializeField] Transform cannonContainer = null;

        private Vector3 velocity = new Vector3();

        private float elapsedTimeBtwShoot = 0;
        private Quaternion baseRotation;
        private void Start() {
            baseRotation = gfx.rotation;
        }

        private void Update() {
            Move();
            Tilt();
            Shoot();
        }

        private void Move() {
            velocity.x = Input.GetAxis("Horizontal");
            velocity.z = Input.GetAxis("Vertical");
            velocity = Vector3.ClampMagnitude(velocity, 1);

            transform.position += velocity * maxSpeed * Time.deltaTime;
        }

        private void Tilt() {
            gfx.rotation = baseRotation;
            gfx.rotation = Quaternion.LerpUnclamped(Quaternion.identity, Quaternion.AngleAxis(maxTilt, transform.right), Input.GetAxis("Vertical")) * gfx.rotation;
            gfx.rotation = Quaternion.LerpUnclamped(Quaternion.identity, Quaternion.AngleAxis(maxTilt, transform.forward), -Input.GetAxis("Horizontal")) * gfx.rotation;

            //cannonContainer.rotation = gfx.rotation * cannonContainer.rotation;
            //cannonContainer.rotation = Quaternion.LerpUnclamped(Quaternion.identity, Quaternion.AngleAxis(maxTilt, transform.right), -Input.GetAxis("Vertical"));
            //cannonContainer.rotation = Quaternion.LerpUnclamped(Quaternion.identity, Quaternion.AngleAxis(maxTilt, transform.forward), Input.GetAxis("Horizontal"));
        }

        private void Shoot() {
            elapsedTimeBtwShoot += Time.deltaTime;

            if (elapsedTimeBtwShoot >= fireRate) {
                foreach (Transform cannon in cannonContainer) {
                    Instantiate(missilePrefab, cannon.position, cannon.rotation);

                }
                elapsedTimeBtwShoot -= elapsedTimeBtwShoot;
            }

        }
    }
}