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

        public void SetState<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void SetState<TState, PayLoad>(PayLoad payLoad) where TState : class, IPayLoadState<PayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IBaseState
        {
            _currentState?.Exit();
            TState state = _states[typeof(TState)] as TState;
            _currentState = state;
            return state;
        }
    }
}