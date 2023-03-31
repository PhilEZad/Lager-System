CREATE TABLE CategoryTable (
    CategoryId INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);
CREATE TABLE ItemTable (
    ItemId INT AUTO_INCREMENT PRIMARY KEY,
    ItemName VARCHAR(100) NOT NULL,
    ItemCategory INT NOT NULL,
    ItemLocation VARCHAR(100) NOT NULL, 
    ItemStatus INT NOT NULL,
    ItemCount INT NOT NULL
);
CREATE TABLE StatusTable (
    StatusId INT AUTO_INCREMENT PRIMARY KEY,
    StatusName VARCHAR(100) NOT NULL,
    StatusDescription VARCHAR(256) NOT NULL
);
ALTER TABLE ItemTable
ADD FOREIGN KEY (ItemStatus) REFERENCES StatusTable(StatusId),
ADD FOREIGN KEY (ItemCategory) REFERENCES CategoryTable(CategoryId);