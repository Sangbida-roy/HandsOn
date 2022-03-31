// See https://aka.ms/new-console-template for more information
using StudentServiceReference;

Console.WriteLine("Hello, World!");

var service = new StudentServiceClient();
var request = new StudentInfoRequest
{
    Header = new HeaderInfo
    {
        TransactionID = Guid.NewGuid().ToString(),
    },
    Body = new StudentBO
    {
        FirstName = "Test",
        LastName = "Test",
        Marks = 100,
        RollNo = 12345
    }
};
var response = service.CreateStudent(request);
Console.WriteLine(response.Header.TransactionID);
Console.WriteLine(response.Header.CallStatus);

