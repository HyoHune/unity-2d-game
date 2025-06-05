using UnityEngine;
using Gley.TrafficSystem;

public class RoadRuntimeToggle_M : MonoBehaviour
{
    // ���� ���� �� �� ����������������������������������������������������
    public void DisableRoad(GameObject road)
    {
        Collider col = road.GetComponent<Collider>();
        if (col == null) return;

        Bounds b = col.bounds;
        float r = Mathf.Max(b.extents.x, b.extents.z);

        // v3.1.1 �� 2-�μ� ����
        API.DisableAreaWaypoints(b.center, r);
        API.ClearTrafficOnArea(b.center, r);

        road.SetActive(false);
    }

    // ���� ���� �� �� ����������������������������������������������������
    public void EnableRoad(GameObject road)
    {
        road.SetActive(true);

        Collider col = road.GetComponent<Collider>();
        if (col == null) return;

        Bounds b = col.bounds;
        float r = Mathf.Max(b.extents.x, b.extents.z);

        // ��������Ʈ ��Ȱ�� : �������� ������ ����
        //API.EnableAreaWaypoints(b.center, r);
    }
}
