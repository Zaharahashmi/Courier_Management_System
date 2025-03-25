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
INSERT INTO Users VALUES(1003, 'Alice Smith', 'alice.smith@gmail.com', 'alice1003', '987654324', '456 Park Avenue, Mumbai, 11001');
INSERT INTO Users VALUES(1004, 'Robert Brown', 'robert.b@gmail.com', 'robert1004', '987654325', '789 Green Road, Delhi, 11223');
INSERT INTO Users VALUES(1005, 'Emily Davis', 'emily.davis@gmail.com', 'emily1005', '987654326', '567 Lake View, Hyderabad, 22112');
INSERT INTO Users VALUES(1006, 'Michael Wilson', 'michael.wilson@gmail.com', 'michael1006', '987654327', '890 Hill Street, Pune, 33221');
INSERT INTO Users VALUES(1007, 'Sophia Martinez', 'sophia.m@gmail.com', 'sophia1007', '987654328', '345 Ocean Drive, Kolkata, 44112');
INSERT INTO Users VALUES(1008, 'David Lee', 'david.lee@gmail.com', 'david1008', '987654329', '123 River Lane, Ahmedabad, 55110');
INSERT INTO Users VALUES(1009, 'Olivia Taylor', 'olivia.taylor@gmail.com', 'olivia1009', '987654330', '678 Sunset Blvd, Chennai, 66009');
INSERT INTO Users VALUES(1010, 'Daniel White', 'daniel.white@gmail.com', 'daniel1010', '987654331', '456 Mountain Rd, Jaipur, 77010');

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
insert into Courier values(3, 'Alice Smith', '456 Park Avenue, Mumbai, 11001', 'Michael Brown', '789 Lake Rd, Mumbai, 654123', 4.75, 'Delivered', 'TRK12346', '2025-03-25');
insert into Courier values(4, 'Robert Brown', '789 Green Road, Delhi, 11223', 'Olivia Johnson', '321 Oak St, Delhi, 543212', 6.25, 'Out for Delivery', 'TRK12347', '2025-03-28');
insert into Courier values(5, 'Emily Davis', '567 Lake View, Hyderabad, 22112', 'Daniel White', '890 River Ln, Hyderabad, 765432', 8.00, 'Pending', 'TRK12348', '2025-04-01');
insert into Courier values(6, 'Michael Wilson', '890 Hill Street, Pune, 33221', 'Sophia Lee', '678 Maple St, Pune, 432156', 3.20, 'Delivered', 'TRK12349', '2025-03-27');
insert into Courier values(7, 'Sophia Martinez', '345 Ocean Drive, Kolkata, 44112', 'David Miller', '999 Beach Rd, Kolkata, 876543', 9.10, 'In Transit', 'TRK12350', '2025-04-03');
insert into Courier values(8, 'David Lee', '123 River Lane, Ahmedabad, 55110', 'Emma Wilson', '222 Hilltop Rd, Ahmedabad, 345678', 2.95, 'Out for Delivery', 'TRK12351', '2025-03-29');
insert into Courier values(9, 'Olivia Taylor', '678 Sunset Blvd, Chennai, 66009', 'Liam Thomas', '555 King St, Chennai, 987654', 5.80, 'Pending', 'TRK12352', '2025-04-05');
insert into Courier values(10, 'Daniel White', '456 Mountain Rd, Jaipur, 77010', 'Noah Carter', '777 Summit Ln, Jaipur, 123987', 6.75, 'Delivered', 'TRK12353', '2025-03-26');

select * from Courier;

--Creation of CourierServices table
create table CourierServices (ServiceID int constraint PF_Service_ID Primary Key,
ServiceName varchar(100),
Cost Decimal(8,2));

--Insertion of values into Courier Service table
insert into CourierServices values(101, 'Standard Delivery', 50.00);
insert into CourierServices values(102, 'Express Delivery', 100.00);
insert into CourierServices values(103, 'Standard Delivery', 50.00);
insert into CourierServices values(104, 'Express Delivery', 100.00);
insert into CourierServices values(105, 'Same-Day Delivery', 150.00);
insert into CourierServices values(106, 'Overnight Delivery', 200.00);
insert into CourierServices values(107, 'Standard Delivery', 50.00);
insert into CourierServices values(108, 'Express Delivery', 100.00);
insert into CourierServices values(109, 'Same-Day Delivery', 150.00);
insert into CourierServices values(110, 'Overnight Delivery', 200.00);

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
insert into Employee values(203, 'Robert', 'robert@gmail.com', '8888888888', 'Delivery Executive', 30000.00); 
insert into Employee values(204, 'Sophia', 'sophia@gmail.com', '7777777777', 'Customer Support', 35000.00);
insert into Employee values(205, 'Michael', 'michael@gmail.com', '6666666666', 'Warehouse Manager', 60000.00); 
insert into Employee values(206, 'Emily', 'emily@gmail.com', '5555551234', 'HR Executive', 45000.00);
insert into Employee values(207, 'David', 'david@gmail.com', '4444444444', 'Finance Analyst', 70000.00);
insert into Employee values(208, 'Olivia', 'olivia@gmail.com', '3333333333', 'Courier Supervisor', 40000.00); 
insert into Employee values(209, 'James', 'james@gmail.com', '2222222222', 'Logistics Coordinator', 55000.00);
insert into Employee values(210, 'Emma', 'emma@gmail.com', '1111111111', 'Operations Head', 90000.00);  

select * from Employee;

--Creation of Location Table
Create table LocationInfo(LocationID int constraint PF_Location_ID primary key,
LocationName varchar(100),
LocationAddress text); 

--insertion of values into Location table
insert into LocationInfo values(99,'Main Hub', '789 Center St, Chennai, 987654');
insert into LocationInfo values(999,'North Street', '123 Main St, Bangalore, 989654');
insert into LocationInfo values(1001, 'South Street', '456 Elm St, Bangalore, 654321');
insert into LocationInfo values(1002, 'East Avenue', '456 Main St, Chennai, 654321');
insert into LocationInfo values(1003, 'West Hub', '789 South St, Hyderabad, 789654');  
insert into LocationInfo values(1004, 'Central Market', '321 East St, Mumbai, 456789');  
insert into LocationInfo values(1005, 'Old Town', '654 West Ave, Pune, 369258');
insert into LocationInfo values(1006, 'New City', '987 Central Rd, Delhi, 741852');  
insert into LocationInfo values(1007, 'Downtown', '159 South St, Kolkata, 987654');  
insert into LocationInfo values(1008, 'Industrial Area', '753 Market St, Coimbatore, 12334');

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
insert into Payment values(3, 3, 1001, 75.00, '2025-03-27'); 
insert into Payment values(4, 4, 1002, 120.00, '2025-03-28');  
insert into Payment values(5, 5, 1003, 90.00, '2025-03-29'); 
insert into Payment values(6, 6, 1004, 200.00, '2025-03-30');  
insert into Payment values(7, 7, 1005, 85.00, '2025-04-01'); 
insert into Payment values(8, 8, 1006, 110.00, '2025-04-02');  
insert into Payment values(9, 9, 1007, 175.00, '2025-04-03');
insert into Payment values(10, 10, 1008, 95.00, '2025-04-04');  

select * from Payment;
