# Yper C# Connector
Created and provided by [Alexandre DUBOIS](https://www.linkedin.com/in/alexandredubois/)

Heavily inspired from the [Stuart C# Client](https://github.com/StuartApp/stuart-client-csharp/)

For a complete documentation of all endpoints offered by the Yper API, you can visit [Yper API documentation](https://yper.stoplight.io/).

## Install
Via NuGet Package Manager:

``` bash
$ PM> Install-Package YperConnector
```

## Usage

1. [Initialize Client](#initialize-client)
2. [Create a Prebook](#create-a-prebook)
3. [Validate a Prebook](#validate-a-prebook)

### Initialize client

```c#
var clientId = "<put_your_Client_ID_here>";
var clientSecret = "<put_your_Client_Secret_here>";
var proId = "<put_your_Pro_ID_here>";
var proSecret = "<put_your_Pro_Secret_here>";
var environment = YperConnector.Environment.Production ; // You can also choose YperConnector.Environment.Sandbox;
var yperApi = YperApi.Initialize(environment, clientId, clientSecret, proId, proSecret);
```

### Create a Prebook

**Important**: Even if you can create a Prebook with a minimal set of parameters, we **highly recommend** that you fill as many information as 
you can in order to ensure the delivery process goes well.

```c#
var retailPointId = 123456789; //Id of your retailpoint registered in Yper Shop
var prebook = new PrebookRequest
{
    Order = new Order
    {
        OrderId = "1234",
        TransportType = TransportType.bike //foot, bike, moto, car or break
    },
    DeliveryAddress = new DeliveryAddress
    {
        FormattedAddress = "246 Cours de la Marne, 33800 BORDEAUX"
    },
    DeliveryStart = DateTime.Now.AddDays(1),
    DeliveryEnd = DateTime.Now.AddDays(1).AddHours(2),
    Receiver = new Receiver
    {
        Email = "test@email.com",
        Firstname = "Alexandre",
        Lastname = "Dubois",
        Phone = "+33612345678",
        Type = "user"
    },
    Sender = new Sender
    {
        Type = "retailpoint",
        Id = retailPointId
    },
    Comment = "This delivery contains a bottle of wine. Handle it carefully."
};

var createdPrebook = await yperApi.Booking.Prebook(prebook);
```

### Validate a Prebook

Once you successfully created a prebook you can turn it into a mission validating your prebook :

```c#
var prebookId = 126532;
var mission = await yperApi.Booking.ValidatePrebook(prebookId);
```