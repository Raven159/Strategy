using System;
using Utils;

namespace UserControlSystem
{
    public class NewValueNotifier<TAwaited> : IAwaiter<TAwaited>
    {
        private readonly ScriptableObjectValueBase<TAwaited> _scriptableObjectValueBase;
        private TAwaited _result;
        private Action _continuation;
        private bool _isCompleted;

        public NewValueNotifier(ScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += ONNewValue;
        }

        private void ONNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= ONNewValue;
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }
        public bool IsCompleted => _isCompleted;
        public TAwaited GetResult() => _result;
    }
}