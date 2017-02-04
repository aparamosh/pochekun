using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// почекун це насправді загублений інтерфейс C#
/// </summary>
namespace ПочекунLibrary
{

    public interface IAwaitable<out TResult>
    {
        Iпочекун<TResult> GetAwaiter();
    }

    public interface Iпочекун<out TResult> : INotifyCompletion
    {
        bool IsCompleted { get; }
        TResult GetResult();
    }

    public struct FuncОчікуване<TResult> : Iпочекун<TResult>
    {
        private readonly Task<TResult> task;

        public FuncОчікуване(Func<TResult> function)
        {
            this.task = new Task<TResult>(function);
            this.task.Start();
        }

        bool Iпочекун<TResult>.IsCompleted
        {
            get
            {
                return this.task.IsCompleted;
            }
        }

        TResult Iпочекун<TResult>.GetResult()
        {
            return this.task.Result;
        }

        void INotifyCompletion.OnCompleted(Action continuation)
        {
            new Task(continuation).Start();
        }
    }

    public static class FuncExtensions
    {
        public static Iпочекун<TResult> GetAwaiter<TResult>(this Func<TResult> function)
        {
            return new FuncОчікуване<TResult>(function);
        }
    }
}
