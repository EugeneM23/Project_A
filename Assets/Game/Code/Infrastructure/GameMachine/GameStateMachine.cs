using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Infrastructure.GameMachine
{
    public class GameStateMachine
    {
        public readonly Dictionary<Type, IBaseState> _states;
        private IBaseState _currentState;

        public GameStateMachine(IEnumerable<IBaseState> states)
        {
            _states = states.ToDictionary(state => state.GetType(), state => state);
        }

        public void SetState<T>() where T : class, IState
        {
            if (_currentState == typeof(T)) return;

            _currentState?.Exit();
            IState state = _states[typeof(T)] as T;
            _currentState = state;
            state.Enter();
        }

        public void SetState<T, PayLoad>(PayLoad payLoad) where T : class, IPayLoadState<PayLoad>
        {
            if (_currentState == typeof(T)) return;

            _currentState?.Exit();
            IPayLoadState<PayLoad> state = _states[typeof(T)] as T;
            _currentState = state;
            state.Enter(payLoad);
        }
    }
}