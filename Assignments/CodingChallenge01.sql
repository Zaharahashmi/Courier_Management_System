create database DB_Ecommerce;
use DB_Ecommerce;

--Creation of customer table
create table Customers(Customer_id int constraint PK_Customer_ID primary key, 
Firstname varchar(255), 
Lastname varchar(255),
Email varchar(255) constraint UQ_Customer_Email Unique,
Address Text);

insert into customers values (1, 'John','Doe', 'johndoe@example.com', '123 Main St, City'),
(2, 'Jane', 'Smith', 'janesmith@example.com', '456 Elm St, Town'),
(3, 'Robert', 'Johnson', 'robert@example.com', '789 Oak St, Village'),
(4, 'Sarah', 'Brown', 'sarah@example.com', '101 Pine St, Suburb'),
(5, 'David', 'Lee', 'david@example.com', '234 Cedar St, District'),
(6, 'Laura', 'Hall', 'laura@example.com', '567 Birch St, County'),
(7, 'Michael', 'Davis', 'michael@example.com', '890 Maple St, State'),
(8, 'Emma', 'Wilson', 'emma@example.com', '321 Redwood St, Country'),
(9, 'William', 'Taylor', 'william@example.com', '432 Spruce St, Province'),
(10, 'Olivia', 'Adams', 'olivia@example.com', '765 Fir St, Territory');
insert into customers values (11, 'Shakespeare','W', 'shakespeare@example.com', '127 Ym St, City');
insert into customers values (12, 'Edwin','Bose', 'edwin@example.com', '102 Pine St, Suburb');

select * from customers;

create table products(Product_id int constraint PK_Product_ID primary key,
ProductName varchar(255),
price decimal(10,2),
Productdescription text,
StockQuantity int);

insert into products values(1, 'Laptop', 800.00, 'High-performance laptop', 10),
(2, 'Smartphone', 600.00,'Latest smartphone', 15),
(3, 'Tablet', 300.00, 'Portable tablet', 20),
(4, 'Headphones', 150.00,'Noise-canceling', 30),
(5, 'TV', 900.00, '4K Smart TV', 5),
(6, 'Coffee Maker', 50.00, 'Automatic coffee maker', 25),
(7, 'Refrigerator', 700.00, 'Energy-efficient', 10),
(8, 'Microwave Oven', 80.00, 'Countertop microwave', 15),
(9, 'Blender', 70.00,'High-speed blender', 20),
(10, 'Vacuum Cleaner', 120.00, 'Bagless vacuum cleaner', 10);

select * from products;

create table cart(
Cart_id int constraint PK_Cart_ID primary key,
Customer_id int constraint FK_Customer_ID foreign key references Customers(Customer_ID) on delete cascade,
Product_id int constraint FK_Product_ID foreign key references Products(Product_ID) on delete cascade,
quantity int check (quantity>0));

insert into cart values (1, 1, 1, 2),
(2, 1, 3, 1),
(3, 2, 2, 3),
(4, 3, 4, 4),
(5, 3, 5, 2),
(6, 4, 6, 1),
(7, 5, 1, 1),
(8, 6, 10, 2),
(9, 6, 9, 3),
(10, 7, 7, 2);

select  * from cart;

create table orders (Order_id int constraint PK_Order_ID primary key,
customer_id int constraint FK_Cus_ID foreign key references Customers(Customer_ID) on delete cascade,
order_date datetime,
total_price decimal(10,2),
shipping_address text
);

insert into orders values
(1, 1, '2023-01-05', 1200.00, '123 Main St, City'),
(2, 2, '2023-02-10', 900.00, '456 Elm St, Town'),
(3, 3, '2023-03-15', 300.00, '789 Oak St, Village'),
(4, 4, '2023-04-20', 150.00, '101 Pine St, Suburb'),
(5, 5, '2023-05-25', 1800.00, '234 Cedar St, District'),
(6, 6, '2023-06-30', 400.00, '567 Birch St, County'),
(7, 7, '2023-07-05', 700.00, '890 Maple St, State'),
(8, 8, '2023-08-10', 160.00, '321 Redwood St, Country'),
(9, 9, '2023-09-15', 140.00, '432 Spruce St, Province'),
(10, 10, '2023-10-20', 1400.00, '765 Fir St, Territory');
insert into orders values (11, 11, '2022-10-20', 1400.00, '127 Ym St, City');
insert into orders values (12, 2, '2022-09-20', 1900.00, '456 Elm St, Town');


select * from orders;

create table order_items (
order_item_id int constraint PK_Order_Item_ID primary key,
order_id int constraint FK_Order_ID foreign key references Orders(Order_id) on delete cascade,
product_id int constraint FK_Prod_ID foreign key references Products(Product_ID) on delete cascade,
quantity int check (quantity>0),
itemAmount decimal(10,2)
);

