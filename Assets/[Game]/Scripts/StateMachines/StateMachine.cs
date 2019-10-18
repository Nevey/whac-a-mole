using System;
using System.Collections.Generic;

namespace Game.StateMachines
{
    public abstract class StateMachine
    {
        private Dictionary<Type, State> stateDict =
            new Dictionary<Type, State>();

        private Dictionary<State, KeyValuePair<State, Transition>> transitionDict =
            new Dictionary<State, KeyValuePair<State, Transition>>();

        private State currentState;

        /// <summary>
        /// Creates a new State, or gets an existing one if this state type already exists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private State CreateState<T>()
            where T : State, new()
        {
            Type type = typeof(T);
            
            if (stateDict.ContainsKey(type))
            {
                return stateDict[type];
            }

            T state = new T();
            stateDict[type] = state;

            return state;
        }

        /// <summary>
        /// Gets a state. Set "catchException" to true to fail if State does not exist
        /// </summary>
        /// <param name="catchException"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private State GetState<T>(bool catchException = false)
        {
            Type type = typeof(T);
            if (stateDict.ContainsKey(type))
            {
                return stateDict[type];
            }

            if (catchException)
            {
                throw new Exception($"State of type {type.Name} could not be found!");
            }
            
            return null;
        }

        /// <summary>
        /// Get a Transition. Set "catchException" to true to fail if Transition does not exist
        /// </summary>
        /// <param name="catchException"></param>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        private Transition GetTransition<TFrom, TTo>(bool catchException = false)
            where TFrom : State
            where TTo : State
        {
            State fromState = GetState<TFrom>(true);
            State toState = GetState<TTo>(true);

            return GetTransition(fromState, toState, catchException);
        }

        /// <summary>
        /// Get a Transition, from the current State. Set "catchException" to true to fail if Transition does not exist
        /// </summary>
        /// <param name="catchException"></param>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        private Transition GetTransition<TTo>(bool catchException = false)
            where TTo : State
        {
            State toState = GetState<TTo>(true);

            return GetTransition(currentState, toState, catchException);
        }

        /// <summary>
        /// Get a Transition. Set "catchException" to true to fail if Transition does not exist
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="catchException"></param>
        /// <returns></returns>
        private Transition GetTransition(State from, State to, bool catchException = false)
        {
            if (transitionDict.ContainsKey(from)
                && transitionDict[from].Key == to)
            {
                return transitionDict[from].Value;
            }

            if (catchException)
            {
                throw new Exception($"Transition from State {from.GetType().Name} "
                    + "to State {toState.GetType().Name} does not exist!");
            }

            return null;
        }

        public void AddTransition<TFrom, TTo>()
            where TFrom : State, new()
            where TTo : State, new()
        {
            State from = CreateState<TFrom>();
            State to = CreateState<TTo>();

            Transition transition = GetTransition<TFrom, TTo>();
            if (transition == null)
            {
                transition = new Transition(from, to);
                transitionDict[from] = new KeyValuePair<State, Transition>(to, transition);
            }
        }

        public void ToState<T>()
            where T : State
        {
            Transition transition = GetTransition<T>(true);
            currentState = transition.Do();
        }
    }
}