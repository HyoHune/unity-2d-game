using UnityEngine;

public class TurnBarTrafficSync_M : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    bool lastRunning;

    void Awake()
    {
        if (turnManager == null)
            turnManager = FindObjectOfType<TurnManager>();
    }

    void Start()               // ���� ���� ����ȭ
    {
        lastRunning = turnManager.isMidTurn;
        TrafficPauseManager_M.SetPaused(!lastRunning);
    }

    void Update()
    {
        bool nowRunning = turnManager.isMidTurn;
        if (nowRunning != lastRunning)
        {
            TrafficPauseManager_M.SetPaused(!nowRunning);
            lastRunning = nowRunning;
        }
    }
}
