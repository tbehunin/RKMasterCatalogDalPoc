using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dapper
{
    public abstract class Product
    {
        public int ProductId { get; set; }
        public ProductType Type { get; set; }
        public string ProductDisplayName { get; set; }
        public Brand Brand { get; set; }
        public string InCommProductUPC { get; set; }
        public string ProductSKU { get; set; }
        public bool IsActive { get; set; }
        public bool IsDigital { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string TempInfoBlob { get; set; }
    }

    public class Voucher : Product
    {
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
    }

    public class GiftCard : Product
    {
        public bool IsVariable { get; set; }
        public decimal FixedAmount { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
    }

    public class PrepaidGiftCard : Product
    {
        public bool IsVariable { get; set; }
        public decimal FixedAmount { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public bool IsBulkProduct { get; set; }
        public string CardHolderAgreementUrl { get; set; }
        public decimal ActivationFee { get; set; }
    }

    public enum ProductType
    {
        Voucher,
        GiftCard,
        PrepaidGiftCard
    }
}