insert into order_items values(1, 1, 1, 2, 1600.00),
(2, 1, 3, 1, 300.00),
(3, 2, 2, 3, 1800.00),
(4, 3, 5, 2, 1800.00),
(5, 4, 4, 4, 600.00),
(6, 4, 6, 1, 50.00),
(7, 5, 1, 1, 800.00),
(8, 5, 2, 2, 1200.00),
(9, 6, 10, 2, 240.00),
(10, 6, 9, 3, 210.00);

select * from order_items;


-- 1. Update refrigerator product price to 800.
update products set price=800.00 where product_id=7;
select * from products;

-- 2. Remove all cart items for a specific customer.
select * from cart;
delete from cart where Customer_id=7;

-- 3. Retrieve Products Priced Below $100.
select product_id, productname, price from products
where price<100;

-- 4. Find Products with Stock Quantity Greater Than 5.
select product_id, productname,StockQuantity from products 
where stockQuantity > 5;

-- 5. Retrieve Orders with Total Amount Between $500 and $1000.
select * from orders;
select Order_id, customer_id, total_price from Orders
where total_price between 500 and 1000;

-- 6. Find Products which name end with letter ‘r’.
select * from products;
select Product_id, Productname from products
where Productname like '%r';

-- 7. Retrieve Cart Items for Customer 5.
select * from cart;
select * from cart where Customer_id = 5;

-- 8. Find Customers Who Placed Orders in 2023.
select c.Customer_ID, c.FirstName,o.Order_date from Customers c
join Orders o on c.customer_id=o.customer_id
where Year(o.order_date)=2023;

-- 9. Determine the Minimum Stock Quantity for Each Product Category.
select Min(stockQuantity) as MinimumStockQuantity from products;

-- 10. Calculate the Total Amount Spent by Each Customer.
select c.Customer_id, c.FirstName, SUM(o.Total_Price) as TotalAmount from Customers c
join Orders o on c.customer_id=o.customer_id
group by c.Customer_id, c.FirstName;

select * from customers;
select * from orders;

-- 11. Find the Average Order Amount for Each Customer.
select c.Customer_id, o.Order_id, c.FirstName, AVG(o.Total_Price) as AverageAmount 
from Customers c
join Orders o on c.customer_id=o.customer_id
group by c.Customer_id,o.Order_id, c.FirstName;

-- 12. Count the Number of Orders Placed by Each Customer.
select c.Customer_id, o.Order_id ,c.Firstname, Count(o.customer_id) as NumberOfOrdersPlaced from Customers c
join Orders o on c.customer_id=o.customer_id
group by c.Customer_id, o.Order_id ,c.Firstname;

-- 13. Find the Maximum Order Amount for Each Customer.
select * from customers;
select * from orders;

select c.Customer_id, o.Order_id ,c.Firstname, o.Total_price from customers c
join Orders o on c.customer_id=o.customer_id
where o.total_price=(select MAX(o1.total_price) from Orders o1
where o1.customer_id = o.customer_id);

-- 14. Get Customers Who Placed Orders Totaling Over $1000.
select c.Customer_id, o.Order_id ,c.Firstname, SUM(o.Total_price) as Total from customers c
join Orders o on c.customer_id=o.customer_id
group by c.Customer_id, o.Order_id ,c.Firstname
having sum(o.Total_price)>=1000;

-- 15. Subquery to Find Products Not in the Cart.
select * from products;
select * from cart;

select p.product_id, p.productname from Products p
where NOT EXISTS (select 1 from cart c
where c.product_id= p.product_id);

-- 16. Subquery to Find Customers Who Haven't Placed Orders.
select c.customer_id, c.firstname from customers c
where NOT EXISTS (select 1 from orders o
where o.customer_id = c.customer_id);

-- 17. Subquery to Calculate the Percentage of Total Revenue for a Product.
select * from products;
select * from order_items;

select p.product_id, p.productname, 
SUM(ot.itemAmount) as TotalRevenue, 
(SUM(ot.itemAmount)*100)/ (select SUM(ot1.itemAmount) from order_items ot1) as 'Percentage'
from products p
join order_items ot on ot.product_id=p.product_id
group by p.product_id, p.productname;

-- 18. Subquery to Find Products with Low Stock.
select * from products;
select Product_id, Productname, StockQuantity from products p
where stockquantity=(select Min(stockquantity) from products);

-- 19. Subquery to Find Customers Who Placed High-Value Orders.
select c.Customer_id, o.order_id, c.Firstname from Customers c
join Orders o on c.customer_id = o.customer_id
where c.customer_id=(select o.customer_id from Orders o
group by o.customer_id
having count(o.customer_id)>1);

