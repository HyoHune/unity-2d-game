using System.Collections;
using UnityEngine;
using Gley.TrafficSystem;

public class RoadDisablerAfterInit_M : MonoBehaviour
{
    [SerializeField] Transform roadRoot;       // RoadRoot�� Inspector�� �巡��
    [Range(0f, 1f)] public float disableRatio = 0.30f;   // 30 % ����

    IEnumerator Start()
    {
        // �ʱ�ȭ �Ϸ� ���
        yield return new WaitUntil(() => FindObjectOfType<TrafficComponent>() != null);

        // ��� RoadToggle Ž��
        var toggles = roadRoot.GetComponentsInChildren<RoadToggle>(true);
        Debug.Log($"[Disabler] found {toggles.Length} toggles");

        // ���� ����
        foreach (var tog in toggles)
        {
            // (1) �ܰ����Ρ��������� �ǳʶٱ�
            if (tog.alwaysWalkable)                 // Inspector üũ�ڽ�
                continue;                           // �Ǵ�  tog.CompareTag("FixedRoad")

            // (2) disableRatio% ��ŭ �������� ��Ȱ��
            if (Random.value < disableRatio)
            {
                Debug.Log($"[Disabler] disable {tog.name}");
                tog.SetActiveRoad(false);
            }
        }
    }
}
