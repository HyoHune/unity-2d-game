using UnityEngine;
using Gley.TrafficSystem;

public class TurnBarTrafficSync_M : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    bool lastMidTurn;

    void Awake()
    {
        // Inspector�� �Ҵ� �� �Ǿ������� ã�Ƽ� ��������
        if (turnManager == null)
            turnManager = Object.FindFirstObjectByType<TurnManager>();
    }

    void Start()
    {
        // ���� ���� ����ȭ
        lastMidTurn = turnManager.isMidTurn;
        ApplyPause(!lastMidTurn);
    }

    void Update()
    {
        // �� ������ ���� �� ���� ���� üũ
        bool nowMidTurn = turnManager.isMidTurn;
        if (nowMidTurn != lastMidTurn)
        {
            // ���°� �ٲ������ ApplyPause ȣ��
            ApplyPause(!nowMidTurn);
            lastMidTurn = nowMidTurn;
        }
    }

    void ApplyPause(bool shouldPause)
    {
        Debug.Log($"[TurnBarSync] SetPaused({shouldPause})");
        TrafficPauseManager_M.SetPaused(shouldPause);
    }
}
