using Connect.Common;
using System.Collections.Generic;
using UnityEngine;

namespace Connect.Core
{
    public class GameManager : MonoBehaviour
    {
        #region START_METHODS

        public static GameManager Instance;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Init();
                DontDestroyOnLoad(gameObject);
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Init()
        {
            CurrentLevel= 1;

            Levels = new Dictionary<string, LevelData>();

            foreach (var item in _allLevels.Levels)
            {
                Levels[item.LevelName] = item;
            }
        }


        #endregion

        #region GAME_VARIABLES



        [HideInInspector]
        public int CurrentLevel;

      
        public bool IsLevelUnlocked(int level)
        {
            string levelName = "Level" + level.ToString();

            if(level == 1)
            {
                PlayerPrefs.SetInt(levelName, 1);
                return true;
            }

            if(PlayerPrefs.HasKey(levelName)) 
            {
                return PlayerPrefs.GetInt(levelName) == 1;
            }

            PlayerPrefs.SetInt(levelName, 0);
            return false;
        }

        public void UnlockLevel()
        {
            CurrentLevel++;

            if(CurrentLevel == 4)
            {
                CurrentLevel = 1;
                
            }

            string levelName = "Level" +  CurrentLevel.ToString();
            PlayerPrefs.SetInt(levelName, 1);
        }

        #endregion

        #region LEVEL_DATA

        [SerializeField]
        private LevelData DefaultLevel;

        [SerializeField]
        private LevelList _allLevels;

        private Dictionary<string, LevelData> Levels;

        public LevelData GetLevel()
        {
            string levelName = "Level" + CurrentLevel.ToString();

            if(CurrentLevel == 2)
            {
                return Levels["2"];
            }
            if(CurrentLevel == 3)
            {

           
                
          
                return Levels["3"];
            }

            return DefaultLevel;
        }

        #endregion

        #region SCENE_LOAD

        private const string MainMenu = "MainMenu";
        private const string Gameplay = "Gameplay";

        public void GoToMainMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
        }

        public void GoToGameplay()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Gameplay);
        }

        #endregion
    } 
}
