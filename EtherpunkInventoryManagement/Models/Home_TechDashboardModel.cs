using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EtherpunkInventoryManagement.Models
{
    public class Home_TechDashboardModel
    {
        public List<RecentlyEnteredHardwareInventory> RecentlyEnteredHardwareInventories = new List<RecentlyEnteredHardwareInventory>();
        public List<ValidatedHardwareInventory> UserValidatedItems = new List<ValidatedHardwareInventory>();
        public List<ValidatedHardwareInventory> ITValidatedItems = new List<ValidatedHardwareInventory>();
        public List<UnvalidatedHardwareInventory> UnvalidatedItems = new List<UnvalidatedHardwareInventory>();

        public class RecentlyEnteredHardwareInventory
        {
            public string HardwareInventoryId { get; set; }
            public string ShortHardwareInventoryId { get; set; }
            public string HardwareInventoryName { get; set; }
            public string HardwareLayoutId { get; set; }
            public string HardwareLayoutName { get; set; }
            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime CreatedOn { get; set; }
            public string CreatedById { get; set; }
            public string CreatedByUsername { get; set; }
            public string AssignedToId { get; set; }
            public string AssignedToUsername { get; set; }
        }

        public class ValidatedHardwareInventory
        {
            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime ActualCompletionDate { get; set; }

            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime AuditStartDate { get; set; }

            public string AssignedUserId { get; set; }
            public string AssignedUserName { get; set; }

            public string HardwareInventoryId { get; set; }
            public string HardwareInventoryName { get; set; }

            public string HardwareShortId { get; set; }

            public string HardwareInventoryOwnerId { get; set; }
            public string HardwareInventoryOwnerName { get; set; }

            public string HardwareLayoutId { get; set; }
            public string HardwareLayoutName { get; set; }
        }

        public class UnvalidatedHardwareInventory
        {
            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime ExpectedCompletionDate { get; set; }

            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime AuditStartDate { get; set; }

            public string AssignedUserId { get; set; }
            public string AssignedUserName { get; set; }

            public string HardwareInventoryId { get; set; }
            public string HardwareInventoryName { get; set; }

            public string HardwareShortId { get; set; }

            public string HardwareInventoryOwnerId { get; set; }
            public string HardwareInventoryOwnerName { get; set; }

            public string HardwareLayoutId { get; set; }
            public string HardwareLayoutName { get; set; }
        }
    }
}
