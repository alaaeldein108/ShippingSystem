namespace Services.AddressServices.SenderAddressBookService.Dto
{
    public class SenderAddressBookDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? SecondPhone { get; set; }
        public string AreaId { get; set; }
        public string Street { get; set; }
        public bool IsDefault { get; set; } = false;
        public string ClientId { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModificationTime { get; set; }
    }
}
