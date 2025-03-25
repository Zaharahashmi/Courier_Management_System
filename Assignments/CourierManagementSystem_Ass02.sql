-- 1. List all customers:  
select * from Users;

-- 2. List all orders for a specific customer: 
select * from Courier where SenderName='Robert Brown';

-- 3. List all couriers:  
select * from Courier;

-- 4. List all packages for a specific order:
select * from Courier where CourierID in(5,8,9);

-- 5. List all deliveries for a specific courier:  
select * from Courier where CourierID=2;

-- 6. List all undelivered packages: 
select * from Courier where Courier_Status!='Delivered';

-- 7. List all packages that are scheduled for delivery today:
select * from Courier where Deliverdate=convert(date, getdate());

-- 8. List all packages with a specific status:  
select * from Courier where Courier_Status='Pending';

-- 9. Calculate the total number of packages for each courier.  
select courierID, count(*) as TotalPackages from Courier group by CourierID;

-- 10. Find the average delivery time for each courier  
select senderName, avg(datediff(day, PaymentDate, Deliverdate)) AS AvgDeliveryTime  
from Courier, Payment  
where Courier.CourierID = Payment.CourierID  
group by senderName;

-- 11. List all packages with a specific weight range: 
select * from Courier where Courier_Weight between 5 and 8;

-- 12. Retrieve employees whose names contain 'John' 
select * from Employee where EmployeeName like '%John%';

-- 13. Retrieve all courier records with payments greater than $50.  
select * from Payment where amount>50;