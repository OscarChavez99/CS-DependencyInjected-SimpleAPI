# CS-DependencyInjected-SimpleAPI
This project is a simple CRUD application designed to learn how APIs work in ASP.NET. It was created using the "ASP.NET Core Web API" template

## This project allows performing CRUD actions through an API
![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/e701d3ab-795e-4b96-a535-741b6e316062)
  
## 1-To run the project pt.1
1. Open a database management tool and create a database (I named it as follows: "cs_simple_apis") <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/5cd0af97-76cf-474a-88e0-9b40e06f1a32)
2. Create a table named "students" with the following structure <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/bf2ed021-21a2-4f15-b88b-c4f3f6da986c)

## 2-To run the project pt.2
1. Open "CS-DependencyInjected-SimpleAPI.sln"
2. Go to the 'appsettings.json' file <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/30ff449f-4922-47a7-b5c5-d20edf8f519f)
3. If your database is NOT hosted on "localhost", modify the "DataSource" field <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/d086920a-4b3b-49f6-8163-dcdbccc4b559)
4. If you named your database differently, modify it in the "Database" field <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/fd103cd1-1450-4092-a621-55266d1bf9f6)
5. Modify the "User" and "Password" fields if needed

## 3-How to use the program?
- Run the program <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/1cc6b6b6-9b15-4cee-bd00-06f67b587d37)

### 3.1 POST (insert) student
1. Click on "POST" and then on "Try it out" <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/c4f2b6e0-a554-425e-b8ae-1273ba2d38d1)
2. Enter the data you want to insert and then click on "Execute" <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/80f491b9-4357-4561-92f9-600bc2f59f48)

### 3.2 PUT (update) student
1. Click on "PUT" then on "Try it out" <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/61170bda-aef7-4467-9513-e3a84271373c)
2. Enter the user data to modify (remember to enter an existing ID) and click on "Execute" <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/b6d27117-fde9-4b16-9147-4295795c3631)

### 3.3 GetAllStudents (select all)
1. Click on "GetAllStudents" then on "Try it out" <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/8a5a3160-7852-4485-bfdb-e1797f78e50b)
2. Click on "Execute," and you will be able to observe all your records <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/5bfeef12-8766-48b7-9013-0b8320f07afa)

### 3.4 GetStudentById (select)
1. Click on "GetStudentById" then on "Try it out" <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/5dc5fc7b-08a4-40c2-8f80-dc6aa9dd3e83)
2. Enter an existing ID then click on "Execute" <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/e7db64b0-43e7-4723-b0bb-2fac43997b57)
3. You will be able to observe your record <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/e7525d20-bc06-40b3-b267-3a8eeb220e88)

### 3.5 Delete student
1. Click on "Delete" then on "Try it out" <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/45c52dcb-551f-4e13-8721-d7ca593e4c89)
2. Enter an existing ID then click on "Execute" <br> ![image](https://github.com/OscarChavez99/CS-DependencyInjected-SimpleAPI/assets/80979314/8ae048cd-aaca-4d4d-80de-83b37b2a0787)
