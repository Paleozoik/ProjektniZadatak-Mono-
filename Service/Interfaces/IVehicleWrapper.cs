namespace Service.Interfaces
{
    //It seemed really useful when I made it, but splitting data manipulations made this class unnecessary
    public interface IVehicleWrapper
    {
        IMakeService MakeService { get; }
        IModelService ModelService { get; }
        void Save();
    }
}
