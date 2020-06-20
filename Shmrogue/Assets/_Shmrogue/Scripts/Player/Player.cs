///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 20/06/2020 11:21
///-----------------------------------------------------------------

using Com.MaxmilienGalea.Shmrogue.Settings;
using DG.Tweening;
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
        [Space]
        [SerializeField] Controller controller;

        private Vector3 velocity = new Vector3();
        private Vector3 mousePos = new Vector3();

        private float elapsedTimeBtwShoot = 0;
        private Quaternion baseRotation;
        private void Start() {
            baseRotation = gfx.rotation;
        }

        private void Update() {
            GetInput();
        }

        private void FixedUpdate() {
            Move();
            Tilt();
            Shoot();

        }

        private void GetInput() {
            velocity = controller.GetAxisClamped();
            mousePos = controller.GetMousePos();
            Debug.Log(mousePos);
        }


        private void Move() {
            transform.position += velocity * maxSpeed * Time.deltaTime;
            transform.DOMove(mousePos, .15f).SetEase(Ease.InOutCirc);
        }

        private void Tilt() {
            Vector3 toMouse = mousePos - transform.position;
            gfx.rotation = baseRotation;

            //if (toMouse.magnitude < controller.MinDistanceTilt) {
            //    return;
            //}

            gfx.rotation = baseRotation;
            gfx.rotation = Quaternion.LerpUnclamped(Quaternion.identity, Quaternion.AngleAxis(maxTilt, Vector3.Cross(toMouse,Vector3.up)), -Vector3.ClampMagnitude(toMouse,1).magnitude) * gfx.rotation;

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