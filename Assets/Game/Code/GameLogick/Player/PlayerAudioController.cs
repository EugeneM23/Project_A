using FMOD.Studio;
using Game.Code.Infrastructure.Services;
using Game.Code.SoundManager;
using UnityEngine;
using Zenject;

namespace Game.Code.GameLogick.Player
{
    public class PlayerAudioController : ITickable, IInitializable
    {
        private readonly CharacterController _characterController;
        private readonly SoundManager.SoundManager _soundManager;
        private readonly InputService _inputService;

        private EventInstance _playerFootStep;

        public PlayerAudioController(InputService inputService, SoundManager.SoundManager soundManager, IPlayer player)
        {
            _inputService = inputService;
            _soundManager = soundManager;

            _characterController = (player as PlayerBase).gameObject.GetComponent<CharacterController>();
        }

        public void Initialize() => _playerFootStep = _soundManager.CreateInstance(FMODEvents.FootStepsEvent);

        public void Tick()
        {
            if (_inputService.Axis.sqrMagnitude > 0 && _characterController.isGrounded)
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
    }
}