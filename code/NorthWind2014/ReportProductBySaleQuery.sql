select p.ProductID, p.ProductName, ood.Quantity, ood.OrderDate
from Products as p
join (select o.OrderID, o.OrderDate, od.ProductID, od.Quantity from Orders as o join [Order Details] as od on o.OrderID = od.OrderID) as ood
on p.ProductID = ood.ProductID
order by p.ProductID;