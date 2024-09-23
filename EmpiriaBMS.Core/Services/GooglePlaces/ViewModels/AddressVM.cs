using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmpiriaBMS.Core.Services.GooglePlaces.ViewModels;

public class AddressVM : BNotifyPropertyChanged
{
    private string? _formattedAddress;
    public string? FormattedAddress
    {
        get => _formattedAddress;
        set
        {
            if (value == _formattedAddress)
                return;
            _formattedAddress = value;
            NotifyPropertyChanged(nameof(FormattedAddress));
        }
    }

    private string? _street;
    public string? Street
    {
        get => _street;
        set
        {
            if (value == _street)
                return;
            _street = value;
            NotifyPropertyChanged(nameof(Street));
        }
    }

    private string? _city;
    public string? City
    {
        get => _city;
        set
        {
            if (value == _city)
                return;
            _city = value;
            NotifyPropertyChanged(nameof(City));
        }
    }

    private string? _state;
    public string? State
    {
        get => _state;
        set
        {
            if (value == _state)
                return;
            _state = value;
            NotifyPropertyChanged(nameof(State));
        }
    }

    private string? _postalCode;
    public string? PostalCode
    {
        get => _postalCode;
        set
        {
            if (value == _postalCode)
                return;
            _postalCode = value;
            NotifyPropertyChanged(nameof(PostalCode));
        }
    }

    private string? _country;
    public string? Country
    {
        get => _country;
        set
        {
            if (value == _country)
                return;
            _country = value;
            NotifyPropertyChanged(nameof(Country));
        }
    }

    private string? _placeId;
    public string? PlaceId
    {
        get => _placeId;
        set
        {
            if (value == _placeId)
                return;
            _placeId = value;
            NotifyPropertyChanged(nameof(PlaceId));
        }
    }

    private double _latitude;
    public double Latitude
    {
        get => _latitude;
        set
        {
            if (value == _latitude)
                return;
            _latitude = value;
            NotifyPropertyChanged(nameof(Latitude));
        }
    }

    private double _longitude;
    public double Longitude
    {
        get => _longitude;
        set
        {
            if (value == _longitude)
                return;
            _longitude = value;
            NotifyPropertyChanged(nameof(Longitude));
        }
    }
}
