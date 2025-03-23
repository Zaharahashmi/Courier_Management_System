--Database Creation
create database Courier_Management_System;
use Courier_Management_System;

--Creation of user table
create table Users(UserID int constraint PK_User_ID primary key, 
UserName varchar(255), 
Email varchar(255) Unique,
UserPassword varchar(255),
ContactNumber varchar(20),
UserAddress Text);

select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where TABLE_NAME='Users';

alter table Users drop constraint UQ__Users__A9D1053469AA3ECD;
alter table Users add constraint UQ_Users_Email UNIQUE(Email);

--Insertion of values into the user table
insert into Users values(1001, 'George', 'george@gmail.com', 'george1001', '987654321', '123 Main Street, Chennai, 12334');
insert into Users values(1002, 'John Doe', 'johndoe@gmail.com', 'johndoe1002', '987654323', '124 North Street, Bangalore, 12114');

select * from Users;

--Creation of Courier Table
Create table Courier(CourierID int constraint PF_Courier_ID primary key,
SenderName varchar(255),
SenderAddress text,
ReceiverName varchar(255),
ReceiverAddress text,
Courier_Weight decimal(5,2),
Courier_Status varchar(50),
TrackingNumber varchar(20) constraint UQ_Courier_TN Unique,
Deliverdate date);

--Inserting values into Courier table
insert into Courier values(1, 'John Doe', '124 North Street, Bangalore, 12114', 'Jane Smith', '456 Elm St, Bangalore, 654321', 5.50, 'In Transit', 'TRK12345', '2025-03-30');
insert into Courier values(2, 'George', '123 Main Street, Chennai, 12334', 'Smith', '456 Main St, Chennai, 654321', 7.50, 'In Transit', 'TRK12335', '2025-04-02');

select * from Courier;

--Creation of CourierServices table
create table CourierServices (ServiceID int constraint PF_Service_ID Primary Key,
ServiceName varchar(100),
Cost Decimal(8,2));

--Insertion of values into Courier Service table
insert into CourierServices values(101, 'Standard Delivery', 50.00);
insert into CourierServices values(102, 'Express Delivery', 100.00);

select * from CourierServices;

--Creation of Employee Table
Create table Employee(EmployeeID int constraint PF_Employee_ID primary key,
EmployeeName varchar(255),
Email varchar(255) constraint UQ_Employee_Email Unique,
ContactNumber varchar(20),
EmployeeRole varchar(50),
Salary decimal(10,2));

--insertion of values into Employee table
insert into Employee values(201, 'Alice', 'alice@gmail.com', '5555555555', 'Courier Manager', 50000.00);
insert into Employee values(202, 'Johnson', 'johnson@gmail.com', '9999999999', 'Manager', 80000.00);

select * from Employee;

--Creation of Location Table
Create table LocationInfo(LocationID int constraint PF_Location_ID primary key,
LocationName varchar(100),
LocationAddress text); 

--insertion of values into Location table
insert into LocationInfo values(99,'Main Hub', '789 Center St, Chennai, 987654');
insert into LocationInfo values(999,'North Street', '123 Main St, Bangalore, 989654');

select * from LocationInfo;

--Creation of Payment table
create table Payment(PaymentID int constraint PF_Payment_ID primary key,
CourierID int constraint FK_Payment_CID Foreign Key references Courier(CourierID),
LocationID int constraint FK_Payment_LID Foreign Key references LocationInfo(LocationID),
Amount Decimal(10,2),
PaymentDate date);

--insertion of values into Payment Table
insert into Payment values(1, 1,99,  50.00, '2025-03-23');
insert into Payment values(2, 2,999,  150.00, '2025-03-26');

select * from Payment;