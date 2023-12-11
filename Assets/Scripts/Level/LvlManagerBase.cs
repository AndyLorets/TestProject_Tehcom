using System.Collections.Generic;
using UnityEngine;

public abstract class LvlManagerBase : MonoBehaviour
{
    [Header("Level Count")]
    [SerializeField] protected LvlInfo[] _lvlInfo;

    [Space(5), Header("Lvl Components")]
    [SerializeField] protected UILvlPrefab _lvlPrefab;

    protected List<UILvlPrefab> _lvlPrefabsList;
    public LvlInfo[] lvlInfo => _lvlInfo; 

    protected virtual void Start() => Construct();
    protected virtual void Construct()
    {
        CreateLvlPrefabs();
        UpdateLevelsData();
    }
    protected virtual void CreateLvlPrefabs()
    {
        _lvlPrefabsList = new List<UILvlPrefab>();
    }
    private void UpdateLevelsData()
    {
        Repository.LvlsCount = _lvlInfo.Length;
        for (int i = 0; i < _lvlInfo.Length; i++)
            _lvlInfo[i].UpdateLevelData(i, _lvlPrefabsList[i]);
    }
    private void OnEnable()
    {
        Repository.updateLevelData += UpdateLevelsData;
    }
    private void OnDisable()
    {
        Repository.updateLevelData -= UpdateLevelsData;
    }
    [System.Serializable]
    public class LvlInfo
    {
        public void UpdateLevelData(int index, UILvlPrefab lvlPrefab)
        {
            bool avable = Repository.GetLevelAvable(index);
            avable = index == 0 ? true : avable; 
            lvlPrefab.UpdateLvlData(index, avable);
        }
    }

}
