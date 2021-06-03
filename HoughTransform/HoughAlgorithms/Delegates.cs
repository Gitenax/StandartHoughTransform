using System;

namespace HoughTransform.HoughAlgorithms
{
    public class HoughEventArgs : EventArgs
    {
        public HoughEventArgs(int maxValue, int current)
        {
            (MaxValue, Current) = (maxValue, current);
        }
        
        public int MaxValue { get; }
        public int Current { get; }
    }


    public delegate void HoughEvent(object sender, HoughEventArgs args);
}