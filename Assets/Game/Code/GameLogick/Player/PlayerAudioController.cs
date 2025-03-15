using FMOD.Studio;
using Game.Code.Infrastructure.Main;
using Game.Code.Infrastructure.Services;
using Game.Code.SoundSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.GameLogick.Player
{
    public class PlayerAudioController : ITickable, IInitializable, IGameStartListener, IGamePauseListener,
        IGameFinishListener, IGameResumListener
    {
        private readonly CharacterController _characterController;
        private readonly SoundManager _soundManager;
        private readonly InputService _inputService;

        private EventInstance _playerFootStep;
        private bool _isMovable;

        public PlayerAudioController(InputService inputService, SoundManager soundManager, IPlayer player)
        {
            _inputService = inputService;
            _soundManager = soundManager;

            _characterController = (player as PlayerBase).gameObject.GetComponent<CharacterController>();
        }

        public void Initialize() => _playerFootStep = _soundManager.CreateInstance(FMODEvents.FootStepsEvent);

        public void Tick()
        {
            if (_inputService.Axis.sqrMagnitude > 0 && _characterController.isGrounded && _isMovable)
            {
                PLAYBACK_STATE playbackState;
                _playerFootStep.getPlaybackState(out playbackState);

                if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                    _playerFootStep.start();
            }
            else
            {
                _playerFootStep.stop(STOP_MODE.IMMEDIATE);
            }
        }

        public void OnStartGame() => _isMovable = true;

        public void OnPauseGame() => _isMovable = false;

        public void OnFinishGame() => _isMovable = false;

        public void OnResumeGame() => _isMovable = true;
    }
}