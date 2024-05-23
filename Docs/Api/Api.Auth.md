# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

#### Register Request

```js
POST /auth/register
```

```json
{
    "firstName": "Amichai",
    "lastName": "Mantinband",
    "email": "amichai@mantinband.com",
    "password": "Amiko1232!"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Amichai",
  "lastName": "Mantinband",
  "email": "amichai@mantinband.com",
  "token": "eyJhb..z9dqcnXoY"
}
```

### Login

#### Login Request

```js
POST /auth/login
```

```json
{
    "email": "amichai@mantinband.com",
    "password": "Amiko1232!"
}
```

```js
200 OK
```

#### Login Response

```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Amichai",
  "lastName": "Mantinband",
  "email": "amichai@mantinband.com",
  "token": "eyJhb..hbbQ"
}
```