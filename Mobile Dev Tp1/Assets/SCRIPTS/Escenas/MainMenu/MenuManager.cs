using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Escenas.MainMenu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> menus = new();

        private void Awake()
        {
            menus[0].SetActive(true);

            for (var i = 1; i < menus.Count; i++)
            {
                menus[i].SetActive(false);
            }
        }
        
        public void Play()
        {
            LoadScene("conduccion9");
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}