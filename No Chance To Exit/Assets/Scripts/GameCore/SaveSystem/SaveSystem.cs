using UnityEngine;

namespace GameCore
{
    public class SaveData
    {
        public int levelIndex;
        public int points;
        public bool wasPlayed;

        public SaveData()
        {
            levelIndex = 1;
            points = 0;
            wasPlayed = false;
        }


    }


    public class SaveSystem : MonoBehaviour
    {
        private SaveData save;

        // START GAME

        public SaveData GetSave()
        {
            return save;
        }

        // NEXT LEVEL

        public SaveData IncreaseLevelIndex()
        {
            save.levelIndex += 1;
            return save;
        }


        public void SaveData()
        {
            PlayerPrefs.SetString(Keys.SaveKeys.SAVE_KEY, JsonUtility.ToJson(save));
        }

        public void LoadData()
        {
            if (PlayerPrefs.HasKey(Keys.SaveKeys.SAVE_KEY))
            {
                save = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(Keys.SaveKeys.SAVE_KEY));
            }
            else
            {
                save = new SaveData();
                SaveData();
            }
        }

    } 
}
