using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shurukhin
{
    internal sealed class Player : MonoBehaviour, IDamage
    {
        float _xRotation = 0f;
        [SerializeField] private float _Life = 3;
        [SerializeField] private float _speed = 2;
        [SerializeField] private float _mouseSense = 100f;
        [SerializeField] private Transform _Camera;
        [SerializeField] private float _speedPlayer = 1;
        [SerializeField] private GameObject _Door;
        [SerializeField] private Animation _Kik;
        [SerializeField] private bool Game = true;
        [Space]
        [SerializeField] private GameObject End_Game = null;
        [SerializeField] private GameObject Finish_Game = null;
        [SerializeField] private Text Lives;
        private Vector3 _direction = Vector3.zero;


        public float Life
        {
            get { return _Life; }
        }

        public void AddDamage()
        {
            _Life -= 1;
            if (_Life <= 0.0f)
            {
                End_Game.SetActive(true);
                Game = false;
            }
        }

        public void AddHeal()
        {
            _Life += 1;
            if (Life > 5)
            {
                _Life = 5;
            }
        }


        void Update()
        {
            if (Game)
            {
                _direction.z = Input.GetAxis("Vertical") * _speedPlayer;
                _direction.x = Input.GetAxis("Horizontal") * _speedPlayer;

                float mouseX = Input.GetAxis("Mouse X") * _mouseSense * Time.fixedDeltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * _mouseSense * Time.fixedDeltaTime;

                _xRotation -= mouseY;
                _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

                _Camera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
                transform.Rotate(Vector3.up * mouseX);
            }
            //счётчик_жизней
            Lives.text = _Life.ToString();
        }

        private void FixedUpdate()
        {
            if(Game)
            {
                Move();
            }
        }

        private void Move()
        {
            var speed = _direction * _speed * Time.fixedDeltaTime;
            transform.Translate(speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Heal_Box"))
            {
                if (_Life != 5)
                {
                    AddHeal();
                    Destroy(other.gameObject);
                }
                
                Debug.Log(_Life);
            }
           
            if (other.CompareTag("Enemy"))
            {
                AddDamage();
                _Kik.Play();
            }

            if (other.CompareTag("Key"))
            {
                Destroy(_Door);
                Debug.Log("Door is open");
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Finish"))
            {
                Finish_Game.SetActive(true);
                Game = false;
            }

        }

    }
}
