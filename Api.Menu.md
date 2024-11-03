# Create Menu

## Create Menu 

```
POST /hosts/{hostId}/menus
```

### Create Menu Request

```json
{
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "Sections":[
	{
	  "name": "Appetizers",
	  "description": "Starters",
	  "Items":[
		{
		  "name": "Fried Pikles",
		  "description": "Deep fried pickles",
		}
	  ]
	}
  ]
}
```

### Create Menu Response

```js

200 OK
```

```json
{
	id": { "value": "00000000-0000-0000-0000-000000000000" },
    "name": "Yummy Menu",
    "description": "A menu with yummy food",
    "averageRating": null,
    "sections": [
        {
            "id": { "value": "00000000-0000-0000-0000-000000000000" },
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "id": { "value": "00000000-0000-0000-0000-000000000000" },
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles"
                }
            ]
        }
    ],
    "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
    "dinnerIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "menuReviewIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```