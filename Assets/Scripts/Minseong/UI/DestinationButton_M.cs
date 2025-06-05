using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DestinationButton_M : MonoBehaviour
{
    [SerializeField] TMP_Text label;

    // ���� �߰�(3��)
    [Header("Text Colors")]
    [SerializeField] Color pickupColor = Color.black;     // �⺻(�Ⱦ���) ��
    [SerializeField] Color deliveryColor = new(0.12f, 0.55f, 1f); // ����� ��

    int index;
    DestinationUI_M ui;

    /* ���������������������������������������������������������������������������������������������� */
    /* �ʱ�ȭ                                          */
    /* ���������������������������������������������������������������������������������������������� */
    public void Init(int idx, DestinationUI_M parent)
    {
        index = idx;
        ui = parent;
        GetComponent<Button>()
            .onClick.AddListener(() => ui.SelectIndex(index));
    }

    public void SetLabel(string text)
    {
        label.text = text;
    }

    // �Ⱦ�/��޿� ���� �� ���� �߰�
    public void SetAsPickup() => label.color = pickupColor;
    public void SetAsDelivery() => label.color = deliveryColor;

}
