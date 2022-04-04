using UnityEngine;

[CreateAssetMenu(fileName = "Windows Asset", menuName = "Utils/Windows asset", order = 1)]
public class WindowsAsset : ScriptableObject
{
    [SerializeField]
    private GameObject[] windows;

    public GameObject[] Windows
    {
        get => windows;
    }
}
