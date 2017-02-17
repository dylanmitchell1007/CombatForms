using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatForms
{
    class FSM<T>
    {
        public FSM()
        {
            current = null;
            transitions = new Dictionary<string, List<State>>();
            states = new Dictionary<string, State>();
            var v = Enum.GetValues(typeof(T));
            foreach (var e in v)
            {
                State s = new State(e as Enum);
                states.Add(s.name, s);
            }
        }

        Dictionary<string, State> states;
        State current;
        private Dictionary<string, List<State>> transitions;

        public void addOnEnter(T state, Delegate enter)
        {
            states[state.ToString()].AddEnterFunction(enter);
        }
        public void addOnExit(T state, Delegate exit)
        {
            states[state.ToString()].AddExitFunction(exit);
        }

        public bool AddState(State state)
        {
            if (transitions[state.name] == null)
            {
                transitions.Add(state.name, new List<State>());
                return true;
            }
            return false;
        }


        public bool AddTransition(T from, T to)
        {
            string Key = from.ToString() + "->" +to.ToString();
            if(transitions.ContainsKey(Key) == false)
            {
                List<State> temp = new List<State>();
                temp.Add(states[from.ToString()]);
                temp.Add(states[to.ToString()]);
                transitions.Add(Key, temp);
                return true;
            }
            return false;
        }


        public void ChangeState(T to)
        {
            string Key = current.Name + "->" + to.ToString();
            if (transitions.ContainsKey(Key))
            {
                current.onExit.Invoke();
                current = states[to.ToString()];
                current.onEnter.Invoke();
            }
        }


        public State GetCurrentState()
        {
            return current;
        }       


        public bool Start(T state)
        {
            if (states.ContainsKey(state.ToString()))
            {
                current = states[state.ToString()];
                current.onEnter.Invoke();
                return true;
            }
            return false;
        }


        public bool Update()
        {
            return true;
        }

    }
}

