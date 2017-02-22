using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatForms
{
    class State
    {
        public State()
        { }
        public State(Enum e)
        {
            name = e.ToString();
            stateName = e;
        }
        public int Id;
        public string name;
        public string Name
        {
            get { return name; }
        }
        public Enum stateName;




        public Handler onEnter = null;
        public Handler onExit = null;

        public void AddEnterFunction(Delegate d)
        {
            onEnter += d as Handler;
        }
        public void AddExitFunction(Delegate a)
        {
            onExit += a as Handler;
        }

        //public override void Start()
        //{
        //    Console.WriteLine("States Name" + this.name);
        //}
        //public override void Update()
        //{
        //    throw new NotImplementedException();
        //}
        //public override void Exit()
        //{
        //    Console.WriteLine("Exit state " + this.name);
        //}

    }
    public abstract class SuperState
    {
        public abstract void Start();
        public abstract void Update();
        public abstract void Exit();
    }

}