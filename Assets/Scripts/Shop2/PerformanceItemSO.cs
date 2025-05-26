using UnityEngine;

[CreateAssetMenu(menuName = "Shop/PerformanceItem")]
public class PerformanceItemSO : ScriptableObject
{
    [Header("고유 ID (예: car1, scooter2)")]
    public string itemId; // 이 필드를 새로 추가

    public Sprite image;
    public PerformanceCategorySO category;
    public int price;
    public float speed;
    public float efficiency;
    public float capacity;

    public ItemType itemType;

    public string itemNameKR;
    public string itemNameEN;

    [TextArea] public string descriptionKR;
    [TextArea] public string descriptionEN;

    public string DisplayName =>
        LocalizationManager.Instance.currentLanguage == Language.Korean ? itemNameKR : itemNameEN;

    public string DisplayDescription =>
        LocalizationManager.Instance.currentLanguage == Language.Korean ? descriptionKR : descriptionEN;
}
