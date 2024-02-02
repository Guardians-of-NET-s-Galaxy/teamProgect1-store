using System.ComponentModel;

namespace OnlineShop.Domain.Entities.Base;

public class BaseEntity
{
    [Description("شناسه")]
    public long Id { get; set; }

    [Description("حذف شده/نشده")]
    public bool IsDelete { get; set; }

    [Description("تاریخ حذف")]
    public DateTime? DeletionDate { get; set; }
    
}