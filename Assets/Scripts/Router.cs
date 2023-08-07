using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Router : MonoBehaviour
    {
        [SerializeField] private CharacterClickListener _characterClickListener;

        [SerializeField] private CharacterPartPusher _characterPartPusher;

        [SerializeField] private RagdollActivator _ragdollActivator;

        [SerializeField] private RagdollInfo _ragdollInfo;

        [SerializeField] private CharacterController _characterController;

        [SerializeField] private CameraMove _cameraMove;

        [SerializeField] private MainScreen _mainScreen;

        private async void ActivateRagdollAndPushAsync(RaycastHit partHit)
        {
            _cameraMove.GoToLookZone();
            
            _ragdollActivator.Activate();
            
            _characterPartPusher.Push(partHit);

            await Task.Delay(100);
            
            while (_ragdollInfo.IsMoving)
                await Task.Delay(1);
            
            _ragdollActivator.DeActivate();
            
            _characterController.StandUp();
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        private void OnEnable()
        {
            _characterClickListener.Clicked += ActivateRagdollAndPushAsync;
            _mainScreen.OnRestartClicked += Restart;
        }

        private void Start()
        {
            
        }

        private void OnDisable()
        {
            _characterClickListener.Clicked -= ActivateRagdollAndPushAsync;
            _mainScreen.OnRestartClicked -= Restart;
        }
    }
}