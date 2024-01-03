using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Connect.Core
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager Instance;

        


        [SerializeField] private GameObject _titlePanel;


        public void ClickedPlay()
        {

            GameManager.Instance.GoToGameplay();
        }
                
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }

    } 
}

