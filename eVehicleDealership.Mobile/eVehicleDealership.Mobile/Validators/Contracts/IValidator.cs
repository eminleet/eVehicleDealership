using System;
using System.Collections.Generic;
using System.Text;

namespace eVehicleDealership.Mobile.Validators.Contracts
{
    public interface IValidator
    {
        string Message { get; set; }
        bool Check(string value);
    }
}
