using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Shurukhin
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Button exitGame = null;
        [SerializeField] private Button RePleyGame = null;

        private void ExitButton()
        {
            Debug.Log("Exit");
        }

        private void RePlay()
        {
            SceneManager.LoadScene(0);
        }

        private void Awake()
        {
            exitGame.onClick.AddListener(ExitButton);
            RePleyGame.onClick.AddListener(RePlay);
        }
    }
}
