using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public interface IMainMapper<TLeft, TRight>{
        public TLeft Map(TRight RightSideElement);
        public TRight Map(TLeft LeftSideElement);
        public List<TLeft> Map(List<TRight> RightSideElement);
        public List<TRight> Map(List<TLeft> LeftSideElement); 
    }
   /* public abstract class MainMapper<TLeft, TRight> : IMainMapper<TLeft, TRight>
    {
        // Override single element Map 
        public abstract TLeft Map(TRight RightSideElement);
        public abstract TRight Map(TLeft LeftSideElement);

        // Mapping lists of elements 
        public virtual List<TLeft> Map(List<TRight> RightSideList)
        {
            var TLeftList = new List<TLeft>(RightSideList.Count());
            foreach (var RightSideElem in RightSideList)
            { 
                TLeftList.Add(Map(RightSideElem)); 
            }
            return TLeftList;
        }

        public virtual List<TRight> Map(List<TLeft> LeftSideList)
        {
            var TRightList = new List<TRight>(LeftSideList.Count());
            foreach (var LeftSideElem in LeftSideList)
            {
                TRightList.Add(Map(LeftSideElem));
            }
            return TRightList;
        } 

    }*/
}
