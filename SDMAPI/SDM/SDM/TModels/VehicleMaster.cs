using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class VehicleMaster
    {
        public int VhId { get; set; }
        public string VhCode { get; set; }
        public string VhType { get; set; }
        public string VhVehicleOn { get; set; }
        public string VhName { get; set; }
        public string VhMakeBrand { get; set; }
        public string VhModelYear { get; set; }
        public DateTime? VhPurchaseDt { get; set; }
        public string VhRegNo { get; set; }
        public string VhRegistrationExp { get; set; }
        public string VhTypeOfPurchase { get; set; }
        public string VhSizeCapacity { get; set; }
        public string VhDrivenBy { get; set; }
        public int? VhCostCentre { get; set; }
        public string VhLocation { get; set; }
        public string VhPurchaseValue { get; set; }
        public string VhPurchasedFrom { get; set; }
        public string VhPurchasedColor { get; set; }
        public string VhColour { get; set; }
        public string VhEnginePower { get; set; }
        public string VhNoOfEngines { get; set; }
        public string VhEngineSerialNumber { get; set; }
        public string VhEngineMake { get; set; }
        public string VhTypeOfHull { get; set; }
        public string VhHullChassisNo { get; set; }
        public string VhWeight { get; set; }
        public string VhOriginPlace { get; set; }
        public string VhNoOfPassengers { get; set; }
        public string VhNoOfCrew { get; set; }
        public string VhRadioDeviceName { get; set; }
        public string VhRadioDeviceType { get; set; }
        public string VhRadioDeviceSno { get; set; }
        public string VhImage { get; set; }
        public string VhStatus { get; set; }
        public string VhOthers1 { get; set; }
        public string VhOthers2 { get; set; }
        public string VhOthers3 { get; set; }
        public string VhOthers4 { get; set; }
        public int? VhCreatedBy { get; set; }
        public DateTime? VhCreatedDate { get; set; }
        public int? VhUpdatedBy { get; set; }
        public DateTime? VhUpdatedDate { get; set; }
        public int? VhDeletedBy { get; set; }
        public DateTime? VhDeletedDate { get; set; }
    }
}
