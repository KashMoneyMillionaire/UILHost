namespace UILHost.Infrastructure.ChangeDataCapture
{
    public class ChangeDataCapturePropertyState
    {
        public string PropertyName { get; set; }
        public object OriginalValue { get; set; }
        public object CurrentValue { get; set; }

        public ChangeDataCapturePropertyState(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        public bool HasChanges()
        {
            if (this.OriginalValue == null || this.CurrentValue == null)
                return true;
            else
                return !this.OriginalValue.Equals(this.CurrentValue);
        }
    }
}
