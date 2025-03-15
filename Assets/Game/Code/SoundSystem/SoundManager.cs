using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace Game.Code.SoundSystem
{
    public class SoundManager : IInitializable
    {
        private List<EventInstance> _savedGameEvents = new();
        private List<StudioEventEmitter> _emitters = new();

        private EventInstance _embient;

        public void Initialize()
        {
            //InitAmbient(FMODEvents.Ambient);
        }

        public void PlayeOneShot(string eventPath) => RuntimeManager.PlayOneShot(eventPath);

        public EventInstance CreateInstance(string eventReference)
        {
            EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);

            _savedGameEvents.Add(eventInstance);
            return eventInstance;
        }

        private void InitAmbient(string ambientEventReference)
        {
            _embient = RuntimeManager.CreateInstance(ambientEventReference);
            _embient.start();
        }

        public void CleanUp()
        {
            Debug.Log("Sound Manager cleanup");
            foreach (var item in _savedGameEvents)
            {
                item.stop(STOP_MODE.IMMEDIATE);
                item.release();
            }

            foreach (var item in _emitters)
                item.Stop();
        }
    }
}