using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatForms
{ 
 class State : SuperState
{
    public delegate void Handler();
    public State()
    { }
    public State(Enum e)
    {
        onEnter = null;
        onExit = null;
        name = e.ToString();
    }
    public string name;
    public delegate void OnEnter();
    public delegate void OnExit();
    public OnEnter onEnter;
    public OnExit onExit;

    public void AddEnterFunction(Delegate d)
    {
        onEnter += d as OnEnter;
    }
    public void AddExitFunction(Delegate a)
    {
        onExit += a as OnExit;
    }
    public override void Start()
    {
        Console.WriteLine("States Name" + this.name);
    }
    public override void Update()
    {
        throw new NotImplementedException();
    }
    public override void Exit()
    {
        Console.WriteLine("Exit state " + this.name);
    }

}
public abstract class SuperState
{
    public abstract void Start();
    public abstract void Update();
    public abstract void Exit();
}

}