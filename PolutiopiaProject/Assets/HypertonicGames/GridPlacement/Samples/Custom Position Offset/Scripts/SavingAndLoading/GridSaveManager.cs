using Hypertonic.GridPlacement.Enums;
using Hypertonic.GridPlacement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Hypertonic.GridPlacement.Example.PositionOffsetDemo { 

    /// <summary>
    /// This is an example implementation of how you can get the grid data and save it. Then load it back into the grid.
    /// For this simple demo the class will use PlayerPrefs as a way to persist a serialised form of the data in this example.
    /// </summary>
    public class GridSaveManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _gridObjectPrefabs = new List<GameObject>();

        private string _playPrefsSaveDataKey = "playPrefsSaveDataKey";

        private void OnEnable()
        {
            Button_SaveGridObjects.OnSaveGridObjectsEvent += HandleSaveGridObjectsPressed;
            Button_LoadGridObjects.OnLoadGridObjectsEvent += HandleLoadGridObjectsPressed;
        }

        private void OnDisable()
        {
            Button_SaveGridObjects.OnSaveGridObjectsEvent -= HandleSaveGridObjectsPressed;
            Button_LoadGridObjects.OnLoadGridObjectsEvent -= HandleLoadGridObjectsPressed;
        }

        private void HandleSaveGridObjectsPressed()
        {
            GridData gridData = GridManagerAccessor.GridManager.GridData;

            SaveData saveData = new SaveData();

            for(int i = 0; i < gridData.GridObjectPositionDatas.Count; i++)
            {
                GridObjectPositionData gridObjectPositionData = gridData.GridObjectPositionDatas[i];

                GridObjectSaveData gridObjectSaveData = 
                    new GridObjectSaveData(gridObjectPositionData.GridObject.name, gridObjectPositionData.GridCellIndex, gridObjectPositionData.ObjectAlignment, gridObjectPositionData.GridObject.transform.rotation);

                saveData.GridObjectSaveDatas.Add(gridObjectSaveData);
            }

            string saveDataAsJson = JsonUtility.ToJson(saveData);

            PlayerPrefs.SetString(_playPrefsSaveDataKey, saveDataAsJson);            
        }

        private void HandleLoadGridObjectsPressed()
        {
            _ = LoadGridData();
        }

        private async Task LoadGridData()
        {
            if (!PlayerPrefs.HasKey(_playPrefsSaveDataKey))
            {
                Debug.LogWarning("There is no save data stored yet. You must save the grid data before being able to load it.");
                return;
            }

            string saveDataAsJson = PlayerPrefs.GetString(_playPrefsSaveDataKey);

            SaveData saveData = JsonUtility.FromJson<SaveData>(saveDataAsJson);

            List<GridObjectPositionData> gridObjectPositionDatas = new List<GridObjectPositionData>();

            foreach (GridObjectSaveData gridObjectSaveData in saveData.GridObjectSaveDatas)
            {
                GameObject prefab = _gridObjectPrefabs.Where(x => x.name.Equals(gridObjectSaveData.PrefabName)).FirstOrDefault();
                GameObject gridObject = Instantiate(prefab);
                gridObject.transform.rotation = gridObjectSaveData.ObjectRotation;

                // Remove the "(Clone)" from instantiated name.
                gridObject.name = prefab.name;


                if (!gridObject.TryGetComponent(out ExampleGridObject exampleGridObjectComponent))
                {
                    gridObject.AddComponent<ExampleGridObject>();
                }
                

                GridObjectPositionData gridObjectPositionData = new GridObjectPositionData(gridObject, gridObjectSaveData.GridCellIndex, gridObjectSaveData.ObjectAlignment);
                gridObjectPositionDatas.Add(gridObjectPositionData);
            }

            GridData gridData = new GridData(gridObjectPositionDatas);

            await GridManagerAccessor.GridManager.PopulateWithGridData(gridData, true);
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public List<GridObjectSaveData> GridObjectSaveDatas = new List<GridObjectSaveData>();
    }

    [System.Serializable]
    public class GridObjectSaveData
    {
        public string PrefabName;
        public Vector2Int GridCellIndex;
        public ObjectAlignment ObjectAlignment;
        public Quaternion ObjectRotation;

        public GridObjectSaveData(string prefabKey, Vector2Int gridCellIndex, ObjectAlignment objectAlignment, Quaternion objectRotation)
        {
            PrefabName = prefabKey;
            GridCellIndex = gridCellIndex;
            ObjectAlignment = objectAlignment;
            ObjectRotation = objectRotation;


        }
    }
}