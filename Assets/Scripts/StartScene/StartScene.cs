using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asha
{
    public class StartScene : MonoBehaviour
    {
        public Button PlayBtn;
        public Button ExitBtn;

        void Start()
        {
            this.PlayBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MenuScene");
            });

            this.ExitBtn.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

    }
}

