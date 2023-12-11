using UnityEngine;

public class UIMapLocationPrefab : MonoBehaviour
{
    public Transform[] lvlPoints => GetPoints();
    private Transform[] GetPoints()
    {
        Transform[] list = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            list[i] = transform.GetChild(i);

        }
        return list;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        GetPoints();
    }
    private void OnDrawGizmos()
    {
        if (lvlPoints == null) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < lvlPoints.Length; i++)
        {
            Vector2 from = lvlPoints[i].position;
            Gizmos.DrawWireSphere(from, .25f);

            if (i >= lvlPoints.Length - 1) return;

            Vector2 to = lvlPoints[i + 1].position;
            Gizmos.DrawLine(from, to);
        }

    }
#endif
}
