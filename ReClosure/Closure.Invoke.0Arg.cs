using System;
namespace ReClosure
{
    public partial struct Closure
    {
        public void Invoke()
        {
            if (_delegate is Action act)
            {
                act();
            }
            else
            {
                throw new Exception("Invalid closure");
            }
        }
    }
}