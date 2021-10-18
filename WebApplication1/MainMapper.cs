using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public abstract class MainMapper<TLeft, TRight>
    {
        // Override single element Map 
        public abstract TLeft Map(TRight RightSideElement);
        public abstract TRight Map(TLeft LeftSideElement);

        // List of elements mappers 
        public List<TLeft> Map(List<TRight> RightSideList)
        {
            var TLeftList = new List<TLeft>(RightSideList.Count());
            foreach (var RightSideElem in RightSideList)
            { 
                TLeftList.Add(Map(RightSideElem)); 
            }
            return TLeftList;
        }

        public List<TRight> Map(List<TLeft> LeftSideList)
        {
            var TRightList = new List<TRight>(LeftSideList.Count());
            foreach (var LeftSideElem in LeftSideList)
            {
                TRightList.Add(Map(LeftSideElem));
            }
            return TRightList;
        } 

    }
}
