using Service.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IVehicleWrapper
    {
        IMakeDataManipulations Make { get; }
        IModelDataManipulations Model { get; }
        void Save();
    }
}
