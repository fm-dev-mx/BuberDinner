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

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "Francisco",
    "lastName": "Mendoza",
    "email": "francisco.mendoza@example.com",
    "password": "MyPassword123!"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "fcb2b53b-7c59-4e6d-8e3b-920b84764e5d",
  "firstName": "Francisco",
  "lastName": "Mendoza",
  "email": "francisco.mendoza@example.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImZjYjJiNTNiLTdjNTktNGU2ZC04ZTNiLTkyMGI4NDc2NGU1ZCIsImVtYWlsIjoiZnJhbmNpc2NvLm1lbmRvekBiYW5hc3NlY3VyaXMuY29tIiwiaWF0IjoxNjA5Njk0OTc2LCJleHAiOjE2MDk3ODQxNzZ9.kW6wfAMwdyS5DjXKLyRlCGvN8IYCzHeMVvOITGTPsDw"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email": "francisco.mendoza@example.com",
    "password": "MyPassword123!"
}
```

```js
200 OK
```

#### Login Response

```json
{
  "id": "fcb2b53b-7c59-4e6d-8e3b-920b84764e5d",
  "firstName": "Francisco",
  "lastName": "Mendoza",
  "email": "francisco.mendoza@example.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImZjYjJiNTNiLTdjNTktNGU2ZC04ZTNiLTkyMGI4NDc2NGU1ZCIsImVtYWlsIjoiZnJhbmNpc2NvLm1lbmRvekBiYW5hc3NlY3VyaXMuY29tIiwiaWF0IjoxNjA5Njk0OTc2LCJleHAiOjE2MDk3ODQxNzZ9.kW6wfAMwdyS5DjXKLyRlCGvN8IYCzHeMVvOITGTPsDw"
}
```