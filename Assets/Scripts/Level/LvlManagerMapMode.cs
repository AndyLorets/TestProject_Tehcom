using System.Collections.Generic;
using UnityEngine; 

public class LvlManagerMapMode : LvlManagerBase
{
    [Header("Map Components")]
    [SerializeField] private UIMapLocationPrefab _maplLocation; 

    protected override void CreateLvlPrefabs()
    {
        base.CreateLvlPrefabs();    

        int lvlPointIndex = 0;
        int mapPrefIndex = 0;
        for (int lvlPrefIndex = 0; lvlPrefIndex < _lvlInfo.Length; lvlPrefIndex++)
        {
            UILvlPrefab lvlPrefab = Instantiate(_lvlPrefab, _maplLocation.lvlPoints[lvlPointIndex].transform, false);
            RectTransform lvlRectTransform = lvlPrefab.GetComponent<RectTransform>();

            lvlRectTransform.anchorMin = new Vector2(.5f, .5f);
            lvlRectTransform.anchorMax = new Vector2(.5f, .5f);
            lvlRectTransform.pivot = new Vector2(.5f, .5f);
            lvlRectTransform.anchoredPosition = new Vector2(0, 0);
            _lvlPrefabsList.Add(lvlPrefab);

            lvlPointIndex++;
            if (lvlPointIndex >= _maplLocation.lvlPoints.Length)
            {
                mapPrefIndex++;
                lvlPointIndex = 0;
            }
        }
    }
}
