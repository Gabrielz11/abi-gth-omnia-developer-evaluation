[Back to README](../README.md)

### Sales

#### POST /api/Sales
    - Description: Add a new sale
    - Request Body:
```json
    {
    "date": "2025-05-11T12:19:49.084Z",
    "customer": "string",
    "branch": "string",
    "items": [
        {
        "product": "string",
        "quantity": 0,
        "unitPrice": 0,
        "discount": 0,
        "isCancelled": true
        }
    ],
    "totalAmount": 0,
    "isCancelled": true
    }
```
- Response:
```json
    {
    "data": {
    "id": "3ebca931-b417-4163-97af-b36c62f38bcd",
    "date": "0001-01-01T00:00:00",
    "customer": null,
    "branch": null,
    "items": [],
    "totalAmount": 0,
    "isCancelled": false
    },
    "success": true,
    "message": "Sale created successfully",
    "errors": []
    }
```
#### GET /api/Sales

- Description: Retrieve a list of all sales

- Parameters:
  - `Skip` (optional): Page number for pagination (default: 1)
  - `Take` (optional): Number of items per page (default: 10)
- Response:
```json
 "sales": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "date": "2025-05-11T12:28:30.189Z",
        "customer": "string",
        "branch": "string",
        "items": [
          {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "product": "string",
            "quantity": 0,
            "unitPrice": 0,
            "discount": 0,
            "isCancelled": true
          }
        ],
        "totalAmount": 0,
        "isCancelled": true
      }
```

#### GET /api/Sales/{id}

- Description: Retrieve a specific sale by ID
- Parameters:
  - `id`: Sale ID.
  - Response: 
  ```json
  {
     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "date": "2025-05-11T12:33:36.306Z",
    "customer": "string",
    "branch": "string",
    "items": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "product": "string",
        "quantity": 0,
        "unitPrice": 0,
        "discount": 0,
        "isCancelled": true
      }
    ],
    "totalAmount": 0,
    "isCancelled": true
  }
  ```
#### PUT /api/Sales/{id}
- Description: Update a specific sale
- Path Parameters:
  - `id`:  Sale ID
- Request Body:
  ```json
  {
  "date": "2025-05-11T17:35:54.285Z",
  "customer": "string",
  "branch": "string",
  "items": [
    {
      "product": "string",
      "quantity": 0,
      "unitPrice": 0,
      "discount": 0,
      "isCancelled": true
    }
  ],
  "totalAmount": 0,
  "isCancelled": true
  }
  ```
- Response: 
  ```json
  {
    "data": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "date": "2025-05-11T17:35:54.286Z",
    "customer": "string",
    "branch": "string",
    "items": [
      {
        "product": "string",
        "quantity": 0,
        "unitPrice": 0,
        "discount": 0,
        "isCancelled": true
      }
    ],
    "totalAmount": 0,
    "isCancelled": true
  }
  ```

  #### DELETE /api/Sales/{id}
- Description: Delete a specific sale
- Path Parameters:
  - `id`: Sale ID
- Response: 
  ```json
  {
    "success": true,
    "message": "string",
    "errors": [
      {
        "error": "string",
        "detail": "string"
      }
    ]
  }
  ```

  #### PATCH /api/Sales/{id}
  - Description: Mark the sale as cancelled
- Path Parameters:
  - `id`: Sale ID
- Response: 
  ```json
  {
    "data": {
    "success": true,
    "message": "Sale marked with canceled successfully",
    "errors": []
    },
    "success": true,
    "message": "",
    "errors": []
  }
  ```

#### PATCH /api/Sales/{id}/Items/{itemId}
- Description: Mark the item sale as cancelled
- Path Parameters:
  - `id`: Sale ID
  - `itemId`: Sale Item ID
- Response: 
  ```json
  {
     "data": {
    "success": true,
    "message": "Item marked with canceled successfully",
    "errors": []
  },
  "success": true,
  "message": "",
  "errors": []
  }