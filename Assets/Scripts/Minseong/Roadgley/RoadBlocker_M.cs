using System.Collections;
using UnityEngine;
using Gley.TrafficSystem;
using Unity.AI.Navigation;   // NavMeshModifier

public class RoadBlocker_M : MonoBehaviour
{
    [Header("�ʼ�: RoadRoot �巡��")]
    [SerializeField] Transform roadRoot;

    [Tooltip("IntersectionPoolManager �� NavMesh�� �ٽ� ������ �� ����� ������ ��")]
    [SerializeField] int delayFrames = 5;

    IEnumerator Start()
    {
        //------------------------------------------------------------------
        // 1) Traffic System �� ������ �ʱ�ȭ�� ������ ���
        //------------------------------------------------------------------
        TrafficComponent tc = null;
        yield return new WaitUntil(() =>
        {
            tc = Object.FindAnyObjectByType<TrafficComponent>();
            return tc != null;
        });

        //------------------------------------------------------------------
        // 2) IntersectionPoolManager �� NavMesh Rebuild �� ��������
        //    ������ �����Ӽ���ŭ ������ �д�
        //------------------------------------------------------------------
        for (int i = 0; i < delayFrames; ++i)
            yield return null;

        int blocked = 0;

        //------------------------------------------------------------------
        // 3) RoadRoot �Ʒ� RoadToggle ���� �˻�
        //------------------------------------------------------------------
        foreach (var tog in roadRoot.GetComponentsInChildren<RoadToggle>(true))
        {
            if (tog == null || tog.alwaysWalkable)
                continue;                       // �ܰ������� ���� �ǳʶ�

            // ���� (A) �������� �̹� �����°�?
            bool visuallyOff = !tog.gameObject.activeInHierarchy ||
                               !AnyRendererEnabled(tog.transform);

            // ���� (B) NavMeshModifier �� Area �� ��Not Walkable(1)�� �ΰ�?
            bool areaOff = false;
            var mod = tog.GetComponent<NavMeshModifier>();
            if (mod && mod.overrideArea && mod.area == 1)
                areaOff = true;

            // �� �� �ϳ��� ���̸� ������ ��ϡ����� �Ǵ�
            if (visuallyOff || areaOff)
            {
                DisableZone(tog);
                blocked++;
            }
        }

        Debug.Log($"[RoadBlocker] waypoint ���� ��� �� = {blocked}");
    }

    // ������������������������������������������������������������������������������������������ Helper ����
    bool AnyRendererEnabled(Transform root)
    {
        foreach (var r in root.GetComponentsInChildren<Renderer>(true))
            if (r.enabled)
                return true;
        return false;
    }

    void DisableZone(RoadToggle tog)
    {
        // ���� ū �ݶ��̴��� ã�Ƽ� ���� �߽ɡ��ݰ� ���
        Collider col = tog.GetComponentInChildren<Collider>(true);
        if (col == null) return;

        Bounds b = col.bounds;
        float radius = Mathf.Max(b.extents.x, b.extents.z);

        // 1) �ش� ���� ��������Ʈ OFF
        API.DisableAreaWaypoints(b.center, radius);

        // 2) �̹� �޸��� �ִ� ���� ȸ��
        API.ClearTrafficOnArea(b.center, radius);
    }
}
