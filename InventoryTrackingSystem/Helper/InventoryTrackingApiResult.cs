namespace InventoryTrackingSystem.API.Helper
{
    public class InventoryTrackingApiResult
    {
        public string Message { get; set; } = "İşlem Başarıyla Tamamlandı";
        public object Data { get; set; }
        public bool Status { get; set; } = true;
        public string File { get; set; }
    }
}
