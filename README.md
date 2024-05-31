# PROG7311_POE_PART_2 Manual



---

### Table of Contents
You're sections headers will be used to reference location of destination.

- [Description](#description)
- [How To Use](#how-to-use)
- [License](#license)
---
#NOTES
- WHEN A NEW USER IS CREATED MAKE SURE TO LOGIN TO THE EMPLOYEE ACCOUNT TO ASSIGN THE NEW USER TO THE ROLE OF FARMER SO THAT YOU ARE ABLE TO ADD PRODUCTS
- THE EDUCATIONAL RESOURCES AND FARMING HUB BLOCKS DO NOT HAVE IMAGES BECAUSE IN THE PRODUCTION MODEL OF THE APP WILL HAVE THUMBNAILS TO VIDEOS.
## Description

This is a web application that is a farming hub that allows for all farmers to add products,discuss new renewable farming techniques, and to educate themselves.

#### Technologies

- Microsoft Visual Studio 2022
- Microsoft Azure

[Back To The Top](#read-me-template)

---

## Login Details for each account type

### Admin 
- Username: NewAdmin
- Password: 123
- 
### Employee
- Username: Employee
- Password: 123

### User
- Username: NewUser
- Password: 123

### Farmer
- Username: Farmer
- Password: 123
  
## Roles 

### Admin
- Has acess to all of the pages and the ability to assign roles to users.

### User
- Only has access to Farming Forums,Farming hub,and education pages
- Default role given to a newly created user and once approved will either be given the role of employee or farmer depending on the situation.
  
### Employee
- Has Access to all pages excpet for the admin controls page
- Employee role is given to a user by the admin once they have been approved

### Farmer
- Has access to all pages excpet for Manage users and Admin controls page.
- Farmer role is given to a user by a employee once they have been approved to have the farmer role.
  
## How To Use

### How to register
- The user must first enter there username and password.
- if the username is already taken the user will be displayed with an error telling them that the username has been taken.
- if the username and password have been entered in correctly the user will then be taken to the Login page.

### How to Login
- The user must enter in there username and password
- if the username does not match any of the accounts in the database the user will be displayed with an error telling them that the username does not exist.
- Once the user has successfully entered in their details they will be taken to the farmers market page where they will only be able to view the Farmers Hub, market, and Education resources as  you are only able to add products to the market once you have been approved to be a farmer and then your account will have the role of farmer.

### How to add a product
- Once the user has the role of Farmer they are able to access the Add Farming Products page.
- Once this page has been selected the user must Enter the product name,Product category,production date, and lastly the product description.
- Once the user has entered in all of these details the must then select the Add product button and this will save the product to the database
  
### How to view all products associated to your account
- A Farmer is able to view all of the products they have added to the market by simply selecting the show products button on the Add Products page
- This will then display all of the farming products in a table to the user.

### How to view all products associated to a farmer
- The Manage Users page is only assecible to Employees and admins.
- The user must select the Manage Users option in the navigation bar.
- The employee will then be taken to the Manage users page where they are able to see all products associated to a farmer they have selected.
- The user must select a farmer from the select farmer combo box.
- the user must then select the date at which the product was listed.
- The user must then select the category of the farming product.
- the user must then click the show modules button.
- Once the show modules button has been clicked the employee will then be displayed with all of the products created by that farmer with the specific filters.

### How to add farming accounts
- This page is only accesible to admins and employees.
- To give the user the role of farmer the employee must select the role farmer from the Select role combo box.
- The employee must then select the username of the user that they wish to give the role of farmer too.
- Once that has been completed the employee must then click the assign role button and this will give the role of farmer to that user.

### How to add roles to accounts
- This page is only accessible to admins.
- The admin must enter in the UserID and then the ID of the Role they wish to assign to a user.
- Once they have completed this the admin must then click the assign role button and this will asign the role to the user.
  
[Back To The Top](#read-me-template)

---

## License

MIT License

Copyright (c) [2017] [James Q Quick]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

[Back To The Top](#read-me-template)

---



[Back To The Top](#read-me-template)
