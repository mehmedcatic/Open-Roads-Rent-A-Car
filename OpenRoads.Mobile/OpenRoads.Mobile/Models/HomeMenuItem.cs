using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Mobile.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        VehicleOffer
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
