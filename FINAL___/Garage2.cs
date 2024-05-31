public partial class Garage
{
    public void SortVehiclesByArea()
    {
        for (int i = 0; i < Vehicles.Count - 1; i++)
        {
            for (int j = 0; j < Vehicles.Count - i - 1; j++)
            {
                if (Vehicles[j].Area > Vehicles[j + 1].Area)
                {
                    var temp = Vehicles[j];
                    Vehicles[j] = Vehicles[j + 1];
                    Vehicles[j + 1] = temp;
                }
            }
        }
    }

}