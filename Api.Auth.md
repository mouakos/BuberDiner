
# Buber Dinner API

## Authentication

### Register

```
POST /auth/register
```

#### Register Request

```json
{
  "lastName": "admin",
  "firstName": "admin",
  "password": "admin",
  "email": "admin@admin.com"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "lastName": "admin",
  "firstName": "admin",
  "password": "admin",
  "email": "admin@admin.com"
  "token": "eyJhb.z9qdajXiV"
}
```

### Login

```
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "admin@admin.com",
  "password": "admin"
}
```

#### Login Response

```js
200 OK
```

```json
{
  "lastName": "admin",
  "firstName": "admin",
  "email": "admin@admin.com"
  "token": "eyJhb.z9qdajXiV"
}
```

## Dinner

