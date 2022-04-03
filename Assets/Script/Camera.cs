using UnityEngine;

namespace Script
{
    public class Camera : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        private Vector3 _offset;
        public static Camera main;


        private void Start()
        {
            _offset = transform.position;
        }

        void Update()
        {
            transform.position = target.transform.position + _offset;
        }

    }
}