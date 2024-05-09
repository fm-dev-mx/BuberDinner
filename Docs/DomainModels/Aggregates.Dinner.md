# Domain Aggregates

## Dinner

```csharp
class Dinner
{
    // TODO: Add methods
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Yummy Dinner",
    "description": "A dinner with yummy food",
    "startDateTime": "2020-01-01T00:00:00.0000000Z",
    "endDateTime": "2020-01-01T00:00:00.0000000Z",
    "status": "Upcoming", // Upcoming, InProgress, Ended, Cancelled
    "isPublic": true,
    "maxGuests": 10,
    "price": {
        "amount": 10.99,
        "currency": "USD"
    },
    "hostId": "00000000-0000-0000-0000-000000000000",
    "menuId": "00000000-0000-0000-0000-000000000000",
    "location": {
        "name": "Dan's Pizza Place",
        "address": "Berlin, Germany",
        "latitude": 52.520008,
        "longitude": 13.404954
    },
    "reservations": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "guestCount": 2,
            "reservationDateTime": "2020-01-01T00:00:00.0000000Z",
            "reservationStatus": "Reserved", // PendingGuestConfirmation, Reserved, Cancelled
            "guestId": "00000000-0000-0000-0000-000000000000",
            "billId": "00000000-0000-0000-0000-000000000000"
        }
    ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```
