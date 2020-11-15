namespace Service.Interfaces
{
    //It seemed really useful when I made it, but splitting data manipulations made this class unnecessary
    public interface IVehicleWrapper
    {
        IMakeDataManipulations Make { get; }
        IModelDataManipulations Model { get; }
        void Save();
    }
}
