using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelhiveryConsoleApp
{
    public class ShipmentService
    {
        private List<Shipment> shipments = new List<Shipment>();

        private readonly List<string> validStatus = new List<string>()
        {
            "Booked",
            "In Transit",
            "Out for Delivery",
            "Delivered",
            "RTO"
        };

        public string BookShipment(Shipment shipment)
        {
            if (string.IsNullOrWhiteSpace(shipment.AWBNumber))
                return "AWB Number cannot be empty.";

            if (shipments.Any(s => s.AWBNumber == shipment.AWBNumber))
                return "AWB Number already exists.";

            if (shipment.WeightKg <= 0)
                return "Weight must be greater than zero.";

            if (!validStatus.Contains(shipment.Status))
                return "Invalid Status.";

            shipment.ShipmentId = shipments.Count + 1;
            shipment.BookedAt = DateTime.Now;

            shipments.Add(shipment);

            return "Shipment booked successfully.";
        }

        public List<Shipment> ListShipments()
        {
            return shipments;
        }

        public string UpdateStatus(string awb, string newStatus)
        {
            Shipment shipment = shipments.FirstOrDefault(s => s.AWBNumber == awb);

            if (shipment == null)
                return "Shipment not found.";

            if (!validStatus.Contains(newStatus))
                return "Invalid Status.";

            shipment.Status = newStatus;

            return "Shipment status updated successfully.";
        }

        public string CancelShipment(string awb)
        {
            Shipment shipment = shipments.FirstOrDefault(s => s.AWBNumber == awb);

            if (shipment == null)
                return "Shipment not found.";

            shipments.Remove(shipment);

            return "Shipment cancelled successfully.";
        }
    }
}
