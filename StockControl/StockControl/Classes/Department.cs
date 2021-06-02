﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    public class Department
    {
        //Properties / Fields
        public int ID { get; set; }
        public string Name { get; set; }
        public int EmployeeCapacity { get; set; }
        public int ProductCapacity { get; set; }
        public int EmployeeCount
        {
            get { return employeesID.Count; }
        }
        public int ProductCount { get; set; }

        private Dictionary<int,int> products = new Dictionary<int,int>();
        private SortedSet<int> employeesID = new SortedSet<int>();

        //Constructors
        public Department() { }
        public Department(int departmentID, string departmentName, int employeeCapacity, int productCapacity)
        {
            ID = departmentID;
            Name = departmentName;
            EmployeeCapacity = employeeCapacity;
            ProductCapacity = productCapacity;
        }

        //Methods
        public void AddProduct(int productId, int quantity)
        {
            if (ProductCount + quantity <= ProductCapacity)
            {
                products.Add(productId, quantity);
                ProductCount += quantity;
            }
            else
            {
                throw new OverCapacityException($"The Department Can't Have More Than {ProductCapacity} Products.");
            }
        }
        public void AddEmployee(int employeeId)
        {
            if (employeesID.Count + 1 <= EmployeeCapacity)
            {
                employeesID.Add(employeeId);
            }
            else
            {
                throw new OverCapacityException($"The Department Can't Have More Than {EmployeeCapacity} Employees.");
            }
        }
        public void RemoveProduct(int productId)
        {
            ProductCount -= products[productId];
            products.Remove(productId);
        }
        public void RemoveEmployee(int employeeId)
        {
            employeesID.Remove(employeeId);
        }
        public void AddQuantity(int productId, int amount)
        {
            if (ProductCount + amount <= ProductCapacity)
            {
                products[productId] += amount;
                ProductCount += amount;
            }
            else
            {
                throw new OverCapacityException($"The Department Can't Have More Than {ProductCapacity} Products.");
            }
        }
        public SortedSet<int> GetEmployeesID()
        {
            return employeesID;
        }
        public Dictionary<int, int> GetProducts()
        {
            return products;
        }
    }
}
