namespace SchoolClearanceWeb.Model
{
    public class GenerateCouponRequest
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }

    public class CouponResponse
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string FullName { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class GetAllCouponsResponse
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string FullName { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UsedAt { get; set; }
        public string? UsedByUsername { get; set; }
    }

    public class AssignRevokeResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}