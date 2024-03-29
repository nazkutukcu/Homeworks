-- Veritabanı Oluşturma
CREATE DATABASE MyDatabase;

-- Kullanılacak Veritabanı
USE MyDb;

-- Category Tablosu Oluşturma
CREATE TABLE Category (
    ID INT PRIMARY KEY,
    CategoryName NVARCHAR(50)
);

-- Product Tablosu Oluşturma
CREATE TABLE Product (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    Price DECIMAL(10, 2),
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Category(ID)
);

-- Product Tablosuna StockQuantity Alanı Ekleme
ALTER TABLE Product
ADD StockQuantity INT;

-- Veritabanındaki Tabloların Listelenmesi
EXEC sp_tables;

-- Tablo yapısını göster
EXEC sp_columns 'Product';

-- Category tablosuna kategori eklenmesi
INSERT INTO Category (ID, CategoryName) VALUES (1, 'Elektronik');
INSERT INTO Category (ID, CategoryName) VALUES (2, 'Ev Aletleri');

-- Product Tablosuna Birkaç Örnek Satır Eklenmesi
INSERT INTO Product (ProductName, Price, CategoryID, StockQuantity)
VALUES ('Laptop', 1200.00, 1, 10),
       ('Smartphone', 800.00, 2, 15),
       ('Tablet', 500.00, 1, 20);

-- Product Tablosundaki Satırların Listelenmesi
SELECT * FROM Product;

-- Product Tablosundaki Bir Satırın Güncellenmesi
UPDATE Product
SET Price = 1300.00
WHERE ID = 3;

-- Product Tablosundan Bir Satırın Silinmesi
DELETE FROM Product
WHERE ID = 3;

-- Inner Join ile Veritabanındaki İki Tablonun Birleştirilmesi
SELECT Product.ID, Product.ProductName, Product.Price, Category.CategoryName
FROM Product
INNER JOIN Category ON Product.CategoryID = Category.ID;

-- Left Join ile Veritabanındaki İki Tablonun Birleştirilmesi
SELECT Product.ID, Product.ProductName, Product.Price, Category.CategoryName
FROM Product
LEFT JOIN Category ON Product.CategoryID = Category.ID;

-- Right Join ile Veritabanındaki İki Tablonun Birleştirilmesi
SELECT Product.ID, Product.ProductName, Product.Price, Category.CategoryName
FROM Product
RIGHT JOIN Category ON Product.CategoryID = Category.ID;
