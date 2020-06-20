///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 20/06/2020 15:17
///-----------------------------------------------------------------

using System.Runtime.InteropServices.ComTypes;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

namespace Com.MaxmilienGalea.Shmrogue.Settings {
    [CreateAssetMenu(fileName = "Player controller", menuName = "Player/PlayerController")]
    public class Controller : ScriptableObject {

        [SerializeField] private string m_horizontal = null;
        [SerializeField] private string m_vertical = null;
        [SerializeField] private float m_height = 0;
        [SerializeField] private float m_minDistanceTilt = 0;

        private Vector3 pos = new Vector3();

        public float MinDistanceTilt => m_minDistanceTilt;

        public Vector3 GetAxisClamped() {

            Vector3 vector3 = new Vector3(Input.GetAxis(m_horizontal), 0, Input.GetAxis(m_vertical));
            vector3 = Vector3.ClampMagnitude(vector3, 1);
            return vector3;
        }


        public Vector3 GetMousePos() {
            if (Input.GetMouseButton(0)) {
                pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_height));
                //pos.y = m_height;
                Debug.DrawLine(Camera.main.transform.position, pos, Color.red);
            }

            return pos;
        }
    }
}