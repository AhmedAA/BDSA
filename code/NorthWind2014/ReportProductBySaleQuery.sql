select p.ProductID, p.ProductName, sum(ood.Quantity) as q, month(ood.OrderDate), year(ood.OrderDate)
from Products as p
join (select o.OrderID, o.OrderDate, od.ProductID, od.Quantity from Orders as o join [Order Details] as od on o.OrderID = od.OrderID) as ood
on p.ProductID = ood.ProductID
group by p.ProductID, p.ProductName, month(ood.OrderDate), year(ood.OrderDate)
order by p.ProductID desc;