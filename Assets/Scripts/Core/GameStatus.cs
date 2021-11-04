﻿using Abstractions;
using System;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Core
{
    public class GameStatus : MonoBehaviour, IGameStatus
    {
        public IObservable<int> Status => _status;
        private Subject<int> _status = new Subject<int>();

        private void checkStatus(object state)
        {
            if (FactionMember.FactionCount == 0) _status.OnNext(0);
            else if (FactionMember.FactionCount == 1) _status.OnNext(FactionMember.GetWinner());
        }

        private void Update()
        {
            ThreadPool.QueueUserWorkItem(checkStatus);
        }
    }
}
