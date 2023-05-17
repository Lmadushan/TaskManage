using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManage.Entities
{
    public enum EvaluationMethod_enum
    {
        [Description("Price Quality Method")]
        [Display(Name = "Price Quality Method")]
        PriceQualityMethod = 1,

        [Description("Lowest Price Conforming")]
        [Display(Name = "Lowest Price Conforming")]
        LowestPriceConforming
    }

    public enum ProjectStatus_enum
    {
        // enum description attibute value [Description("Tender Open")] will use when dropDown select.
        [Description("Tender Open")]
        [Display(Name = "Tender Open")]
        TenderOpen = 1,

        [Description("Closed & Not Submit")]
        [Display(Name = "Closed & Not Submit")]
        ClosedAndNotSubmit = 2,

        [Description("Closed & Pending")]
        [Display(Name = "Closed & Pending")]
        ClosedAndPending = 3,

        [Description("Closed & Revised")]
        [Display(Name = "Closed & Revised")]
        ClosedAndRevised = 4,

        [Description("Closed & Won")]
        [Display(Name = "Closed & Won")]
        ClosedAndWon = 5,

        [Description("Closed & Loss")]
        [Display(Name = "Closed & Loss")]
        ClosedAndLoss = 6,

        [Description("Ongoing Project")]
        [Display(Name = "Ongoing Project")]
        OngoingProject = 7,

        [Description("Practically Completed")]
        [Display(Name = "Practically Completed")]
        PracticallyCompleted = 8,

        [Description("Fully Completed")]
        [Display(Name = "Fully Completed")]
        FullyCompleted = 9,
    }



    public enum SoqLevels_enum
    {
        L1 = 1,
        L2,
        L3,
        L4,
        L5,
        Item

    }

    public enum RateBreakdownStatus_enum
    {
        Incomplete = 1,
        Working,
        Complete
    }

    public enum ProductType_enum
    {
        [Description("Tendering")]
        [Display(Name = "Tendering")]
        Tendering = 1,

        [Description("Cost Controll")]
        [Display(Name = "Cost Controll")]
        CostControll
    }

    public enum LeadStatus_enum
    {
        [Description("Pending")]
        [Display(Name = "Pending")]
        Pending = 1,

        [Description("Approved")]
        [Display(Name = "Approved")]
        Approved = 2,

        [Description("Rejected")]
        [Display(Name = "Rejected")]
        Rejected = 3
    }

    public enum PaymentClaimStatus
    {
        [Description("Pending")]
        [Display(Name = "Pending")]
        Pending = 1,

        [Description("Approved")]
        [Display(Name = "Approved")]
        Approved = 2,

        [Description("Rejected")]
        [Display(Name = "Rejected")]
        Rejected = 3
    }

    public enum ResourceGroup_enum
    {
        Labor = 1,
        Plant,
        Materials,
        Subcontractors,
        OneTimeSubcontractors,
        OneTimeSuppliers,
        Services,
        Assets,
        Others
    }

    public enum OffSiteBreakdownLevel_enum
    {
        Heading = 1,
        Item,
        SubItem
    }
}
