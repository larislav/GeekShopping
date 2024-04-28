using GeekShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model
{
    [Table("cart_detail")]
    public class CartDetail : BaseEntity
    {
        [ForeignKey("cart_header_id")]
        public long CartHeaderId { get; set; }
        public virtual CartHeader CartHeader { get; set; }

        [ForeignKey("product_id")]
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Column("count")]
        public int Count { get; set; }

    }
}
