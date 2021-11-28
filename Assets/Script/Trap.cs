using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shurukhin
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] private Animation _trap;

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _trap.Play();
            }
        }
    }
}

