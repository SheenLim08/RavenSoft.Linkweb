using RavenSoft.Linkweb.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Library.Entities.Helpers
{
    public static class ServiceTypesExtension
    {
        public static ServiceType CreateNewServiceType(string name, string description)
        {
            ServiceType newServiceType = new ServiceType();
            newServiceType.GUID = Guid.NewGuid().ToString();
            newServiceType.Name = name;
            newServiceType.Description = description;
            newServiceType.IsEnable = true;

            return newServiceType;
        }

        public static void UpdateServiceType(this ServiceType serviceTypeToUpdate,
            string name, string description, bool isEnabled)
        {
            serviceTypeToUpdate.Name = name;
            serviceTypeToUpdate.Description = description;
            serviceTypeToUpdate.IsEnable = isEnabled;
        }

        public static IQueryable<ServiceTypeCharge> GetServiceTypeCharges(this ServiceType serviceType)
        {
            return serviceType.ServiceTypeCharges.AsQueryable();
        }

        public static ServiceTypeCharge CreateNewServiceTypeCharge(this ServiceType serviceType, decimal amount, decimal charge, int indexLocation)
        {
            ServiceTypeCharge newServiceTypeCharge = new ServiceTypeCharge();
            newServiceTypeCharge.GUID = Guid.NewGuid().ToString();
            newServiceTypeCharge.ServiceTypeGUID = serviceType.GUID;
            newServiceTypeCharge.IndexLocation = indexLocation;
            newServiceTypeCharge.Amount = amount;
            newServiceTypeCharge.Charge = charge;

            newServiceTypeCharge.ServiceType = serviceType;

            return newServiceTypeCharge;
        }

        public static void UpdateServiceTypeCharge(this ServiceTypeCharge serviceTypeCharge, decimal amount, decimal charge, int indexLocation)
        {
            serviceTypeCharge.Amount = amount;
            serviceTypeCharge.Charge = charge;
            serviceTypeCharge.IndexLocation = indexLocation;
        }

        public static void RemoveServiceTypeCharge(this DbSet<ServiceTypeCharge> serviceTypeCharges, ServiceTypeCharge serviceTypeChargeToRemove)
        {
            serviceTypeCharges.Remove(serviceTypeChargeToRemove);
        }

        public static decimal GetServiceTypeChargeFromAmount(this ServiceType serviceType, decimal amount)
        {
            decimal returnValue = 0.0M;

            foreach (ServiceTypeCharge chargeEntry in serviceType.ServiceTypeCharges.OrderBy(currentServiceTypeCharge => currentServiceTypeCharge.IndexLocation))
            {
                if (amount >= chargeEntry.Amount)
                    returnValue = chargeEntry.Charge;
            }

            return returnValue;
        }
    }
}
