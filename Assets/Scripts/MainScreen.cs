using System;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private Button _restart;

    public event Action OnRestartClicked;

    private void Start()
    {
        _restart.onClick.AddListener(delegate { OnRestartClicked?.Invoke(); });
    }
}