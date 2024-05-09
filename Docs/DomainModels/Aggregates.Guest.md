# Domain Aggregates

## Guest

```csharp
class Guest
{
    // TODO: Add methods
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "firstName": "John",
    "lastName": "Doe",
    "profileImage": "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp",
    "averageRating": 4.5,
    "userId": "00000000-0000-0000-0000-000000000000",
    "dinnerIds": [
        "00000000-0000-0000-0000-000000000000"
    ],
    "billIds": [
        "00000000-0000-0000-0000-000000000000"
    ],
    "menuReviewIds": [
        "00000000-0000-0000-0000-000000000000"
    ],
    "ratings": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "hostId": "00000000-0000-0000-0000-000000000000",
            "dinnerId": "00000000-0000-0000-0000-000000000000",
            "rating": 4,
            "createdDateTime": "2020-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
        }
    ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```