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

        public void ChangeState(T e)
        {
            string Key = current.ToString() + "->" + (e as Enum).ToString();
            if (transitions[Key] != null)
            {
                current.onExit.Invoke();
                current = states[(e as Enum).ToString()];
                current.onEnter.Invoke();
            }
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


        public bool AddTransition<V>(V a, V b)
        {
            State s = a as State;
            var tmp = transitions[s.name];

            return true;
        }


        public State GetState(T e)
        {
            string key = (e as State).name;
            return states[key];
        }

        private bool isValidTransition(State to)
        {
            var validStates = transitions[current.name];
            if (validStates == null)
                return false;
            foreach (var state in validStates)
            {
                if (state == to)
                    return true;
            }
            return false;
        }




        public bool Start(T state)
        {
            return true;
        }




        public bool Update()
        {
            return true;
        }



    }
}

