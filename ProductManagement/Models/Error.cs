namespace ProductManagement.Models
{
    public class Error
    {
        private const string OperationErrorMessage = "Podczas {0} produktu - wystąpił błąd";
        public string ErrorMessage { get; set; }

        public Error()
        {
        }

        public Error(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public Error(Operation.Name operation)
        {
            string operationName = operation switch
            {
                Operation.Name.Add => "dodawania",
                Operation.Name.Edit => "edytowania",
                Operation.Name.Delete => "usuwania",
                _ => string.Empty
            };
            if (string.IsNullOrWhiteSpace(operationName)) return;
            ErrorMessage = string.Format(OperationErrorMessage, operationName);
        }
    }
}
