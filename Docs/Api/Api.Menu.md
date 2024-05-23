# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
  - [Menu](#menu)
    - [Create Menu](#create-menu)
      - [Create Menu Request](#create-menu-request)
      - [Create Menu Response](#create-menu-response)

## Menu

### Create Menu

#### Create Menu Request

```js
POST /hosts/{hostId}/menus
```

```json
{
    "name": "Yummy Menu",
    "description": "A menu with yummy food",
    "sections": [
        {
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles"
                }
            ]
        }
    ]
}
```

#### Create Menu Response

```js
201 Created
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Yummy Menu",
    "description": "A menu with yummy food",
    "averageRating": null,
    "sections": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "id": "00000000-0000-0000-0000-000000000000",
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles"
                }
            ]
        }
    ],
    "hostId": "00000000-0000-0000-0000-000000000000",
    "dinnerIds": [
        "00000000-0000-0000-0000-000000000000",
    ],
    "menuReviewIds": [
        "00000000-0000-0000-0000-000000000000",
    ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```