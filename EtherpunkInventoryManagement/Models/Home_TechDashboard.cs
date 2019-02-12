using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EtherpunkInventoryManagement.Models
{
    public class Home_TechDashboard
    {
        public List<RecentlyEnteredItem> RecentlyEnteredItemsList = new List<RecentlyEnteredItem>();
        public List<ValidatedItem> UserValidatedItems = new List<ValidatedItem>();
        public List<ValidatedItem> ITValidatedItems = new List<ValidatedItem>();
        public List<UnvalidatedItem> UnvalidatedItems = new List<UnvalidatedItem>();

        public class RecentlyEnteredItem
        {
            public string InventoryId { get; set; }
            public string ShortInventoryId { get; set; }
            public string InventoryName { get; set; }
            public string InventoryTemplateId { get; set; }
            public string InventoryTemplateName { get; set; }
            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime CreatedOn { get; set; }
            public string CreatedById { get; set; }
            public string CreatedByUsername { get; set; }
            public string AssignedToId { get; set; }
            public string AssignedToUsername { get; set; }
        }

        public class ValidatedItem
        {
            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime ActualCompletionDate { get; set; }

            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime AuditStartDate { get; set; }

            public string AssignedUserId { get; set; }
            public string AssignedUserName { get; set; }

            public string InventoryId { get; set; }
            public string InventoryName { get; set; }

            public string ShortId { get; set; }

            public string InventoryOwnerId { get; set; }
            public string InventoryOwnerName { get; set; }

            public string InventoryTemplateId { get; set; }
            public string InventoryTemplateName { get; set; }
        }

        public class UnvalidatedItem
        {
            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime ExpectedCompletionDate { get; set; }

            [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy}", ApplyFormatInEditMode = true)]
            public DateTime AuditStartDate { get; set; }

            public string AssignedUserId { get; set; }
            public string AssignedUserName { get; set; }

            public string InventoryId { get; set; }
            public string InventoryName { get; set; }

            public string ShortId { get; set; }

            public string InventoryOwnerId { get; set; }
            public string InventoryOwnerName { get; set; }

            public string InventoryTemplateId { get; set; }
            public string InventoryTemplateName { get; set; }
        }
    }
}
