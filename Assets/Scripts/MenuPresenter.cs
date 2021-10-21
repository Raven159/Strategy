using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MenuPresenter : MonoBehaviour
{
    [SerializeField] private Button _comeBackButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _comeBackButton.OnClickAsObservable().Subscribe(_ => gameObject.SetActive(false));
        _exitButton.OnClickAsObservable().Subscribe(_ => Application.Quit());
    }
}